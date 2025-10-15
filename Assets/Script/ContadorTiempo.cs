using UnityEngine;
using TMPro;

public class Contador : MonoBehaviour
{
    [Header("UI")]
    public TMP_Text ContadorTexto;
    [SerializeField] GameObject gameOverCanvas;

    [Header("Tiempo restante (para perder)")]
    public float TiempoRestante = 60f;
    bool tiempoActivo = true;

    [Header("Tiempo de partida (cronómetro general)")]
    public float TiempoPartida { get; private set; } = 0f;
    bool partidaActiva = true;

    // ✅ Nueva bandera: si el jugador ya ganó
    [Header("Control de flujo")]
    public bool yaGano = false;

    void Start()
    {
        if (gameOverCanvas) gameOverCanvas.SetActive(false);
        ActualizarTexto();
    }

    void Update()
    {
        // Cuenta regresiva del HUD
        if (tiempoActivo)
        {
            TiempoRestante -= Time.deltaTime;

            if (TiempoRestante <= 0f)
            {
                TiempoRestante = 0f;
                tiempoActivo = false;

                // ✅ Solo mostramos Game Over si NO ganó
                if (!yaGano)
                    FinDelTiempo();
            }

            ActualizarTexto();
        }

        // Cronómetro general de la partida (para Winner)
        if (partidaActiva)
            TiempoPartida += Time.deltaTime;
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
    Debug.Log($"[GameOver] Lo llamó: {name} | restante={TiempoRestante:F2}");
    if (gameOverCanvas) gameOverCanvas.SetActive(true);
    PausarJuego();
    Debug.Log("⏰ ¡Se acabó el tiempo!");
    }

    public float GetTiempoPartida() => TiempoPartida;
    
}
