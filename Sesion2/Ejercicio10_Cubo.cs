using UnityEngine;

public class Ejercicio10_Cubo : MonoBehaviour
{
    public float speed = 5f;

    void Update()
    {
        Vector3 direccion = Vector3.zero;

        if (Input.GetKey(KeyCode.UpArrow)) 
        {
            direccion += Vector3.up;
        }
        
        if (Input.GetKey(KeyCode.DownArrow)) 
        {
            direccion += Vector3.down;
        }

        if (Input.GetKey(KeyCode.LeftArrow)) 
        {
            direccion += Vector3.left;
        }
        
        if (Input.GetKey(KeyCode.RightArrow)) 
        {
            direccion += Vector3.right;
        }

        direccion = direccion.normalized;
        transform.Translate(direccion * speed * Time.deltaTime);
    }
}