using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeEnemy : MonoBehaviour
{
    private Vector3 enemySpawn;
    // Start is called before the first frame update
    void Start()
    {
        enemySpawn = transform.position;
    }

    public void respawnEnemy()
    {
        transform.position = enemySpawn;
        transform.rotation = Quaternion.Euler(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
