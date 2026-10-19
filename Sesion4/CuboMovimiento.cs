using UnityEngine;

public class CuboMovimiento : MonoBehaviour
{
    [SerializeField] float velocidad = 5f;

    void Update()
    {
        Vector2 e = LeerTeclado();
        transform.Translate(new Vector3(e.x, 0f, e.y) * velocidad * Time.deltaTime, Space.World);
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
}
