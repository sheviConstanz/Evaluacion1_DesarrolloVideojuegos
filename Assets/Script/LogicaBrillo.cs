using UnityEngine;
using UnityEngine.UI;

public class Brillo : MonoBehaviour
{
    [Header("Referencias")]
    public Slider slider;
    public Image panelBrillo;

    float sliderValue;

    void Start()
    {
        sliderValue = PlayerPrefs.GetFloat("brillo", 1f);
        slider.value = sliderValue;
        AplicarBrillo(sliderValue);
        slider.onValueChanged.AddListener(AplicarBrillo);
    }

    public void AplicarBrillo(float valor)
    {
        sliderValue = valor;
        PlayerPrefs.SetFloat("brillo", sliderValue);

        if (panelBrillo != null)
        {
            Color c = panelBrillo.color;
            c.a = 1f - sliderValue; // 1 → transparente, 0 → opaco
            panelBrillo.color = c;
        }
    }
}
