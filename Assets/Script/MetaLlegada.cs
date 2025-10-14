using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Collider))]
public class MetaLlegada : MonoBehaviour
{
    [Header("Detección")]
    public string etiquetaJugador = "Player";

    [Header("Cambio de escena")]
    [Tooltip("Si es >= 0 y hay LoadManager en la escena, se usará este índice con barra de carga.")]
    public int indiceEscenaSiguiente = -1;

    [Tooltip("Si no hay LoadManager o no quieres usar índice, puedes poner el nombre de la escena aquí.")]
    public string nombreEscenaSiguiente = "";

    [Header("Feedback (opcional)")]
    public AudioSource audioFuente;
    public float retardoAntesDeSalir = 0.5f;

    private bool activada = false;

    void Reset()
    {
        var col = GetComponent<Collider>();
        if (col) col.isTrigger = true;
    }

    void OnTriggerEnter(Collider other)
    {
        if (activada) return;
        if (!other.CompareTag(etiquetaJugador)) return;
        activada = true;

        // SFX opcional
        float delay = 0f;
        if (audioFuente && audioFuente.clip)
        {
            audioFuente.Play();
            delay = Mathf.Max(delay, audioFuente.clip.length);
        }

        Invoke(nameof(CambiarEscena), Mathf.Max(delay, retardoAntesDeSalir));
    }

    void CambiarEscena()
    {
        // Asegurar que el tiempo esté normal por si alguien lo pausó antes
        Time.timeScale = 1f;

        // 1) Usar LoadManager (si existe y se dio un índice válido)
        var loader = FindObjectOfType<LoadManager>();
        if (loader != null && indiceEscenaSiguiente >= 0)
        {
            loader.SceneLoad(indiceEscenaSiguiente); // usa tu panel+slider de carga
            return;
        }

        // 2) Cargar por nombre (si se indicó)
        if (!string.IsNullOrWhiteSpace(nombreEscenaSiguiente))
        {
            SceneManager.LoadScene(nombreEscenaSiguiente);
            return;
        }

        // 3) Fallback: volver al menú principal
        SceneManager.LoadScene("MainMenu");
    }
}
