using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class CannonBullet : MonoBehaviour
{
    public GameObject cannon;
    public GameObject bulletGrp;
    private GameObject player;

    void Start()
    {
        StartCoroutine(lifetime()); // starts a timer for the lifetime
        cannon = GameObject.FindGameObjectWithTag("Cannon"); // Finds the GameObject in which all its childs are Cannons in the Level
        bulletGrp = GameObject.Find("Bullets"); // Finds the GameObject in which all childs are Cannon Bullets in the level
        transform.parent = bulletGrp.transform; // Assigns the bullet to be a child of the Bullet Group

        player = GameObject.FindGameObjectWithTag("Player"); // Finds the player in the level
        gameObject.transform.GetComponent<Rigidbody>().AddForce((player.transform.position - transform.position) * 50f); // Adds a force towards the player
    }

    // Function that works as a timer lifetime for the bullet
    private IEnumerator lifetime()
    {
        yield return new WaitForSeconds(5f);
        Destroy(this.gameObject);
    }
}
