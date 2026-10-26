using UnityEngine;

public class Recuperador : MonoBehaviour
{
    public delegate void Mensaje();
    public static event Mensaje OnRecuperar;

    public float tiempoSeleccion = 2f;
    public float velocidadGiro = 180f;

    float tiempoMirando;
    bool mirado;

    public void OnPointerEnter()
    {
        mirado = true;
        tiempoMirando = 0f;
    }

    public void OnPointerExit()
    {
        mirado = false;
    }

    public void OnPointerClick()
    {
        Recuperar();
    }

    void Update()
    {
        if (!mirado) return;

        tiempoMirando += Time.deltaTime;
        transform.Rotate(0, velocidadGiro * Time.deltaTime, 0);

        if (tiempoMirando >= tiempoSeleccion)
        {
            Recuperar();
            mirado = false;
        }
    }

    void Recuperar()
    {
        Debug.Log("Recuperando los objetos recolectables");
        if (OnRecuperar != null) OnRecuperar();
    }
}
