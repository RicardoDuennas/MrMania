using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource voicesAudioSource;
    public float minInsanityForSound = 30f;
    public float maxVolume = 1f;

    private InsanityManager insanityManager;

    void Start()
    {
        insanityManager = FindObjectOfType<InsanityManager>();
        if (insanityManager != null)
        {
            insanityManager.OnInsanityChanged += UpdateVoicesVolume;
        }
        else
        {
            Debug.LogError("InsanityManager not found!");
        }

        if (voicesAudioSource != null)
        {
            voicesAudioSource.volume = 0;
            voicesAudioSource.loop = true;
            voicesAudioSource.Play();
        }
        else
        {
            Debug.LogError("AudioSource for voices not assigned!");
        }
    }

    void UpdateVoicesVolume(float insanityLevel)
    {
        if (voicesAudioSource != null)
        {
            if (insanityLevel >= minInsanityForSound)
            {
                float normalizedInsanity = (insanityLevel - minInsanityForSound) / (insanityManager.maxInsanity - minInsanityForSound);
                voicesAudioSource.volume = Mathf.Clamp01(normalizedInsanity) * maxVolume;
            }
            else
            {
                voicesAudioSource.volume = 0;
            }
        }
    }

    void OnDestroy()
    {
        if (insanityManager != null)
        {
            insanityManager.OnInsanityChanged -= UpdateVoicesVolume;
        }
    }
}
