using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Medicine : MonoBehaviour
{
    public GameObject Pildoras;
    public float insanityReductionAmount = 10f; // Valor por el cual se reducirá la locura
    public float immunityDuration = 10f; // Duración del power-up de inmunidad
    Collider pillCollider;
    private InsanityManager insanityManager;

    // Start is called before the first frame update
    void Start()
    {
        Pildoras = GameObject.Find("Pildoras");
        pillCollider = GetComponent<Collider>();
        pillCollider.isTrigger = true;

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
            Pildoras.GetComponent<PildoraManager>().isPillInScene = false;
            Pildoras.GetComponent<PillCountdown>().StartCount(6);
            Pildoras.GetComponent<PildoraManager>().pillsTaken += 1;

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
