using UnityEngine;

public class ObjetoReferencia : MonoBehaviour
{
    public delegate void Mensaje();
    public static event Mensaje OnCuboCerca;

    public float distanciaActivacion = 3f;

    GameObject cubo;
    bool cuboDentro;

    void Start()
    {
        cubo = GameObject.FindWithTag("Player");
    }

    void Update()
    {
        bool dentro = Vector3.Distance(cubo.transform.position, transform.position) <= distanciaActivacion;

        if (dentro && !cuboDentro)
        {
            Debug.Log("El cubo se ha acercado a " + name);
            if (OnCuboCerca != null) OnCuboCerca();
        }

        cuboDentro = dentro;
    }
}
