using System;
using UnityEngine;

public class ObjetoReferencia : MonoBehaviour
{
    public static event Action OnCuboCerca;

    [SerializeField] float distanciaActivacion = 3f;

    Transform cubo;
    bool cuboDentro;

    void Start()
    {
        cubo = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        Vector3 diferencia = cubo.position - transform.position;
        diferencia.y = 0f;
        bool dentro = diferencia.magnitude <= distanciaActivacion;

        if (dentro && !cuboDentro)
        {
            Debug.Log("El cubo se ha acercado a " + name);
            OnCuboCerca?.Invoke();
        }

        cuboDentro = dentro;
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(transform.position, distanciaActivacion);
    }
}
