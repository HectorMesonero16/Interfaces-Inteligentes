using UnityEngine;

public class SistemaRecompensas : MonoBehaviour
{
    public delegate void Mensaje(int numero, string nombre);
    public static event Mensaje OnRecompensaObtenida;

    public int puntosPorRecompensa = 100;
    public string[] nombres = { "Medalla de bronce", "Medalla de plata", "Medalla de oro", "Corona de campeón" };

    int entregadas = 0;

    void Start()
    {
        RecolectorEscudos.OnPuntuacionCambiada += Comprobar;
    }

    void OnDestroy()
    {
        RecolectorEscudos.OnPuntuacionCambiada -= Comprobar;
    }

    void Comprobar(int puntuacion)
    {
        while (entregadas < puntuacion / puntosPorRecompensa)
        {
            string nombre = nombres[Mathf.Min(entregadas, nombres.Length - 1)];
            entregadas++;
            Debug.Log("Recompensa: " + nombre);
            if (OnRecompensaObtenida != null) OnRecompensaObtenida(entregadas, nombre);
        }
    }
}
