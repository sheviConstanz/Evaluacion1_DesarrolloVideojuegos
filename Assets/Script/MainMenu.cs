using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [Header("Paneles")]
    public GameObject mainMenu;       // Menú principal
    public GameObject optionsMenu;    // Opciones generales
    public GameObject optionsSound;   // Opciones de sonido
    public GameObject optionsScreen;  // ✅ Opciones de pantalla (nuevo)

    void Awake()
    {
        // Al iniciar, muestra el menú principal
        ShowOnly(mainMenu);
    }

    // Muestra SOLO el panel indicado y oculta los demás
    void ShowOnly(GameObject panelToShow)
    {
        if (mainMenu)      mainMenu.SetActive(panelToShow == mainMenu);
        if (optionsMenu)   optionsMenu.SetActive(panelToShow == optionsMenu);
        if (optionsSound)  optionsSound.SetActive(panelToShow == optionsSound);
        if (optionsScreen) optionsScreen.SetActive(panelToShow == optionsScreen);
    }

    // --- Navegación ---
    public void ShowMainMenu()      => ShowOnly(mainMenu);
    public void ShowOptionsMenu()   => ShowOnly(optionsMenu);
    public void ShowOptionsSound()  => ShowOnly(optionsSound);
    public void ShowOptionsScreen() => ShowOnly(optionsScreen); // ✅ nuevo

    // --- Flujo de juego ---
    public void StartGame()
    {
        SceneManager.LoadScene("Level1");
    }

    public void VolverMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void QuitGame()
    {
    #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false; // Detiene el juego en el editor
    #endif
        Application.Quit();
        // Debug.Log("Saliendo del juego...");
    }
}
