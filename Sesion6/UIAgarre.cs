using UnityEngine;

public class UIAgarre : MonoBehaviour
{
    public TMPro.TMP_Text texto;

    int vecesAgarrado = 0;

    void Start()
    {
        texto.text = "Agarra el " + name;
    }

    public void Agarrar()
    {
        vecesAgarrado++;
        texto.text = name + " agarrado (" + vecesAgarrado + " veces)";
        Debug.Log(name + " agarrado");
    }

    public void Soltar()
    {
        texto.text = name + " soltado";
    }
}
