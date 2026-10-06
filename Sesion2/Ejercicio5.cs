using UnityEngine;

public class MoverConEspacio : MonoBehaviour
{
    public Vector3 desplazamiento;
    private Vector3 posicionOriginal;    
    private bool movido = false;

    void Start(){
        posicionOriginal = transform.position;
    }

    void Update(){
        float inputEspacio = Input.GetAxis("Jump");

        if (inputEspacio > 0 && !movido){
            transform.position = posicionOriginal + desplazamiento;
            movido = true;
        }
        else if (inputEspacio == 0){
            movido = false;
        }
    }
}