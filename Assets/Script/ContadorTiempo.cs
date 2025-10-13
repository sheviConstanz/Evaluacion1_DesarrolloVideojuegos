using UnityEngine;
using TMPro;

public class Contador : MonoBehaviour
{
    public TMP_Text ContadorTexto;     // Texto TMP donde se mostrará el tiempo
    public float TiempoRestante = 60f; // Tiempo inicial en segundos (1 minuto)
    private bool tiempoActivo = true;  // Controla si el contador está corriendo

    private void Start()
    {
        ActualizarContador();
    }

    private void Update()
    {
        if (!tiempoActivo) return;

        // Restar tiempo cada frame
        TiempoRestante -= Time.deltaTime;

        // Evitar que baje de 0
        if (TiempoRestante <= 0)
        {
            TiempoRestante = 0;
            tiempoActivo = false;
            FinDelTiempo(); // Llama un método al terminar
        }

        ActualizarContador();
    }

    void ActualizarContador()
{
    if (ContadorTexto != null)
        ContadorTexto.text = " ⏱ Tiempo restante: " + TiempoRestante.ToString("f2") + "seg";
}


    void FinDelTiempo()
    {
        Debug.Log("¡Se acabó el tiempo!");
        // Aquí puedes añadir acciones al finalizar:
        // - Mostrar un panel de derrota
        // - Detener movimiento del jugador
        // - Reiniciar la escena, etc.
    }
}
