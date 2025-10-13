using UnityEngine;
using UnityEngine.UI;

public class BrilloPantalla : MonoBehaviour
{
    [SerializeField] Image panelBrillo;  // arrastra el panel negro
    [SerializeField] Slider sliderBrillo; // arrastra el slider

    void Start()
    {
        // Cargar valor guardado o usar 1 (máximo brillo)
        float valorGuardado = PlayerPrefs.GetFloat("Brillo", 1f);
        if (sliderBrillo) sliderBrillo.value = valorGuardado;
        AplicarBrillo(valorGuardado);

        // Escuchar cambios del slider
        if (sliderBrillo)
            sliderBrillo.onValueChanged.AddListener(AplicarBrillo);
    }

    void AplicarBrillo(float valor)
    {
        if (!panelBrillo) return;

        // Cuanto menor el valor, más oscuro (aumenta el alpha del panel)
        Color color = panelBrillo.color;
        color.a = 1f - Mathf.Clamp01(valor);
        panelBrillo.color = color;

        // Guardar preferencia
        PlayerPrefs.SetFloat("Brillo", valor);
    }
}