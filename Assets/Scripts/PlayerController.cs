using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Rigidbody rb;

    public float waveForce = 10f;
    public float waveCooldown = 5f;
    private float lastWaveTime;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && Time.time - lastWaveTime > waveCooldown)
        {
            GenerateWave();
        }
    }

    void GenerateWave()
    {
        lastWaveTime = Time.time;
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, 15f);
        foreach (var hitCollider in hitColliders)
        {
            if (hitCollider.CompareTag("Enemy"))
            {
                Rigidbody enemyRb = hitCollider.GetComponent<Rigidbody>();
                if (enemyRb != null)
                {
                    Vector3 direction = (hitCollider.transform.position - transform.position).normalized;
                    enemyRb.AddForce(direction * waveForce, ForceMode.Impulse);
                }
            }
        }
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0f, moveVertical);
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}
