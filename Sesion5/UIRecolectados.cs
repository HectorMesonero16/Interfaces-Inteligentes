using UnityEngine;

public class UIRecolectados : MonoBehaviour
{
    TMPro.TMP_Text texto;

    void Start()
    {
        texto = GetComponent<TMPro.TMP_Text>();
        texto.text = "Recolectados: 0";
        Recolectable.OnRecolectado += Mostrar;
    }

    void OnDestroy()
    {
        Recolectable.OnRecolectado -= Mostrar;
    }

    void Mostrar(int total)
    {
        texto.text = "Recolectados: " + total;
    }
}
