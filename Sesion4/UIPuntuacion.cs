using UnityEngine;

public class UIPuntuacion : MonoBehaviour
{
    TMPro.TMP_Text texto;

    void Start()
    {
        texto = GetComponent<TMPro.TMP_Text>();
        texto.text = "Puntuación: 0";
        RecolectorEscudos.OnPuntuacionCambiada += Mostrar;
    }

    void OnDestroy()
    {
        RecolectorEscudos.OnPuntuacionCambiada -= Mostrar;
    }

    void Mostrar(int puntuacion)
    {
        texto.text = "Puntuación: " + puntuacion;
    }
}
