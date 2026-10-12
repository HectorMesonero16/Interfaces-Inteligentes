using UnityEngine;

public class Lanzador : MonoBehaviour
{
    public Vector3 fuerzaLanzamiento = new Vector3(0f, 3f, 5f);
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            rb.AddForce(fuerzaLanzamiento, ForceMode.Impulse);
        }
    }
}