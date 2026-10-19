using UnityEngine;

public class ReceptorCilindro : MonoBehaviour
{
    public Transform objetivoTipo2;
    public bool colorearSegunGrupo = true;
    public float velocidad = 3f;
    public float distanciaParada = 1.2f;

    Transform objetivo;
    Animator animator;

    void Start()
    {
        animator = GetComponentInChildren<Animator>();

        if (CompareTag("Tipo1"))
        {
            CilindroNotificador.OnCuboColisiona += IrHaciaTipo2;
            if (colorearSegunGrupo) Colorear(Color.red);
        }

        if (CompareTag("Tipo2"))
        {
            CilindroNotificador.OnCuboColisiona += IrHaciaCilindro;
            if (colorearSegunGrupo) Colorear(Color.green);
        }
    }

    void OnDestroy()
    {
        CilindroNotificador.OnCuboColisiona -= IrHaciaTipo2;
        CilindroNotificador.OnCuboColisiona -= IrHaciaCilindro;
    }

    void IrHaciaTipo2(Transform cilindro)
    {
        objetivo = objetivoTipo2;
    }

    void IrHaciaCilindro(Transform cilindro)
    {
        objetivo = cilindro;
    }

    void Update()
    {
        if (objetivo == null) return;

        Vector3 destino = objetivo.position;
        destino.y = transform.position.y;

        if (Vector3.Distance(transform.position, destino) > distanciaParada)
        {
            transform.position = Vector3.MoveTowards(transform.position, destino, velocidad * Time.deltaTime);
            transform.LookAt(destino);
            Animar(true);
        }
        else
        {
            Animar(false);
        }
    }

    void Colorear(Color color)
    {
        foreach (Renderer rd in GetComponentsInChildren<Renderer>())
            rd.material.color = color;
    }

    void Animar(bool andando)
    {
        if (animator == null || animator.runtimeAnimatorController == null) return;
        foreach (AnimatorControllerParameter p in animator.parameters)
            if (p.name == "Caminando") animator.SetBool("Caminando", andando);
    }
}
