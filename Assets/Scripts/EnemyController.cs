using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{

    public Transform player;
    public float velocidad;

    public NavMeshAgent Ai;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").transform;
        Ai.speed = velocidad;
    }

    // Update is called once per frame
    void Update()
    {
        Ai.SetDestination(player.position);
    }

    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Bullet"))
        Destroy(gameObject);
    }
}
