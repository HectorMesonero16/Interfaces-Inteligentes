using UnityEngine;

// Va en cada ImageTarget.
// Detectado() y Perdido() se llaman desde los eventos On Target Found y
// On Target Lost del Default Observer Event Handler (en el Inspector).
public class AvisoObjetivo : MonoBehaviour
{
    public TMPro.TMP_Text texto;
    public string nombre = "Astronauta";

    int vecesDetectado = 0;

    public void Detectado()
    {
        vecesDetectado++;
        texto.text = nombre + " detectado (" + vecesDetectado + " veces)";
        Debug.Log(nombre + " detectado");
    }

    public void Perdido()
    {
        texto.text = nombre + " perdido";
        Debug.Log(nombre + " perdido");
    }
}
