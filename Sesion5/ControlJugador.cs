using UnityEngine;

public class ControlJugador : MonoBehaviour
{
    public float velocidad = 3f;
    public float anguloMinimo = 30f;
    public float anguloMaximo = 80f;
    public Transform cabeza;

    Rigidbody rb;
    Transform camara;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        camara = Camera.main.transform;
    }

    void Update()
    {
#if UNITY_EDITOR
        transform.Rotate(0, Input.GetAxis("Mouse X") * 3, 0);
        cabeza.Rotate(-Input.GetAxis("Mouse Y") * 3, 0, 0);
#endif
    }

    void FixedUpdate()
    {
        Vector3 adelante = camara.forward;
        adelante.y = 0;
        adelante.Normalize();

        Vector3 derecha = camara.right;
        derecha.y = 0;
        derecha.Normalize();

        Vector3 movimiento = adelante * Input.GetAxis("Vertical") + derecha * Input.GetAxis("Horizontal");

        float inclinacion = camara.eulerAngles.x;
        if (inclinacion > anguloMinimo && inclinacion < anguloMaximo)
            movimiento = adelante;

        rb.linearVelocity = new Vector3(movimiento.x * velocidad, rb.linearVelocity.y, movimiento.z * velocidad);
    }
}