using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public static event Action<EnemyController> OnEnemyDestroyed;
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
        if (player != null)
        {
            Vector3 direction = (player.position - transform.position).normalized;
            enemyRb.velocity = direction * moveSpeed;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            InsanityManager insanityManager = FindObjectOfType<InsanityManager>();
            if (insanityManager != null && !insanityManager.isImmune)
            {
                insanityManager.IncreaseInsanity(10f);
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            PlayerPowerUp powerUp = other.gameObject.GetComponent<PlayerPowerUp>();
            if (powerUp != null && powerUp.IsImmune)
            {
                DestroyEnemy();
            }
        }
    }

    public void DestroyEnemy()
    {
        OnEnemyDestroyed?.Invoke(this);
        Destroy(gameObject);
    }
}
