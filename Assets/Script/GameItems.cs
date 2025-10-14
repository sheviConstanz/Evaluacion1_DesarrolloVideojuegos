using UnityEngine;
using TMPro;

public class ContadorItems : MonoBehaviour
{
    [Header("UI")]
    public TMP_Text textoContador; // arrastra tu Text (TMP)

    [Header("Conteo")]
    public int totalItems = 5;
    public float segundosPorItem = 5f; //cada ítem suma X segundos al contador

    int itemsRecogidos = 0;

    [Header("Referencias")]
    public Contador contador; 

    void Awake()
    {
    if (!contador) contador = FindFirstObjectByType<Contador>();
    ActualizarUI();
    }

    // Llama este método cuando el jugador recoja un ítem
    public void SumarItem()
    {
        itemsRecogidos++;
        ActualizarUI();

        if (contador) contador.AgregarTiempo(segundosPorItem);
        else Debug.LogWarning("No se encontró 'Contador' en la escena.");
    }

    void ActualizarUI()
    {
        if (textoContador)
            textoContador.text = "Cristales: " + itemsRecogidos + " / " + totalItems;
    }
}
