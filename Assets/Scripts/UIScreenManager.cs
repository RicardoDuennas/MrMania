using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIScreenManager : MonoBehaviour
{
    public GameObject newGamePanel;
    public GameObject loreScreen;
    public GameObject tutorialScreen;
    public GameObject startScreen;
    public GameObject winnerScreen;
    public GameObject gameOverScreen;

    public bool isRestarting = false;

    private void Start()
    {/*
        if (isRestarting == true)
        {
            Debug.Log("No hago nada porque estoy reiniciando");
        }
        else if (isRestarting == false)
        {
            Debug.Log("Entre porque quitie");
            Time.timeScale = 0f; // Pausa el juego
            newGamePanel.SetActive(true);
        }
        */
        Time.timeScale = 0f; // Pausa el juego
        newGamePanel.SetActive(true);

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
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Reinicia la escena actual
    }
}
