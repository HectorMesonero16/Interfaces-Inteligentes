using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class CuboFisico : MonoBehaviour
{
    [SerializeField] float aceleracion = 25f;
    [SerializeField] float velocidadMaxima = 6f;
    [SerializeField] float impulsoSalto = 5f;

    Rigidbody rb;
    Vector2 entrada;
    bool saltar;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        rb.isKinematic = false;
        rb.constraints = RigidbodyConstraints.FreezeRotation;
    }

    void Update()
    {
        entrada = LeerTeclado();
        if (SaltoPulsado() && Physics.Raycast(transform.position, Vector3.down, 0.6f)) saltar = true;
    }

    void FixedUpdate()
    {
        Vector3 fuerza = new Vector3(entrada.x, 0f, entrada.y) * aceleracion;
        Vector3 velocidad = rb.linearVelocity;
        velocidad.y = 0f;

        if (velocidad.magnitude < velocidadMaxima || Vector3.Dot(velocidad, fuerza) < 0f)
            rb.AddForce(fuerza, ForceMode.Acceleration);

        if (saltar)
        {
            rb.AddForce(Vector3.up * impulsoSalto, ForceMode.VelocityChange);
            saltar = false;
        }
    }

    Vector2 LeerTeclado()
    {
#if ENABLE_INPUT_SYSTEM
        var k = UnityEngine.InputSystem.Keyboard.current;
        if (k == null) return Vector2.zero;
        float x = 0f, y = 0f;
        if (k.aKey.isPressed || k.leftArrowKey.isPressed) x--;
        if (k.dKey.isPressed || k.rightArrowKey.isPressed) x++;
        if (k.sKey.isPressed || k.downArrowKey.isPressed) y--;
        if (k.wKey.isPressed || k.upArrowKey.isPressed) y++;
        return new Vector2(x, y).normalized;
#else
        return new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;
#endif
    }

    bool SaltoPulsado()
    {
#if ENABLE_INPUT_SYSTEM
        var k = UnityEngine.InputSystem.Keyboard.current;
        return k != null && k.spaceKey.wasPressedThisFrame;
#else
        return Input.GetKeyDown(KeyCode.Space);
#endif
    }
}
