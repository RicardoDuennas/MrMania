using System.Collections;
using System.Collections.Generic;
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
    private int pillActive = 0;


    // Start is called before the first frame update
    void Start()
    {
        
        StartCoroutine(SpawnPill());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnPill(){
        Vector3 spawnLocation = new Vector3(Random.Range(minX, maxX), yPos, Random.Range(minZ, maxZ));
        Instantiate(pillPrefabs[pillActive], spawnLocation, pillPrefabs[pillActive].transform.rotation);
        isPillInScene = true;    
        Debug.Log("1");        
        while (isPillInScene){
            yield return null;
        }
        pillActive += 1;
        spawnLocation = new Vector3(Random.Range(minX, maxX), yPos, Random.Range(minZ, maxZ));
        Instantiate(pillPrefabs[pillActive], spawnLocation, pillPrefabs[pillActive].transform.rotation);
        isPillInScene = true;    
        Debug.Log("2");        
        while (isPillInScene){
            yield return null;
        }
        pillActive += 1;
        spawnLocation = new Vector3(Random.Range(minX, maxX), yPos, Random.Range(minZ, maxZ));
        Instantiate(pillPrefabs[pillActive], spawnLocation, pillPrefabs[pillActive].transform.rotation);
        isPillInScene = true;         
        Debug.Log("3");        
   
        while (isPillInScene){
            yield return null;
        }
        pillActive += 1;
        spawnLocation = new Vector3(Random.Range(minX, maxX), yPos, Random.Range(minZ, maxZ));
        Instantiate(pillPrefabs[pillActive], spawnLocation, pillPrefabs[pillActive].transform.rotation);
        isPillInScene = true;  
        Debug.Log("4");        
  
        while (isPillInScene){
            yield return null;
        }
        pillActive += 1;
        spawnLocation = new Vector3(Random.Range(minX, maxX), yPos, Random.Range(minZ, maxZ));
        Instantiate(pillPrefabs[pillActive], spawnLocation, pillPrefabs[pillActive].transform.rotation);
        isPillInScene = true;    
        Debug.Log("5");        

    }




}
