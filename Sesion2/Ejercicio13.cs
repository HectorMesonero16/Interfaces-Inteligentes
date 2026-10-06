using UnityEngine;

public class Ejercicio13 : MonoBehaviour
{
    public float speed = 5f;
    public float rotationSpeed = 100f; 

    void Update()
    {

        float giro = Input.GetAxis("Horizontal");
        transform.Rotate(0, giro * rotationSpeed * Time.deltaTime, 0);
        transform.Translate(transform.forward * speed * Time.deltaTime, Space.World);
        Debug.DrawRay(transform.position, transform.forward * 3f, Color.red);
    }
}