using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float waveForce = 10f;
    public float waveCooldown = 5f;
    private float lastWaveTime;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true; // Evita que el Rigidbody gire
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && Time.time - lastWaveTime > waveCooldown)
        {
            GenerateWave();
        }
    }

    void FixedUpdate()
    {
        // Obtiene la entrada del jugador
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        // Calcula la dirección del movimiento
        Vector3 movement = new Vector3(moveHorizontal, 0f, moveVertical).normalized;
        Vector3 velocity = movement * moveSpeed;

        // Aplica la velocidad al Rigidbody
        rb.velocity = new Vector3(velocity.x, rb.velocity.y, velocity.z);
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
}