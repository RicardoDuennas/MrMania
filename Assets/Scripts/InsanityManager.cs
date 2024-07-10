using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InsanityManager : MonoBehaviour
{
    public float insanityLevel = 0f;
    public float maxInsanity = 100f;
    public float insanityIncreaseRate = 1f;
    public event System.Action<float> OnInsanityChanged;
    public bool isImmune = false;
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
        if (gameManager != null && !gameManager.isGameOver && !isImmune)
        {
            IncreaseInsanity(insanityIncreaseRate * Time.deltaTime);
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

    public void IncreaseInsanity(float amount)
    {
        if (gameManager != null && gameManager.isGameOver) return;

        if (isImmune) return; // Añade esta línea para asegurar que no se incremente la locura cuando el jugador está inmune.

        float oldInsanity = insanityLevel;
        insanityLevel += amount;
        insanityLevel = Mathf.Clamp(insanityLevel, 0f, maxInsanity);

        if (insanityLevel != oldInsanity)
        {
            OnInsanityChanged?.Invoke(insanityLevel);
        }

        if (insanityLevel >= maxInsanity)
        {
            insanityLevel = maxInsanity;
            gameManager.GameOver();
        }
    }

    public void SetImmunity(bool immunity, float duration)
    {
        StartCoroutine(ImmunityCoroutine(immunity, duration));
    }

    private IEnumerator ImmunityCoroutine(bool immunity, float duration)
    {
        isImmune = immunity;
        yield return new WaitForSeconds(duration);
        isImmune = false;
    }
}
