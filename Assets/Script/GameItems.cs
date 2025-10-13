using UnityEngine;
using TMPro;

public class ContadorItems : MonoBehaviour
{
    public TMP_Text textoContador; // arrastra aquí tu texto TMP
    public int totalItems = 5;     // cuántos hay en total
    private int itemsRecogidos = 0;

    public void SumarItem()
    {
        itemsRecogidos++;
        textoContador.text = "Cristales: " + itemsRecogidos + " / " + totalItems;
    }
}
