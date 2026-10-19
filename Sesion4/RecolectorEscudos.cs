using UnityEngine;

public class RecolectorEscudos : MonoBehaviour
{
    public delegate void Mensaje(int puntuacion);
    public static event Mensaje OnPuntuacionCambiada;

    public int puntuacion = 0;

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger con: " + other.gameObject.name);
        Recoger(other.gameObject);
    }

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Colisión con: " + collision.collider.gameObject.name);
        Recoger(collision.collider.gameObject);
    }

    void Recoger(GameObject escudo)
    {
        int puntos = 0;
        if (escudo.CompareTag("Escudo1")) puntos = 5;
        if (escudo.CompareTag("Escudo2")) puntos = 10;
        if (puntos == 0) return;

        escudo.tag = "Untagged";
        puntuacion = puntuacion + puntos;
        Debug.Log("+" + puntos + " puntos. Total: " + puntuacion);

        if (OnPuntuacionCambiada != null) OnPuntuacionCambiada(puntuacion);
        Destroy(escudo);
    }
}
