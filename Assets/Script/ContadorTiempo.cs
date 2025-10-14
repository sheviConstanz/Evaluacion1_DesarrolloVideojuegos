/*using UnityEngine;
using TMPro;

public class Contador : MonoBehaviour
{
    [Header("UI")]
    public TMP_Text ContadorTexto;
    [SerializeField] GameObject gameOverCanvas; // opcional

    [Header("Tiempo")]
    public float TiempoRestante = 60f; // tiempo inicial en segundos
    bool tiempoActivo = true;

    // Guardamos el valor inicial para calcular tiempo transcurrido
    public float TiempoInicial { get; private set; }

    void Start()
    {
        TiempoInicial = TiempoRestante;

        if (gameOverCanvas) gameOverCanvas.SetActive(false);
        ActualizarTexto();
    }

    void Update()
    {
        if (!tiempoActivo) return;

        TiempoRestante -= Time.deltaTime;

        if (TiempoRestante <= 0f)
        {
            TiempoRestante = 0f;
            tiempoActivo = false;
            FinDelTiempo();
        }

        ActualizarTexto();
    }

    void ActualizarTexto()
    {
        if (ContadorTexto)
            ContadorTexto.text = "Tiempo restante: " + TiempoRestante.ToString("F2") + "seg";
    }

    // Suma tiempo desde otros scripts (ej: ítems)
    public void AgregarTiempo(float segundos)
    {
        if (!tiempoActivo) return;
        TiempoRestante += segundos;
        ActualizarTexto();
    }

    // Devuelve el tiempo que tardó el jugador: inicial - restante
    public float GetTiempoTranscurrido()
    {
    return Time.timeSinceLevelLoad; // segundos desde que empezó la escena
    }

    // Útil para pausar cuando se gana también
    public void PausarJuego()
    {
        tiempoActivo = false;
        Time.timeScale = 0f;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    void FinDelTiempo()
    {
        if (gameOverCanvas) gameOverCanvas.SetActive(true);
        PausarJuego();
        Debug.Log("⏰ ¡Se acabó el tiempo!");
    }
}
*/

using UnityEngine;
using TMPro;

public class Contador : MonoBehaviour
{
    [Header("UI")]
    public TMP_Text ContadorTexto;           // Texto TMP donde se mostrará el tiempo restante
    [SerializeField] GameObject gameOverCanvas; // Panel Game Over (opcional)

    [Header("Tiempo restante (para perder)")]
    public float TiempoRestante = 60f;  // tiempo inicial en segundos
    bool tiempoActivo = true;

    [Header("Tiempo de partida (cronómetro general)")]
    public float TiempoPartida { get; private set; } = 0f;
    bool partidaActiva = true;

    void Start()
    {
        if (gameOverCanvas) gameOverCanvas.SetActive(false);
        ActualizarTexto();
    }

    void Update()
    {
        // ↓ Cuenta regresiva (HUD)
        if (tiempoActivo)
        {
            TiempoRestante -= Time.deltaTime;
            if (TiempoRestante <= 0f)
            {
                TiempoRestante = 0f;
                tiempoActivo = false;
                FinDelTiempo();
            }
            ActualizarTexto();
        }

        // ↓ Cronómetro de tiempo total de partida
        if (partidaActiva)
        {
            TiempoPartida += Time.deltaTime;
        }
    }

    void ActualizarTexto()
    {
        if (ContadorTexto)
            ContadorTexto.text = "Tiempo restante: " + TiempoRestante.ToString("F2") + " seg";
    }

    public void AgregarTiempo(float segundos)
    {
        if (!tiempoActivo) return;
        TiempoRestante += segundos;
        ActualizarTexto();
    }

    public void PausarJuego()
    {
        tiempoActivo = false;
        partidaActiva = false;
        Time.timeScale = 0f;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    void FinDelTiempo()
    {
        if (gameOverCanvas) gameOverCanvas.SetActive(true);
        PausarJuego();
        Debug.Log("⏰ ¡Se acabó el tiempo!");
    }

    // ✅ Tiempo total de la partida (para el Winner)
    public float GetTiempoPartida()
    {
        return TiempoPartida;
    }
}
