using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class HumanoideEj3 : MonoBehaviour
{
    public static event Action<string> OnCuboToca;

    [SerializeField] Transform escudoSeleccionado;
    [SerializeField] Color colorAlTocarEscudo = Color.yellow;
    [SerializeField] float velocidad = 3f;

    Rigidbody rb;
    Animator animator;
    Transform objetivo;
    float distanciaParada;
    bool buscandoEscudo;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        rb.isKinematic = true;
        animator = GetComponentInChildren<Animator>();
        if (animator != null) animator.applyRootMotion = false;
    }

    void OnEnable() { OnCuboToca += Reaccionar; }
    void OnDisable() { OnCuboToca -= Reaccionar; }

    void Reaccionar(string grupoTocado)
    {
        if (grupoTocado == "Tipo2" && CompareTag("Tipo1"))
        {
            buscandoEscudo = false;
            objetivo = escudoSeleccionado;
            distanciaParada = 1.2f;
        }
        else if (grupoTocado == "Tipo1" && CompareTag("Tipo2"))
        {
            buscandoEscudo = true;
            BuscarEscudo();
        }
    }

    void BuscarEscudo()
    {
        objetivo = null;
        distanciaParada = 0f;
        float mejor = Mathf.Infinity;

        foreach (GameObject escudo in GameObject.FindGameObjectsWithTag("Escudo2"))
        {
            float d = Vector3.Distance(transform.position, escudo.transform.position);
            if (d < mejor) { mejor = d; objetivo = escudo.transform; }
        }

        if (objetivo == null) buscandoEscudo = false;
    }

    public void Detener()
    {
        objetivo = null;
        buscandoEscudo = false;
        Animar(false);
    }

    void FixedUpdate()
    {
        if (buscandoEscudo && objetivo == null) BuscarEscudo();
        if (objetivo == null) { Animar(false); return; }

        Vector3 destino = objetivo.position;
        destino.y = rb.position.y;
        Vector3 direccion = destino - rb.position;

        if (direccion.magnitude <= distanciaParada) { Animar(false); return; }

        rb.MovePosition(Vector3.MoveTowards(rb.position, destino, velocidad * Time.fixedDeltaTime));
        rb.MoveRotation(Quaternion.LookRotation(direccion));
        Animar(true);
    }

    void OnTriggerEnter(Collider other) { Procesar(other.gameObject); }
    void OnCollisionEnter(Collision collision) { Procesar(collision.collider.gameObject); }

    void Procesar(GameObject otro)
    {
        if (otro.CompareTag("Player"))
        {
            Debug.Log("El cubo ha tocado a " + name + " (" + tag + ")");
            OnCuboToca?.Invoke(tag);
        }
        else if (otro.CompareTag("Escudo2"))
        {
            Debug.Log(name + " ha chocado con " + otro.name + ": cambia de color");
            Colorear(colorAlTocarEscudo);
            Detener();
        }
    }

    void Colorear(Color color)
    {
        foreach (Renderer r in GetComponentsInChildren<Renderer>())
        {
            foreach (Material m in r.materials)
            {
                if (m.HasProperty("_BaseColor")) m.SetColor("_BaseColor", color);
                if (m.HasProperty("_Color")) m.SetColor("_Color", color);
            }
        }
    }

    void Animar(bool andando)
    {
        if (animator == null || animator.runtimeAnimatorController == null) return;
        foreach (AnimatorControllerParameter p in animator.parameters)
            if (p.name == "Caminando") animator.SetBool("Caminando", andando);
    }
}
