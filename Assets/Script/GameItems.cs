using UnityEngine;
using TMPro;

public class ContadorItems : MonoBehaviour
{
    [Header("UI HUD")]
    public TMP_Text textoContador;        // "Cristales: X / Y"

    [Header("Meta")]
    public int totalItems = 5;
    public float segundosPorItem = 5f;

    [Header("Winner UI")]
    [SerializeField] GameObject winnerCanvas;    // Canvas/Panel Winner (desactivado al inicio)
    [SerializeField] TMP_Text winnerItemsText;   // ej: "Cristales: 5 / 5"
    [SerializeField] TMP_Text winnerTimeText;    // ej: "Tiempo: 34.27 s"

    [Header("Referencias")]
    public Contador contador; // arrástralo; si queda vacío se busca

    int itemsRecogidos = 0;

    void Awake()
    {
        if (!contador) contador = FindFirstObjectByType<Contador>();
        ActualizarUI();

        if (winnerCanvas) winnerCanvas.SetActive(false);
    }

    // Llama esto cuando se recoja un ítem
    public void SumarItem()
    {
        itemsRecogidos++;
        ActualizarUI();

        // Sumar tiempo por ítem
        if (contador) contador.AgregarTiempo(segundosPorItem);

        // ¿Completó todos?
        if (itemsRecogidos >= totalItems)
            MostrarWinner();
    }

    void ActualizarUI()
    {
        if (textoContador)
            textoContador.text = "Cristales: " + itemsRecogidos + " / " + totalItems;
    }

    /*void MostrarWinner()
{
    if (!winnerCanvas)
    {
        Debug.LogError("❌ winnerCanvas no asignado/encontrado.");
        return;
    }

    // 1) Asegurar jerarquía activa y Canvas habilitado
    var t = winnerCanvas.transform;
    while (t != null) { t.gameObject.SetActive(true); t = t.parent; } // activa padres
    var canvasComp = winnerCanvas.GetComponent<Canvas>();
    if (canvasComp) canvasComp.enabled = true;

    // 2) Subir orden para que quede por encima del HUD
    if (canvasComp)
    {
        canvasComp.overrideSorting = true;
        canvasComp.sortingOrder = 500; // bien alto
    }

    // 3) Si hay CanvasGroup (Modern UI Pack a veces lo trae), hacer visible/clicable
    var cg = winnerCanvas.GetComponentInChildren<CanvasGroup>(true);
    if (cg)
    {
        cg.alpha = 1f;
        cg.interactable = true;
        cg.blocksRaycasts = true;
    }

    // 4) Desactivar GameOver si estuviera encendido (por si lo tapa)
    var go = GameObject.Find("GameOverCanvas");
    if (go) go.SetActive(false);

    // 5) Actualizar textos
    if (winnerItemsText)
        winnerItemsText.text = $"Cristales: {itemsRecogidos} / {totalItems}";

    if (contador && winnerTimeText)
        winnerTimeText.text = "Tiempo: " + contador.GetTiempoTranscurrido().ToString("F2") + " s";

    // 6) Mostrar y pausar
    winnerCanvas.SetActive(true);
    if (contador) contador.PausarJuego(); else { Time.timeScale = 0f; }

    // 7) Asegurar cursor visible
    Cursor.lockState = CursorLockMode.None;
    Cursor.visible = true;

    Debug.Log("🏆 WinnerCanvas forzado a mostrarse (orden/alpha activados).");
}*/

    void MostrarWinner()
    {
        // Preparar textos
        if (winnerItemsText)
            winnerItemsText.text = "Cristales: " + itemsRecogidos + " / " + totalItems;

        if (contador && winnerTimeText)
            winnerTimeText.text = "Tiempo: " + contador.GetTiempoTranscurrido().ToString("F2") + " s";

        // Mostrar panel Winner y pausar juego
        if (winnerCanvas) winnerCanvas.SetActive(true);
        if (contador) contador.PausarJuego();

        Debug.Log("🏆 ¡Ganaste! Todos los ítems han sido recolectados.");
    }
}
