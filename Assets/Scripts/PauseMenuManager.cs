using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenuManager : MonoBehaviour
{
    public GameObject pauseMenuUI; // Referencia al Panel de pausa
    //public GameObject canvas;
    public Button pauseButton; // Referencia al botón de pausa

    private bool isPaused = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f; // Reanuda el juego
        isPaused = false;
    }

    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f; // Pausa el juego
        isPaused = true;
    }

    public void Restart()
    {
        Time.timeScale = 1f; // Reanuda el juego antes de reiniciar
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Reinicia la escena actual
    }

    public void Quit()
    {
        Time.timeScale = 1f; // Reanuda el juego antes de reiniciar
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Reinicia la escena actual
        Time.timeScale = 0f; // Pausa el juego
        gameObject.GetComponent<UIScreenManager>().newGamePanel.SetActive(true);
    }

    public void OnPauseButtonClicked()
    {
        Pause(); // Abre el menú de pausa cuando se hace clic en el botón de pausa
    }
}

