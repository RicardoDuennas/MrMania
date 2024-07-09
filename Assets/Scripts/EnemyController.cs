using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float moveSpeed = 3f;
    private Transform player;
    private Rigidbody enemyRb;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        enemyRb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        Vector3 direction = (player.position - transform.position).normalized;
        enemyRb.MovePosition(enemyRb.position + direction * moveSpeed * Time.fixedDeltaTime);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            InsanityManager insanityManager = FindObjectOfType<InsanityManager>();
            insanityManager.insanityLevel += 10f; // Incrementa la locura al tocar al jugador
        }
    }
}
