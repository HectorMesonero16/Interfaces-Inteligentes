using UnityEngine;

public class CuboFisico : MonoBehaviour
{
    public float aceleracion = 25f;
    public float velocidadMaxima = 6f;

    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.constraints = RigidbodyConstraints.FreezeRotation;
    }

    void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        if (rb.linearVelocity.magnitude < velocidadMaxima)
            rb.AddForce(new Vector3(horizontal, 0, vertical) * aceleracion, ForceMode.Acceleration);
    }
}
