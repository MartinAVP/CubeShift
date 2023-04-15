using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Cannon : MonoBehaviour
{
    public GameObject player;
    public GameObject bullet_prefab;
    private bool spawnDelay;

    void Start()
    {
        spawnDelay = false; // no spawn delay
        InvokeRepeating("shoot", 0f, 2f); //Invoke the shoot function every 2 seconds
    }

    void Update()
    {
        // Makes the cannon look at the player at all times.
        transform.LookAt(player.transform.position);
    }

    // Function of public access to start a timer on when the cannon starts shooting
    public void dActivation()
    {
        StartCoroutine(delayActivation());
    }

    // Timer for the cannon to start shooting after starting
    public IEnumerator delayActivation()
    {
        spawnDelay = true;
        yield return new WaitForSeconds(2f);
        spawnDelay = false;
    }

    //Will spawn a bullet prefab at the position and rotation of the cannon
    private void shoot()
    {
        if (spawnDelay == false)
        {
            Instantiate(bullet_prefab, GetComponent<Transform>().position,
                GetComponent<Transform>().rotation); // Attached to pos and rot
        }
    }
}
