using UnityEngine;

public class Ejercicio6 : MonoBehaviour
{
	
	public float velocidad = 5f;

    void Update()
    {  
        float vertical = Input.GetAxis("Vertical");
        float horizontal = Input.GetAxis("Horizontal");
        float resultado = velocidad * vertical * horizontal;

        if (Input.GetKey(KeyCode.UpArrow))
        {
            Debug.Log("Flecha arriba - Resultado " + resultado);
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            Debug.Log("Flecha abajo - Resultado " + resultado);
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            Debug.Log("Flecha izquierda - Resultado " + resultado);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            Debug.Log("Flecha derecha - Resultado " + resultado);
        }
    }
}
