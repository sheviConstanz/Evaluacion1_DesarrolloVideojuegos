using UnityEngine;
using TMPro;

[RequireComponent(typeof(Collider))]
[RequireComponent(typeof(AudioSource))]
public class MetaWinner : MonoBehaviour
{
    [Header("Detección del jugador")]
    [SerializeField] string tagJugador = "Player";

    [Header("UI Winner")]
    [SerializeField] GameObject winnerCanvas;
    [SerializeField] TMP_Text winnerItemsText;
    [SerializeField] TMP_Text winnerTimeText;

    [Header("Configuración")]
    [SerializeField] bool pausarAlGanar = true;
    [SerializeField] bool exigirTodosLosItems = false;


    [Header("Audio de Victoria")]
    [SerializeField] AudioClip sonidoVictoria; // 🎵 arrastra aquí el clip


    private AudioSource audioSource;

    Contador contador;
    ContadorItems items;

    void Reset()
    {
        var col = GetComponent<Collider>();
        if (col) col.isTrigger = true;
    }

    void Awake()
    {
        contador = FindFirstObjectByType<Contador>();
        items = FindFirstObjectByType<ContadorItems>();
        audioSource = GetComponent<AudioSource>();
        if (winnerCanvas) winnerCanvas.SetActive(false);
    }

    void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag(tagJugador)) return;
        if (exigirTodosLosItems && items && items.Recogidos < items.Total) return;

        MostrarWinner();
    }

    void MostrarWinner()
    {
        if (!winnerCanvas)
        {
            Debug.LogError("WinnerCanvas no asignado.");
            return;
        }

        // 🎵 Reproducir sonido de victoria
        if (sonidoVictoria && audioSource)
        {
            audioSource.clip = sonidoVictoria;
            audioSource.Play();
        }

        // Actualizar textos
        if (winnerItemsText && items)
            winnerItemsText.text = $"Cristales: {items.Recogidos} / {items.Total}";

        if (winnerTimeText && contador)
        {
            float t = contador.GetTiempoPartida();
            int min = Mathf.FloorToInt(t / 60f);
            float seg = t % 60f;
            winnerTimeText.text = $"Tiempo: {min:00}:{seg:00.00}";
        }

        // Mostrar panel
        winnerCanvas.SetActive(true);
        var cv = winnerCanvas.GetComponent<Canvas>();
        if (cv) { cv.overrideSorting = true; cv.sortingOrder = 500; }

        if (pausarAlGanar)
        {
            if (contador) contador.PausarJuego();
            else Time.timeScale = 0f;
        }


        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        Debug.Log("🏆 ¡Meta alcanzada! Mostrando Winner y reproduciendo sonido.");
    }
}
