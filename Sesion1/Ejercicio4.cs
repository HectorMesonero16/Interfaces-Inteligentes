using UnityEngine;

public class Ejercicio4 : MonoBehaviour{
    private GameObject cubo;
    private GameObject cilindro;

    void Start(){
        cubo = GameObject.FindWithTag("Cubo");
        cilindro = GameObject.FindWithTag("Cilindro");
    }

    void Update(){
        if (cubo != null && cilindro != null){
            float distCubo = Vector3.Distance(transform.position, cubo.transform.position);
            float distCilindro = Vector3.Distance(transform.position, cilindro.transform.position);

            Debug.Log("Distancia al cubo: " + distCubo);
            Debug.Log("Distancia al cilindro: " + distCilindro);
        }
    }
}