using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public int initialEnemies = 1;
    public int enemiesPerInsanityStep = 2;
    private List<GameObject> activeEnemies = new List<GameObject>();
    private InsanityManager insanityManager;
    private GameManager gameManager;
    
    // Variables para definir el rango de aparición
    public float minSpawnDistance = 20f;
    public float maxSpawnDistance = 30f;

    void Start()
    {
        insanityManager = FindObjectOfType<InsanityManager>();
        gameManager = FindObjectOfType<GameManager>();

        if (insanityManager != null)
        {
            insanityManager.OnInsanityChanged += UpdateEnemyCount;
        }
        else
        {
            Debug.LogError("InsanityManager not found in the scene!");
        }

        if (gameManager == null)
        {
            Debug.LogError("GameManager not found in the scene!");
        }

        EnemyController.OnEnemyDestroyed += HandleEnemyDestroyed;

        for (int i = 0; i < initialEnemies; i++)
        {
            SpawnEnemy();
        }
    }

    void UpdateEnemyCount(float insanityLevel)
    {
        if (gameManager == null || gameManager.isGameOver) return;

        int insanityStep = Mathf.FloorToInt(insanityLevel / 10f);
        int targetEnemyCount = initialEnemies + (insanityStep * enemiesPerInsanityStep);

        targetEnemyCount = Mathf.Min(targetEnemyCount, initialEnemies + (9 * enemiesPerInsanityStep));

        while (activeEnemies.Count < targetEnemyCount)
        {
            SpawnEnemy();
        }
    }

    void SpawnEnemy()
    {
        if (enemyPrefab == null)
        {
            Debug.LogError("Enemy prefab is not assigned!");
            return;
        }

        Vector3 randomPos = GetRandomSpawnPosition();
        GameObject newEnemy = Instantiate(enemyPrefab, randomPos, Quaternion.identity);
        activeEnemies.Add(newEnemy);
    }

    Vector3 GetRandomSpawnPosition()
    {
        Vector3 playerPosition = GameObject.FindGameObjectWithTag("Player").transform.position;
        Vector3 randomDirection = Random.insideUnitSphere;
        randomDirection.y = 0; // Para mantener a los enemigos en el mismo nivel en el eje Y

        float distance = Random.Range(minSpawnDistance, maxSpawnDistance);
        Vector3 spawnPosition = playerPosition + randomDirection.normalized * distance;

        return new Vector3(spawnPosition.x, 1.25f, spawnPosition.z);
    }

    void HandleEnemyDestroyed(EnemyController enemy)
    {
        activeEnemies.Remove(enemy.gameObject);
        UpdateEnemyCount(insanityManager.insanityLevel);
    }

    void OnDestroy()
    {
        if (insanityManager != null)
        {
            insanityManager.OnInsanityChanged -= UpdateEnemyCount;
        }

        EnemyController.OnEnemyDestroyed -= HandleEnemyDestroyed;
    }
}
