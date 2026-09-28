using UnityEngine;

public class Ejercicio2 : MonoBehaviour
{
    public Vector3 vector1 = new Vector3(0.0f, 1.0f, 0.0f);
    public Vector3 vector2 = new Vector3(1.0f, 0.0f, 1.0f);

    public float magnitudV1;
    public float magnitudV2;
    public float angulo;
    public float distancia;
    public string mensajeAltura;

    void Start()
    {
        magnitudV1 = vector1.magnitude;
        magnitudV2 = vector2.magnitude;
        
        angulo = Vector3.Angle(vector1, vector2);
        
        distancia = Vector3.Distance(vector1, vector2);
        
        if (vector1.y > vector2.y)
            mensajeAltura = "El vector 1 está a una altura mayor.";
        else if (vector2.y > vector1.y)
            mensajeAltura = "El vector 2 está a una altura mayor.";
        else
            mensajeAltura = "Ambos vectores están a la misma altura.";

        Debug.Log("Magnitud V1: " + magnitudV1);
        Debug.Log("Magnitud V2: " + magnitudV2);
        Debug.Log("Ángulo: " + angulo);
        Debug.Log("Distancia: " + distancia);
        Debug.Log(mensajeAltura);
    }
}
