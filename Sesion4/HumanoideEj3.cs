using UnityEngine;

public class HumanoideEj3 : MonoBehaviour
{
    public delegate void Mensaje(string grupoTocado);
    public static event Mensaje OnCuboToca;

    public Transform escudoSeleccionado;
    public Color colorAlTocarEscudo = Color.yellow;
    public float velocidad = 3f;

    Rigidbody rb;
    Animator animator;
    Transform objetivo;
    float distanciaParada;
    bool buscandoEscudo;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponentInChildren<Animator>();
        OnCuboToca += Reaccionar;
    }

    void OnDestroy()
    {
        OnCuboToca -= Reaccionar;
    }

    void Reaccionar(string grupoTocado)
    {
        if (grupoTocado == "Tipo2" && CompareTag("Tipo1"))
        {
            buscandoEscudo = false;
            objetivo = escudoSeleccionado;
            distanciaParada = 1.2f;
        }

        if (grupoTocado == "Tipo1" && CompareTag("Tipo2"))
        {
            buscandoEscudo = true;
            BuscarEscudo();
        }
    }

    void BuscarEscudo()
    {
        objetivo = null;
        distanciaParada = 0f;
        float menorDistancia = Mathf.Infinity;

        foreach (GameObject escudo in GameObject.FindGameObjectsWithTag("Escudo2"))
        {
            float distancia = Vector3.Distance(transform.position, escudo.transform.position);
            if (distancia < menorDistancia)
            {
                menorDistancia = distancia;
                objetivo = escudo.transform;
            }
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
        if (objetivo == null) return;

        Vector3 destino = objetivo.position;
        destino.y = rb.position.y;

        if (Vector3.Distance(rb.position, destino) > distanciaParada)
        {
            rb.MovePosition(Vector3.MoveTowards(rb.position, destino, velocidad * Time.fixedDeltaTime));
            transform.LookAt(destino);
            Animar(true);
        }
        else
        {
            Animar(false);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        Procesar(other.gameObject);
    }

    void OnCollisionEnter(Collision collision)
    {
        Procesar(collision.collider.gameObject);
    }

    void Procesar(GameObject otro)
    {
        if (otro.CompareTag("Player"))
        {
            Debug.Log("El cubo ha tocado a " + name + " (" + tag + ")");
            if (OnCuboToca != null) OnCuboToca(tag);
        }

        if (otro.CompareTag("Escudo2"))
        {
            Debug.Log(name + " ha chocado con " + otro.name);
            foreach (Renderer rd in GetComponentsInChildren<Renderer>())
                rd.material.color = colorAlTocarEscudo;
            Detener();
        }
    }

    void Animar(bool andando)
    {
        if (animator == null || animator.runtimeAnimatorController == null) return;
        foreach (AnimatorControllerParameter p in animator.parameters)
            if (p.name == "Caminando") animator.SetBool("Caminando", andando);
    }
}
