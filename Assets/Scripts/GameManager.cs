using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool isGameOver = false;

    public void GameOver()
    {
        isGameOver = true;
        Debug.Log("Game Over");
        // Todo lo relacionado al game over
        Time.timeScale = 0; // Detiene el juego
    }
}
