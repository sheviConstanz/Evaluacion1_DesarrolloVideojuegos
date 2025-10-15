/*using UnityEngine;
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
    }

    void ActualizarUI()
    {
        if (textoContador)
            textoContador.text = "Cristales: " + itemsRecogidos + " / " + totalItems;
    }

   public int Total => totalItems;
 public int Recogidos => itemsRecogidos;
    
}
*/

using UnityEngine;
using TMPro;

public class ContadorItems : MonoBehaviour
{
    [Header("UI HUD")]
    public TMP_Text textoContador;  // Texto TMP del HUD ("Cristales: X / Y")

    [Header("Configuración")]
    public int totalItems = 5;
    public float segundosPorItem = 5f;

    [Header("Referencias")]
    public Contador contador;  // Arrastra el objeto con el script Contador

    int itemsRecogidos = 0;

    void Awake()
    {
        if (!contador) contador = FindFirstObjectByType<Contador>();
        ActualizarUI();
    }

    public void SumarItem()
    {
        itemsRecogidos++;
        ActualizarUI();

        // +5s por ítem
        if (contador) contador.AgregarTiempo(segundosPorItem);
    }

    void ActualizarUI()
    {
        if (textoContador)
            textoContador.text = "Cervezas: " + itemsRecogidos;
    }

    // 🔹 Para leer desde la meta:
    public int Recogidos => itemsRecogidos;
    public int Total => totalItems;
}
