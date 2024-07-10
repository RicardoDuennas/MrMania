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

        Vector3 randomPos = Random.insideUnitSphere * 20f;
        randomPos.y = 1.25f;
        GameObject newEnemy = Instantiate(enemyPrefab, randomPos, Quaternion.identity);
        activeEnemies.Add(newEnemy);
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