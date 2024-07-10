using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InsanityBar : MonoBehaviour
{
    public GameObject insanityBarFill;
    public GameObject pillBarFill;
    public GameObject powerUpUI;
    public TextMeshProUGUI insanityPercent;
    public TextMeshProUGUI pillTaken;
    private InsanityManager insanityManager;
    private PillCountdown pillCountDown;
    private PildoraManager pildoraManager;
    private PlayerPowerUp playerPowerUp;

    void Start()
    {
        insanityManager = FindObjectOfType<InsanityManager>();
        if (insanityManager != null)
        {
            insanityManager.OnInsanityChanged += UpdateInsanityBar;
        }

        pillCountDown = FindObjectOfType<PillCountdown>();
        pildoraManager = FindObjectOfType<PildoraManager>();
        playerPowerUp = FindObjectOfType<PlayerPowerUp>();
    }

    void UpdateInsanityBar(float insanityLevel)
    {
        if (insanityBarFill != null)
        {
            float scaleValue = insanityLevel / insanityManager.maxInsanity;
            RectTransform rectTransform = insanityBarFill.GetComponent<RectTransform>();
            Vector3 newScale = rectTransform.localScale;
            newScale.x = scaleValue;
            rectTransform.localScale = newScale;
        }
        
        if (insanityPercent != null)
        {
            insanityPercent.text = $"Locura: {Mathf.RoundToInt(insanityLevel)}%";
        }
    }

    private void Update()
    {
        pillTaken.text = pildoraManager.pillsTaken.ToString();

        if (pillBarFill != null)
        {
            float scaleValue = (pildoraManager.pillsTaken / 10f)/0.7f;
            RectTransform rectTransform = pillBarFill.GetComponent<RectTransform>();
            Vector3 newScale = rectTransform.localScale;
            newScale.y = scaleValue;
            rectTransform.localScale = newScale;
        }

        if (playerPowerUp.isImmune)
        {
            powerUpUI.SetActive(true);
        }
        else 
        {
            powerUpUI.SetActive(false);
        }
    }

    void OnDestroy()
    {
        if (insanityManager != null)
        {
            insanityManager.OnInsanityChanged -= UpdateInsanityBar;
        }
    }
}