using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InsanityManager : MonoBehaviour
{
    public float insanityLevel = 0f;
    public float maxInsanity = 100f;
    public float insanityIncreaseRate = 1f;
    public System.Action<float> OnInsanityChanged;

    void Update()
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
            FindObjectOfType<GameManager>().GameOver();
        }
    }

    public void ReduceInsanity(float amount)
    {
        insanityLevel -= amount;
        insanityLevel = Mathf.Max(insanityLevel, 0f);
        OnInsanityChanged?.Invoke(insanityLevel);
    }
}
