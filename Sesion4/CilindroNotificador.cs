using System;
using UnityEngine;

public class CilindroNotificador : MonoBehaviour
{
    public static event Action<Transform> OnCuboColisiona;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) Notificar();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player")) Notificar();
    }

    void Notificar()
    {
        Debug.Log("El cubo ha chocado con el cilindro");
        OnCuboColisiona?.Invoke(transform);
    }
}
