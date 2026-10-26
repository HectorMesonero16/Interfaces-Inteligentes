using UnityEngine;

public class Recolectable : MonoBehaviour
{
    public delegate void Mensaje(int total);
    public static event Mensaje OnRecolectado;
    public static int total = 0;

    public float distanciaRecoleccion = 3f;
    public float velocidad = 6f;

    Transform jugador;
    Vector3 escalaOriginal;
    bool mirado;
    bool volando;
    bool recogido;

    void Start()
    {
        jugador = Camera.main.transform;
        escalaOriginal = transform.localScale;
        Recuperador.OnRecuperar += Volar;
    }

    void OnDestroy()
    {
        Recuperador.OnRecuperar -= Volar;
    }

    public void OnPointerEnter()
    {
        mirado = true;
        transform.localScale = escalaOriginal * 1.2f;
    }

    public void OnPointerExit()
    {
        mirado = false;
        transform.localScale = escalaOriginal;
    }

    public void OnPointerClick()
    {
        if (Vector3.Distance(transform.position, jugador.position) <= distanciaRecoleccion) Recoger();
    }

    void Volar()
    {
        volando = true;
    }

    void Update()
    {
        float distancia = Vector3.Distance(transform.position, jugador.position);

        if (mirado && distancia <= distanciaRecoleccion) Recoger();

        if (volando)
        {
            transform.position = Vector3.MoveTowards(transform.position, jugador.position, velocidad * Time.deltaTime);
            if (distancia < 1f) Recoger();
        }
    }

    void Recoger()
    {
        if (recogido) return;
        recogido = true;
        total++;
        Debug.Log("Recolectado " + name + ". Total: " + total);
        if (OnRecolectado != null) OnRecolectado(total);
        gameObject.layer = 0;
        gameObject.SetActive(false);
    }
}
