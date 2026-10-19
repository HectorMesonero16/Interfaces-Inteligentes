using System;
using UnityEngine;

public class SistemaRecompensas : MonoBehaviour
{
    public static event Action<int, string> OnRecompensaObtenida;

    [SerializeField] int puntosPorRecompensa = 100;
    [SerializeField] string[] nombres = { "Medalla de bronce", "Medalla de plata", "Medalla de oro", "Corona de campeón" };

    int entregadas;

    void OnEnable() { RecolectorEscudos.OnPuntuacionCambiada += Comprobar; }
    void OnDisable() { RecolectorEscudos.OnPuntuacionCambiada -= Comprobar; }

    void Comprobar(int puntuacion)
    {
        while (entregadas < puntuacion / puntosPorRecompensa)
        {
            string nombre = nombres[Mathf.Min(entregadas, nombres.Length - 1)];
            entregadas++;
            Debug.Log("Recompensa: " + nombre);
            OnRecompensaObtenida?.Invoke(entregadas, nombre);
        }
    }
}
