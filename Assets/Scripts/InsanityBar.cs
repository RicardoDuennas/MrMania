using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InsanityBar : MonoBehaviour
{
    public Image insanityBarFill;
    public TextMeshProUGUI insanityPercent;
    private InsanityManager insanityManager;

    void Start()
    {
        insanityManager = FindObjectOfType<InsanityManager>();
        if (insanityManager != null)
        {
            insanityManager.OnInsanityChanged += UpdateInsanityBar;
        }
    }

    void UpdateInsanityBar(float insanityLevel)
    {
        if (insanityBarFill != null)
        {
            insanityBarFill.fillAmount = insanityLevel / insanityManager.maxInsanity;
        }
        
        if (insanityPercent != null)
        {
            insanityPercent.text = $"Locura: {Mathf.RoundToInt(insanityLevel)}%";
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