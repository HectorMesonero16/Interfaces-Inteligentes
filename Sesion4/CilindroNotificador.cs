using UnityEngine;

public class CilindroNotificador : MonoBehaviour
{
    public delegate void Mensaje(Transform cilindro);
    public static event Mensaje OnCuboColisiona;

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
        if (OnCuboColisiona != null) OnCuboColisiona(transform);
    }
}
