using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    public GameObject spawnEnemy;
    [SerializeField] private int tamañoEnemyList = 20;
    [SerializeField] private List<GameObject> enemyList;
    // Start is called before the first frame update


    private static GameManager instance;
    public static  GameManager Intance {get {return instance;}}

    private void Awake() {
            if ( instance == null )
            {
                instance = this;
            }
            else
            {
                Destroy(gameObject);
            }
    }
    void Start()
    {
        AñadirEnemigosSpawn(tamañoEnemyList);
    }
        private void AñadirEnemigosSpawn(int amount)
    {
        for(int i = 0; i < amount; i++)
        {
            GameObject enemy = Instantiate(enemyPrefab);
            enemy.SetActive(false);
            enemyList.Add(enemy);
            enemy.transform.parent = spawnEnemy.transform;
        }
       
    }

        public GameObject SpawnearEnemigos()
    {
        for(int i = 0; i < enemyList.Count; i++)
        {
            if(!enemyList[i].activeSelf)
            {
                enemyList[i].SetActive(true);
                return enemyList[i];
            }
        }
        AñadirEnemigosSpawn(1);
        enemyList[enemyList.Count - 1].SetActive(true);
        return enemyList[enemyList.Count - 1];
    }

}

