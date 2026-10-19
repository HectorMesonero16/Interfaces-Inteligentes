using UnityEngine;

public class UIRecompensas : MonoBehaviour
{
    public TMPro.TMP_Text textoAviso;
    public TMPro.TMP_Text textoContador;
    public Transform contenedorIconos;
    public GameObject prefabIcono;
    public float duracionAviso = 2.5f;

    void Start()
    {
        textoAviso.gameObject.SetActive(false);
        textoContador.text = "Recompensas: 0";
        SistemaRecompensas.OnRecompensaObtenida += Mostrar;
    }

    void OnDestroy()
    {
        SistemaRecompensas.OnRecompensaObtenida -= Mostrar;
    }

    void Mostrar(int numero, string nombre)
    {
        textoContador.text = "Recompensas: " + numero;
        textoAviso.text = "¡Recompensa!\n" + nombre;
        textoAviso.gameObject.SetActive(true);

        if (contenedorIconos != null && prefabIcono != null) Instantiate(prefabIcono, contenedorIconos);

        CancelInvoke("OcultarAviso");
        Invoke("OcultarAviso", duracionAviso);
    }

    void OcultarAviso()
    {
        textoAviso.gameObject.SetActive(false);
    }
}
