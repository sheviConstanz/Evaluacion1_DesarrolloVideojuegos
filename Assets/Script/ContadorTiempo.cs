using UnityEngine;
using TMPro;

public class Contador : MonoBehaviour
{
    [Header("UI")]
    public TMP_Text ContadorTexto;          // Texto TMP donde se mostrará el tiempo
    [SerializeField] GameObject gameOverCanvas; // ← arrástralo en el Inspector

    [Header("Tiempo")]
    public float TiempoRestante = 60f; // Tiempo en segundos
    private bool tiempoActivo = true;

    void Start()
    {
        // Asegura que el GameOver esté oculto al iniciar
        if (gameOverCanvas) gameOverCanvas.SetActive(false);
        ActualizarContador();
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

        ActualizarContador();
    }

    void ActualizarContador()
    {
        if (ContadorTexto)
            ContadorTexto.text = "Tiempo restante: " + TiempoRestante.ToString("f2") + "seg";
    }

    void FinDelTiempo()
    {
        // Mostrar Game Over
        if (gameOverCanvas) gameOverCanvas.SetActive(true);

        // Pausar juego y mostrar cursor (opcional)
        Time.timeScale = 0f;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        Debug.Log("¡Se acabó el tiempo!");
    }
}

