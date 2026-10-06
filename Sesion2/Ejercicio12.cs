using UnityEngine;

public class Ejercicio12 : MonoBehaviour
{
    public Transform esfera; 
    public float speed = 5f;

    void Update()
    {

        Vector3 objetivoMirada = new Vector3(esfera.position.x, transform.position.y, esfera.position.z);
        transform.LookAt(objetivoMirada);
        Vector3 direccionMundo = (objetivoMirada - transform.position).normalized;
        transform.Translate(direccionMundo * speed * Time.deltaTime, Space.World);
    }
}