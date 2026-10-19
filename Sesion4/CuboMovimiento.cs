using UnityEngine;

public class CuboMovimiento : MonoBehaviour
{
    public float velocidad = 5f;

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        transform.Translate(new Vector3(horizontal, 0, vertical) * velocidad * Time.deltaTime, Space.World);
    }
}
