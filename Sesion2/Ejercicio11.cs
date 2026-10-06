using UnityEngine;

public class Ejercicio11 : MonoBehaviour
{
    public Transform esfera; 
    public float speed = 5f;

    void Update()
    {

        Vector3 direccion = esfera.position - transform.position;
        direccion.y = 0;
        direccion = direccion.normalized;
        transform.Translate(direccion * speed * Time.deltaTime, Space.World);
    }
}