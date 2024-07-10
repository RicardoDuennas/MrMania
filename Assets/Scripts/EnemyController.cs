using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;


public class EnemyController : MonoBehaviour
{
    public static event Action<EnemyController> OnEnemyDestroyed;
    public float moveSpeed = 3f;
    private Transform player;
    private Rigidbody enemyRb;
    public GameObject sounds;
    AudioSource audioSource;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        enemyRb = GetComponent<Rigidbody>();
        sounds = GameObject.Find("Sounds");
        audioSource = sounds.GetComponent<AudioSource>(); 
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
                int i = Random.Range(0, sounds.GetComponent<SoundPlayer>().painSounds.Length);
                audioSource.PlayOneShot(sounds.GetComponent<SoundPlayer>().painSounds[i], 0.7f);
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
                int i = Random.Range(0, sounds.GetComponent<SoundPlayer>().killSounds.Length);
                audioSource.PlayOneShot(sounds.GetComponent<SoundPlayer>().killSounds[i], 0.7f);
            }
        }
    }

    public void DestroyEnemy()
    {
        OnEnemyDestroyed?.Invoke(this);
        Destroy(gameObject);
    }
}
