using UnityEngine;

public class Ejercicio1 : MonoBehaviour{
	
    public int framesDeEspera = 120; 
    
    private float[] vectorColor = new float[3];
    private int contadorFrames = 0;
    private Renderer objRenderer;

    void Start(){
        objRenderer = GetComponent<Renderer>();
        vectorColor[0] = Random.Range(0.0f, 1.0f);
        vectorColor[1] = Random.Range(0.0f, 1.0f);
        vectorColor[2] = Random.Range(0.0f, 1.0f);
        ActualizarColor();
    }

    void Update(){
        contadorFrames++;
		
        if (contadorFrames >= framesDeEspera){
            contadorFrames = 0;
            int posicionAleatoria = Random.Range(0, 3);
            vectorColor[posicionAleatoria] = Random.Range(0.0f, 1.0f);
            ActualizarColor();
        }
    }

    void ActualizarColor(){
        if (objRenderer != null){
            objRenderer.material.color = new Color(vectorColor[0], vectorColor[1], vectorColor[2]);
        }
    }
}
