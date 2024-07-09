using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PillCountdown : MonoBehaviour
{
    public GameObject Pildoras;
    public float timeRemaining = 6;
    public bool timerIsRunning = false;
    

    private void Start()
    {
        Pildoras = GameObject.Find("Pildoras");

    }

    void Update()
    {
        
        float seconds = Mathf.FloorToInt(timeRemaining % 60);
        
        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
            }
            else
            {
                timeRemaining = 0;
                timerIsRunning = false;
                gameObject.GetComponent<PildoraManager>().isPillInScene = false;
                gameObject.GetComponent<PildoraManager>().CoroutineCall();
                //GetComponent<...>().EndBoost();
            }
        }
    }

    public void StartCount(int time){
        timeRemaining = time;
        timerIsRunning = true;
    }
}