using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHability : MonoBehaviour
{
    public float waveForce = 10f;
    public float cooldownTime = 5f;
    private float nextWaveTime = 0f;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && Time.time > nextWaveTime)
        {
            GenerateWave();
            nextWaveTime = Time.time + cooldownTime;
        }
    }

    void GenerateWave()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, 5f);
        foreach (var hitCollider in hitColliders)
        {
            if (hitCollider.CompareTag("Enemy"))
            {
                Rigidbody rb = hitCollider.GetComponent<Rigidbody>();
                if (rb != null)
                {
                    Vector3 direction = hitCollider.transform.position - transform.position;
                    rb.AddForce(direction.normalized * waveForce, ForceMode.Impulse);
                }
            }
        }
    }
}
