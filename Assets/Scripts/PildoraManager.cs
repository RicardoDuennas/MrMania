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
    public int secondsToWait = 2;
    public bool isPillInScene;
    public int pillActive = 0;
    public int pillsTaken = 0;


    // Start is called before the first frame update
    void Start()
    {
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
        yield return new WaitForSeconds(2);

        if (pillActive < pillPrefabs.Count()){
            Vector3 spawnLocation = new Vector3(Random.Range(minX, maxX), yPos, Random.Range(minZ, maxZ));
            Instantiate(pillPrefabs[pillActive], spawnLocation, pillPrefabs[pillActive].transform.rotation);
            isPillInScene = true;  
            pillActive += 1;
        }

//        Debug.Log(!gameObject.GetComponent<PillCountdown>().timerIsRunning);

    }
}
