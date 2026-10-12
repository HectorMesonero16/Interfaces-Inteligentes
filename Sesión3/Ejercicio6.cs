using UnityEngine;

public class MoverHaciaObjetivo : MonoBehaviour
{
    public Transform cilindroObjetivo;
    public GameObject cuboObstaculo;

    public float velocidad = 3f;
    public Material nuevoMaterialCubo; 

    private bool materialCambiado = false;

    void Update()
    {
        if (cilindroObjetivo != null)
        {
            transform.position = Vector3.MoveTowards(
                transform.position, 
                cilindroObjetivo.position, 
                velocidad * Time.deltaTime
            );
        }

        if (cuboObstaculo != null && !materialCambiado)
        {
            float distanciaAlCubo = Vector3.Distance(transform.position, cuboObstaculo.transform.position);
            if (distanciaAlCubo <= 1.2f)
            {
                CambiarMaterialDelCubo();
                materialCambiado = true;
            }
        }
    }

    void CambiarMaterialDelCubo()
    {
        Renderer renderCubo = cuboObstaculo.GetComponent<Renderer>();
        
        if (renderCubo != null)
        {
            if (nuevoMaterialCubo != null)
            {
                renderCubo.material = nuevoMaterialCubo;
            }
            else
            {
                renderCubo.material.color = Color.red;
            }

            Debug.Log("¡La esfera alcanzó el cubo obstáculo! Material cambiado.");
        }
    }
}