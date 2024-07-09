using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Medicine : MonoBehaviour
{
    public GameObject Pildoras;
    Collider pillCollider;
    // Start is called before the first frame update
    void Start()
    {
        Pildoras = GameObject.Find("Pildoras");
        pillCollider = GetComponent<Collider>();
        pillCollider.isTrigger = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(this.gameObject);
            Pildoras.GetComponent<PildoraManager>().isPillInScene = false;
            Debug.Log("entra");
        }
    }

}