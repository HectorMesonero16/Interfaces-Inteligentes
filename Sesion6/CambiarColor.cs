using UnityEngine;

public class CambiarColor : MonoBehaviour
{
    public Color colorSeleccionado = Color.green;

    Renderer rd;
    Color colorOriginal;

    void Start()
    {
        rd = GetComponent<Renderer>();
        colorOriginal = rd.material.color;
    }

    public void Seleccionar()
    {
        rd.material.color = colorSeleccionado;
        Debug.Log(name + " seleccionado");
    }

    public void Deseleccionar()
    {
        rd.material.color = colorOriginal;
    }
}
