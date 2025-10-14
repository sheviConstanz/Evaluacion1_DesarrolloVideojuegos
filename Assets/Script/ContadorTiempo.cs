using UnityEngine;
using TMPro;

public class Contador : MonoBehaviour
{
    [Header("UI")]
    public TMP_Text ContadorTexto;
    [SerializeField] GameObject gameOverCanvas; // (opcional) arrástralo si quieres mostrar Game Over

    [Header("Tiempo")]
    public float TiempoRestante = 60f; // tiempo inicial en segundos
    bool tiempoActivo = true;

    void Start()
    {
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

    // Llama esto desde otros scripts para sumar tiempo (+)
    public void AgregarTiempo(float segundos)
    {
        if (!tiempoActivo) return;
        TiempoRestante += segundos;
        ActualizarTexto();
    }

    void FinDelTiempo()
    {
        if (gameOverCanvas) gameOverCanvas.SetActive(true);
        Time.timeScale = 0f;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Debug.Log("¡Se acabó el tiempo!");
    }
}
