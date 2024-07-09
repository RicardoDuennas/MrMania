using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire2"))
        {
        GameObject enemy = GameManager.Intance.SpawnearEnemigos();
        enemy.transform.position = GameManager.Intance.spawnEnemy.transform.position;
        }
    }
}
