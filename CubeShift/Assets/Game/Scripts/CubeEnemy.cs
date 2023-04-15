using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeEnemy : MonoBehaviour
{
    private Vector3 enemySpawn;
    void Start()
    {
        enemySpawn = transform.position; // Sets the starting position as the respawn position for the enemy
    }

    // Function of public access that will allow to reset the starting enemy position and rotation
    public void respawnEnemy()
    {
        transform.position = enemySpawn; // Sets the position of the enemy to its respawn position
        transform.rotation = Quaternion.Euler(0, 0, 0); // Resets the rotation of the enemy
    }
}
