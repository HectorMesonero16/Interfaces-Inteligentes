using UnityEngine;

public class CamaraSeguimiento : MonoBehaviour
{
    public Vector3 desplazamiento = new Vector3(0, 8, -9);

    GameObject cubo;

    void Start()
    {
        cubo = GameObject.FindWithTag("Player");
    }

    void LateUpdate()
    {
        transform.position = cubo.transform.position + desplazamiento;
        transform.LookAt(cubo.transform);
    }
}
