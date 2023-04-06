using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerChar : MonoBehaviour
{

    private Vector3 spawnPoint;
    // Start is called before the first frame update
    void Start()
    {
        spawnPoint = gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Respawn()
    {
        gameObject.transform.position = spawnPoint;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "enemy") 
        {
            Respawn();
        }
        else if (other.gameObject.tag == "key")
        {
            print("key");
        }
    }

}
