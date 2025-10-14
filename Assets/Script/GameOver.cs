using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public void Reiniciar()
    {
        Time.timeScale = 1f;                          // ← resetear
        Cursor.lockState = CursorLockMode.Locked;     // ← volver a bloquear
        Cursor.visible = false;

        Scene current = SceneManager.GetActiveScene();
        SceneManager.LoadScene(current.buildIndex);
    }

    public void VolverMenu()
    {
        Time.timeScale = 1f;                          // ← resetear
        Cursor.lockState = CursorLockMode.None;       // en menú conviene libre
        Cursor.visible = true;

        SceneManager.LoadScene("MainMenu");
    }

    public void Salir()
    {
        Time.timeScale = 1f; // por si acaso
    #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
    #else
        Application.Quit();
    #endif
    }
} 