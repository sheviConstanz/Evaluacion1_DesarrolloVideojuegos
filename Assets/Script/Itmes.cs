/*using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] ContadorItems contador; // arrástralo desde la escena

    void Awake()
    {
        // Por si te olvidas de asignarlo, intenta buscarlo 1 vez.
        if (!contador) contador = FindObjectOfType<ContadorItems>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        if (contador) contador.SumarItem();
        else Debug.LogError("No se encontró ContadorItems en la escena.");

        Destroy(gameObject);
    }
}
*/