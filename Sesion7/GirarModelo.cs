using UnityEngine;

public class GirarModelo : MonoBehaviour
{
    public float velocidad = 45f;

    bool girando = false;

    void Update()
    {
        if (girando)
            transform.Rotate(0, velocidad * Time.deltaTime, 0);
    }

    public void Activar()
    {
        girando = true;
    }

    public void Desactivar()
    {
        girando = false;
    }
}
