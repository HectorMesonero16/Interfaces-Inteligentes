using UnityEngine;

public class Ejercicio5 : MonoBehaviour
{
    public GameObject objeto1;
    public GameObject objeto2;
    public GameObject objeto3;

    public Vector3 desplazamiento1;
    public Vector3 desplazamiento2;
    public Vector3 desplazamiento3;

    private Vector3 posOriginal1;
    private Vector3 posOriginal2;
    private Vector3 posOriginal3;

    void Start()
    {
        if (objeto1 != null) posOriginal1 = objeto1.transform.position;
        if (objeto2 != null) posOriginal2 = objeto2.transform.position;
        if (objeto3 != null) posOriginal3 = objeto3.transform.position;
    }

    void Update()
    {
        if (Input.GetAxis("Jump") > 0)
        {
            if (objeto1 != null) objeto1.transform.position = posOriginal1 + desplazamiento1;
            if (objeto2 != null) objeto2.transform.position = posOriginal2 + desplazamiento2;
            if (objeto3 != null) objeto3.transform.position = posOriginal3 + desplazamiento3;
        }
    }
}
