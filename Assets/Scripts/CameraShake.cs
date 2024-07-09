using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public float shakeThreshold = 50f;
    public float baseShakeIntensity = 0.1f;
    public float shakeIntensityStep = 0.05f;
    public float shakeDuration = 0.5f;

    private InsanityManager insanityManager;
    private Vector3 originalPosition;
    private Quaternion originalRotation;
    private Coroutine shakeCoroutine;

    void Start()
    {
        insanityManager = FindObjectOfType<InsanityManager>();
        if (insanityManager != null)
        {
            insanityManager.OnInsanityChanged += CheckShake;
        }
        else
        {
            Debug.LogError("InsanityManager not found!");
        }

        originalPosition = transform.localPosition;
        originalRotation = transform.localRotation;
    }

    void CheckShake(float insanityLevel)
    {
        if (insanityLevel >= shakeThreshold)
        {
            float intensity = baseShakeIntensity + (Mathf.Floor((insanityLevel - shakeThreshold) / 10f) * shakeIntensityStep);
            if (shakeCoroutine != null)
            {
                StopCoroutine(shakeCoroutine);
            }
            shakeCoroutine = StartCoroutine(Shake(intensity));
        }
    }

    IEnumerator Shake(float intensity)
    {
        float elapsed = 0f;

        while (elapsed < shakeDuration)
        {
            float z = Random.Range(-1f, 1f) * intensity;
            transform.localRotation = originalRotation * Quaternion.Euler(0, 0, z);

            elapsed += Time.deltaTime;
            yield return null;
        }

        transform.localRotation = originalRotation;
    }

    void OnDestroy()
    {
        if (insanityManager != null)
        {
            insanityManager.OnInsanityChanged -= CheckShake;
        }
    }
}
