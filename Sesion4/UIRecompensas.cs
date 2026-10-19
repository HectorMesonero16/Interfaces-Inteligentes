using System.Collections;
using TMPro;
using UnityEngine;

public class UIRecompensas : MonoBehaviour
{
    [SerializeField] TMP_Text textoAviso;
    [SerializeField] TMP_Text textoContador;
    [SerializeField] Transform contenedorIconos;
    [SerializeField] GameObject prefabIcono;
    [SerializeField] float duracionAviso = 2.5f;

    void Awake()
    {
        textoAviso.gameObject.SetActive(false);
        textoContador.text = "Recompensas: 0";
    }

    void OnEnable() { SistemaRecompensas.OnRecompensaObtenida += Mostrar; }
    void OnDisable() { SistemaRecompensas.OnRecompensaObtenida -= Mostrar; }

    void Mostrar(int numero, string nombre)
    {
        textoContador.text = "Recompensas: " + numero;
        if (contenedorIconos != null && prefabIcono != null) Instantiate(prefabIcono, contenedorIconos);
        StopAllCoroutines();
        StartCoroutine(MostrarAviso("¡Recompensa!\n" + nombre));
    }

    IEnumerator MostrarAviso(string mensaje)
    {
        textoAviso.text = mensaje;
        textoAviso.gameObject.SetActive(true);
        yield return new WaitForSeconds(duracionAviso);
        textoAviso.gameObject.SetActive(false);
    }
}
