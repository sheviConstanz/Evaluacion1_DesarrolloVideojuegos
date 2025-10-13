using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject optionsMenu;
    public GameObject mainMenu;
    public GameObject optionsSound;

    public void ShowMainMenu()
    {
        mainMenu.SetActive(true);
        optionsMenu.SetActive(false);
    }

    public void ShowOptionsMenu()
    {
        mainMenu.SetActive(false);
        optionsMenu.SetActive(true);
    }

    public void QuitGame()
    {
    
        UnityEditor.EditorApplication.isPlaying = false; // Detiene el juego en el editor
        Application.Quit();
    
        //Application.Quit();
        //Debug.Log("Saliendo del juego...");
    }
    public void VolverMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Level1");
    }
    
}
