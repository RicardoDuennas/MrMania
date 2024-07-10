using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPowerUp : MonoBehaviour
{
    private bool isImmune = false;
    private InsanityManager insanityManager;

    public bool IsImmune => isImmune;
    public GameObject sounds;
    AudioSource audioSource;
    public AudioClip powerup;


    void Start()
    {
        insanityManager = FindObjectOfType<InsanityManager>();
        sounds = GameObject.Find("Sounds");
        audioSource = sounds.GetComponent<AudioSource>(); 

    }

    void OnTriggerEnter(Collider other)
    {
        if (isImmune && other.gameObject.CompareTag("Enemy"))
        {
            Destroy(other.gameObject);
            if (insanityManager != null)
            {
                insanityManager.ReduceInsanity(1f);
            }
        }
    }

    public void ActivatePowerUp(float duration)
    {
        StartCoroutine(PowerUpCoroutine(duration));
    }

    private IEnumerator PowerUpCoroutine(float duration)
    {
        isImmune = true;
        if (insanityManager != null)
        {
            insanityManager.SetImmunity(true, duration); // Asegúrate de que el InsanityManager también sepa que el jugador está inmune.
            audioSource.PlayOneShot(powerup, 0.7f);
        }
        yield return new WaitForSeconds(duration);
        isImmune = false;
        if (insanityManager != null)
        {
            insanityManager.SetImmunity(false, 0f); // Restablece el estado de inmunidad.
        }
    }
}
