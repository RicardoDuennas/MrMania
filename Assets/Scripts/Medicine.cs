using System.Collections;
using System.Collections.Generic;
using TMPro.Examples;
using UnityEngine;

public class Medicine : MonoBehaviour
{
    public GameObject pildoras;
    public float insanityReductionAmount = 10f; // Valor por el cual se reducirá la locura
    public float immunityDuration = 10f; // Duración del power-up de inmunidad
    Collider pillCollider;
    private InsanityManager insanityManager;
    private GameManager gameManager;
    private GameObject[] pillArray;


    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        if (gameManager == null)
        {
            Debug.LogError("GameManager not found in the scene!");
        }

        pildoras = GameObject.Find("Pildoras");
        pillCollider = GetComponent<Collider>();
        pillCollider.isTrigger = true;
        pillArray = pildoras.GetComponent<PildoraManager>().pillPrefabs;

        insanityManager = FindObjectOfType<InsanityManager>();
        if (insanityManager == null)
        {
            Debug.LogError("InsanityManager not found in the scene!");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(this.gameObject);
            pildoras.GetComponent<PildoraManager>().isPillInScene = false;
            pildoras.GetComponent<PillCountdown>().StartCount(6);
            pildoras.GetComponent<PildoraManager>().pillsTaken += 1;

            if (insanityManager != null)
            {
                insanityManager.ReduceInsanity(insanityReductionAmount);
                insanityManager.SetImmunity(true, immunityDuration);
            }

            PlayerPowerUp powerUp = other.gameObject.GetComponent<PlayerPowerUp>();
            if (powerUp != null)
            {
                powerUp.ActivatePowerUp(immunityDuration);
            }
        }
    }
}
