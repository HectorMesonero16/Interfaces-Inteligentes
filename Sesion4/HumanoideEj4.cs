using UnityEngine;

public class HumanoideEj4 : MonoBehaviour
{
    public Transform escudoObjetivo;
    public Transform objetoAMirar;
    public float radioAlrededorDelEscudo = 1.5f;

    void Start()
    {
        ObjetoReferencia.OnCuboCerca += Reaccionar;
    }

    void OnDestroy()
    {
        ObjetoReferencia.OnCuboCerca -= Reaccionar;
    }

    void Reaccionar()
    {
        if (CompareTag("Tipo1")) Teletransportar();
        if (CompareTag("Tipo2")) Orientar();
    }

    void Teletransportar()
    {
        Vector2 circulo = Random.insideUnitCircle.normalized * radioAlrededorDelEscudo;
        Vector3 destino = escudoObjetivo.position + new Vector3(circulo.x, 0, circulo.y);
        destino.y = transform.position.y;

        SendMessage("Detener", SendMessageOptions.DontRequireReceiver);
        transform.position = destino;

        Rigidbody rb = GetComponent<Rigidbody>();
        if (rb != null) rb.position = destino;

        Vector3 mirar = escudoObjetivo.position;
        mirar.y = transform.position.y;
        transform.LookAt(mirar);

        Debug.Log(name + " teletransportado a " + escudoObjetivo.name);
    }

    void Orientar()
    {
        Vector3 mirar = objetoAMirar.position;
        mirar.y = transform.position.y;
        transform.LookAt(mirar);
    }
}
