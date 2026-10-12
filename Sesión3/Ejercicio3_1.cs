using UnityEngine;

public class ZonaEfecto : MonoBehaviour
{
    public Color colorEfecto = Color.green;
    private Color colorOriginal;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Renderer render = other.GetComponent<Renderer>();
            if (render != null)
            {
                colorOriginal = render.material.color; 
                render.material.color = colorEfecto;   
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Renderer render = other.GetComponent<Renderer>();
            if (render != null)
            {
                render.material.color = colorOriginal; 
            }
        }
    }
}