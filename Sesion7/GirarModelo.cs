using UnityEngine;

// Va en cada modelo 3D (hijo de su ImageTarget).
// El modelo gira mientras su imagen se está viendo.
// Activar() y Desactivar() se llaman desde On Target Found y On Target Lost.
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
