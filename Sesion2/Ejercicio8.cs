using UnityEngine;

public class Ejercicio8 : MonoBehaviour
{

    public Vector3 moveDirection = new Vector3(1f,0f,0f);
    public float speed = 5f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Vector3 posicionInicial = transform.position;
        posicionInicial.y = 0f;
        transform.position = posicionInicial; 
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(moveDirection * speed * Time.deltaTime);
    }
}
