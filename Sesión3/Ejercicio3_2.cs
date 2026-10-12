using UnityEngine;

public class ZonaDano : MonoBehaviour
{
    public float cantidadDano = 10f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            EstadoJugador jugador = other.GetComponent<EstadoJugador>();
            if (jugador != null)
            {
                jugador.danoAcumulado += cantidadDano;
                Debug.Log("¡Aviso! Daño acumulado: " + jugador.danoAcumulado);
            }
        }
    }
}