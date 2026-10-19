using TMPro;
using UnityEngine;

public class UIPuntuacion : MonoBehaviour
{
    TMP_Text texto;

    void Awake()
    {
        texto = GetComponent<TMP_Text>();
        Mostrar(0);
    }

    void OnEnable() { RecolectorEscudos.OnPuntuacionCambiada += Mostrar; }
    void OnDisable() { RecolectorEscudos.OnPuntuacionCambiada -= Mostrar; }

    void Mostrar(int puntos)
    {
        texto.text = "Puntuación: " + puntos;
    }
}
