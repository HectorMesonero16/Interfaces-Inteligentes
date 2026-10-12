using UnityEngine;

public class Ejercicio2 : MonoBehaviour
{
    private Renderer renderizador;

    void Start()
    {
        renderizador = GetComponent<Renderer>();
    }

    private void OnCollisionEnter(Collision colision)
    {
        Debug.Log("Colisión detectada con: " + colision.gameObject.name);
        if (renderizador != null)
        {
            renderizador.material.color = Random.ColorHSV();
        }
    }
}