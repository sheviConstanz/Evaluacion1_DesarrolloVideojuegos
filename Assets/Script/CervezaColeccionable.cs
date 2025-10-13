using UnityEngine;

[RequireComponent(typeof(Collider))]
public class CervezaColeccionable : MonoBehaviour
{
    [Header("Referencias")]
    public GameObject visual;        // arrastra el hijo "Visual"
    public AudioSource audioFuente;  // opcional (en el padre)

    [Header("Jugador")]
    public string etiquetaJugador = "Player";

    // referencia al contador de la UI
    private ContadorItems contador;

    bool recogida = false;

    void Awake()
    {
        // busca una vez el contador en la escena
        contador = FindObjectOfType<ContadorItems>();
        var col = GetComponent<Collider>();
        if (col) col.isTrigger = true; // aseguramos trigger
    }

    void OnTriggerEnter(Collider other)
    {
        if (recogida) return;
        if (!other.CompareTag(etiquetaJugador)) return;

        recogida = true;

        // 1) ocultar el visual (hijo animado)
        if (visual) visual.SetActive(false);

        // 2) reproducir SFX si hay
        float delay = 0f;
        if (audioFuente && audioFuente.clip)
        {
            audioFuente.Play();
            delay = audioFuente.clip.length;
        }

        // 3) sumar al contador de la UI (si existe)
        if (contador) contador.SumarItem();
        else Debug.LogWarning("No se encontró ContadorItems en la escena.");

        // 4) destruir el objeto (tras el audio si corresponde)
        Destroy(gameObject, delay);
    }
}
