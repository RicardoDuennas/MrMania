using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class UIScreenManager : MonoBehaviour
{
    public GameObject newGamePanel;
    public GameObject loreScreen;
    public GameObject tutorialScreen;
    public GameObject startScreen;
    public GameObject winnerScreen;
    public GameObject gameOverScreen;
    public GameManager gameManager;
    public TMP_Text enemiesKilled;

    private void Start()
    {
        if (GameState.isRestarting)
        {
            GameState.isRestarting = false; // Restablecer el estado
            Time.timeScale = 1f; // Asegúrate de que el juego esté corriendo
        }
        else
        {
            Time.timeScale = 0f; // Pausa el juego
            newGamePanel.SetActive(true);
        }
    }

    public void OnNewGameButtonPressed() 
    {
        newGamePanel.SetActive(false);
        loreScreen.SetActive(true);
    }

    public void OnNextButtonPressed()
    {
        loreScreen.SetActive(false);
        tutorialScreen.SetActive(true);
    }

    public void OnTutorialNextButtonPressed()
    {
        tutorialScreen.SetActive(false);
        startScreen.SetActive(true);
    }

    public void OnStartButtonPressed()
    {
        startScreen.SetActive(false);
        Time.timeScale = 1f; // Reanuda el juego
    }

    public void OnRestartButtonPressed()
    {
        gameOverScreen.SetActive(false);
        Time.timeScale = 1f; // Reanuda el juego antes de reiniciar
        GameState.isRestarting = true;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Reinicia la escena actual
    }
    private void Update()
    {
        enemiesKilled.text = "Enemies Killed: " + gameManager.enemiesKilled.ToString();
    }
}
