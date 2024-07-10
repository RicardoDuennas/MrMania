using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PildoraManager : MonoBehaviour
{
    public GameObject[] pillPrefabs;
    public int minX = 0;
    public int maxX = 0;
    public int minZ = 0;
    public int maxZ = 0;
    public int yPos = 0;
    public bool isPillInScene;
    public int pillActive = 0;
    public int pillsTaken = 0;
    private GameManager gameManager;



    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        if (gameManager == null)
        {
            Debug.LogError("GameManager not found in the scene!");
        }

        CoroutineCall();


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CoroutineCall (){
        StartCoroutine(SpawnPill());        
    }
    public IEnumerator SpawnPill(){
        yield return new WaitForSeconds(Random.Range(8, 14));

        if (pillActive < pillPrefabs.Count()){
            Vector3 spawnLocation = new Vector3(Random.Range(minX, maxX), yPos, Random.Range(minZ, maxZ));
            Instantiate(pillPrefabs[pillActive], spawnLocation, pillPrefabs[pillActive].transform.rotation);
            isPillInScene = true;  
            pillActive += 1;
        }
    }
}
