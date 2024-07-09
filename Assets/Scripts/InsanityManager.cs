using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InsanityManager : MonoBehaviour
{
    public float insanityLevel = 0f;
    public float maxInsanity = 100f;
    public float insanityIncreaseRate = 1f;
    public event System.Action<float> OnInsanityChanged;

    private GameManager gameManager;

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        if (gameManager == null)
        {
            Debug.LogError("GameManager not found in the scene!");
        }
    }

    void Update()
    {
        if (gameManager != null && !gameManager.isGameOver)
        {
            float oldInsanity = insanityLevel;
            insanityLevel += insanityIncreaseRate * Time.deltaTime;
            insanityLevel = Mathf.Clamp(insanityLevel, 0f, maxInsanity);

            if (insanityLevel != oldInsanity)
            {
                OnInsanityChanged?.Invoke(insanityLevel);
            }

            if (insanityLevel >= maxInsanity)
            {
                gameManager.GameOver();
            }
        }
    }

    public void ReduceInsanity(float amount)
    {
        float oldInsanity = insanityLevel;
        insanityLevel -= amount;
        insanityLevel = Mathf.Max(insanityLevel, 0f);
        
        if (insanityLevel != oldInsanity)
        {
            OnInsanityChanged?.Invoke(insanityLevel);
        }
    }
}
