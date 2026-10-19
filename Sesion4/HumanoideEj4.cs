using UnityEngine;

public class HumanoideEj4 : MonoBehaviour
{
    [SerializeField] Transform escudoObjetivo;
    [SerializeField] Transform objetoAMirar;
    [SerializeField] float radioAlrededorDelEscudo = 1.5f;
    [SerializeField] float velocidadGiro = 240f;

    bool orientando;

    void OnEnable() { ObjetoReferencia.OnCuboCerca += Reaccionar; }
    void OnDisable() { ObjetoReferencia.OnCuboCerca -= Reaccionar; }

    void Reaccionar()
    {
        if (CompareTag("Tipo1")) Teletransportar();
        if (CompareTag("Tipo2")) orientando = true;
    }

    void Teletransportar()
    {
        if (escudoObjetivo == null) return;

        float angulo = Random.Range(0f, 360f) * Mathf.Deg2Rad;
        Vector3 destino = escudoObjetivo.position + new Vector3(Mathf.Cos(angulo), 0f, Mathf.Sin(angulo)) * radioAlrededorDelEscudo;
        destino.y = transform.position.y;

        Vector3 mirar = escudoObjetivo.position - destino;
        mirar.y = 0f;

        SendMessage("Detener", SendMessageOptions.DontRequireReceiver);
        transform.position = destino;
        transform.rotation = Quaternion.LookRotation(mirar);

        Rigidbody rb = GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.position = destino;
            rb.rotation = transform.rotation;
        }

        Debug.Log(name + " teletransportado a " + escudoObjetivo.name);
    }

    void Update()
    {
        if (!orientando || objetoAMirar == null) return;

        Vector3 direccion = objetoAMirar.position - transform.position;
        direccion.y = 0f;
        if (direccion == Vector3.zero) return;

        transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(direccion), velocidadGiro * Time.deltaTime);
    }
}
