using UnityEngine;

public class ReceptorCilindro : MonoBehaviour
{
    [SerializeField] Transform objetivoTipo2;
    [SerializeField] bool colorearSegunGrupo = true;
    [SerializeField] float velocidad = 3f;
    [SerializeField] float distanciaParada = 1.2f;

    Transform objetivo;
    Animator animator;

    void Awake()
    {
        animator = GetComponentInChildren<Animator>();
        if (animator != null) animator.applyRootMotion = false;

        if (colorearSegunGrupo)
        {
            if (CompareTag("Tipo1")) Colorear(Color.red);
            if (CompareTag("Tipo2")) Colorear(Color.green);
        }
    }

    void OnEnable()
    {
        if (CompareTag("Tipo1")) CilindroNotificador.OnCuboColisiona += IrHaciaTipo2;
        if (CompareTag("Tipo2")) CilindroNotificador.OnCuboColisiona += IrHaciaCilindro;
    }

    void OnDisable()
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
        if (objetivo == null) { Animar(false); return; }

        Vector3 destino = objetivo.position;
        destino.y = transform.position.y;
        Vector3 direccion = destino - transform.position;

        if (direccion.magnitude <= distanciaParada) { Animar(false); return; }

        transform.position = Vector3.MoveTowards(transform.position, destino, velocidad * Time.deltaTime);
        transform.rotation = Quaternion.LookRotation(direccion);
        Animar(true);
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
