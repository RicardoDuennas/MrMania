using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIScreenManager : MonoBehaviour
{
    public GameObject NewGamePanel;
    public GameObject LoreScreen;
    public GameObject TutorialScreen;
    public GameObject StartScreen;
    public GameObject WinnerScreen;
    public GameObject GameOverScreen;

    private void Start()
    {
        Time.timeScale = 0f; // Pausa el juego
        NewGamePanel.SetActive(true);
    }

    public void OnNewGameButtonPressed() 
    {
        NewGamePanel.SetActive(false);
        LoreScreen.SetActive(true);
    }

    public void OnNextButtonPressed()
    {
        LoreScreen.SetActive(false);
        TutorialScreen.SetActive(true);
    }

    public void OnTutorialNextButtonPressed()
    {
        TutorialScreen.SetActive(false);
        StartScreen.SetActive(true);
    }

    public void OnStartButtonPressed()
    {
        StartScreen.SetActive(false);
        Time.timeScale = 1f; // Reanuda el juego
    }
}
