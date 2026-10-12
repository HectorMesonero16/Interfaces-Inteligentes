using UnityEngine;

public class Ejercicio1 : MonoBehaviour
{
    public float velocidad = 7f;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");
        rb.linearVelocity = new Vector3(x * velocidad, rb.linearVelocity.y, z * velocidad);
    }
}