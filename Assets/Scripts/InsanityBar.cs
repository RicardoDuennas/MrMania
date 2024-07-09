using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InsanityBar : MonoBehaviour
{
    public GameObject insanityBarFill;
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

    void OnDestroy()
    {
        if (insanityManager != null)
        {
            insanityManager.OnInsanityChanged -= UpdateInsanityBar;
        }
    }
}