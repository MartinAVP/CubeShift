using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class PlayerChar : MonoBehaviour
{

    private Vector3 spawnPoint;
    public GameObject mainLevel;
    public GameObject bulletGrp;
    public GameObject CannonGrp;
    public GameObject Enemies;
    public GameObject Pills;

    public int goldenKey;
    private bool isDead;

    public GameObject goldKey;
    public GameObject goldGate;

    private Vector3 defaultScale;
    // Start is called before the first frame update
    void Start()
    {
        defaultScale = new Vector3(0.3f, .3f, .3f); // Sets the default scale of the cube
        spawnPoint = gameObject.transform.position; // sets the spawnpoint of the player Cube
        isDead = false;                             // check if the player is already in a dead state
                                                    // Prevents the UI checking two times
    }

    // Delay of death
    private IEnumerator deathDelay()
    {
        //Waits .8 seconds for when the player dies
        yield return new WaitForSeconds(.8f);
        mainLevel.GetComponent<PlayerMovement>().Respawn(); // Calls the Respawn Function in the Main Level
        transform.position = spawnPoint;                    // Brings the player to the spawn position
        transform.rotation = Quaternion.Euler(0, 0, 0);     // Makes the rotation of the player to default
        transform.localScale = defaultScale;                // Will Reset the scale of the player
        isDead = false;                                     // Disables the death state
        // Spawned Bullets
        if(bulletGrp != null)                               // Checks if the Bullet group is not defined
        {
            foreach (Transform child in bulletGrp.transform)// Will select each child in the BulletGrp
            {
                GameObject.Destroy(child.gameObject);       // Destroys the GameObject
            }
        }
        // Enemies
        if(Enemies != null)                                 // Checks if the Enemies group is not defiend
        {
            foreach (Transform child in Enemies.transform)  // Will select each child in the Enemis group
            {
                //GameObject.Destroy(child.gameObject);
                child.GetComponentInChildren<CubeEnemy>().respawnEnemy(); // Will Respawn the Enemie is defined
            }
        }
        // Doors & Keys
        goldKey.gameObject.SetActive(true);                 // Will enable the Gold Key
        goldGate.gameObject.SetActive(true);                // Will enable the Gold Gate
        goldenKey = 0;
        // Pills
        if (Pills != null)                                  // Checks if the Pills group is not defined
        {
            foreach (Transform child in Pills.transform)    // Will select each child in the Pills group
            {
                //GameObject.Destroy(child.gameObject);
                child.gameObject.SetActive(true);           // Will enable each child in the GameObject
            }
        }

    }

    // Function that will respawn the player
    private void Respawn()
    {
        if (isDead == false)                                // Check if the player dead state
        {
            isDead = true;                                  // Will enable the death state for the player
            mainLevel.GetComponent<UIController>().Death(); // Calls the UI death state

            // Cannon Group
            if(CannonGrp != null)                           // Check if the Cannon Group is defined
            {
                CannonGrp.GetComponentInChildren<Cannon>().dActivation();   // Calls the Function for Disable the cannon temporarily
            }
            StartCoroutine("deathDelay"); // Calls the death function
        }
    }

    // Function will Check if the player collides with another object
    private void OnTriggerEnter(Collider other)
    {
        // Check for Finish Line
        if (other.gameObject.tag == "Finish")
        {
            gameObject.GetComponent<Rigidbody>().isKinematic = true;    // Makes the player freeze in time
        }
        // Check for Enemy Collision
        else if(other.gameObject.tag == "enemy") 
        {
            Respawn();                                                  // Will call the Respawn Function
        }
        // Checks for Re-Sizing Pill
        else if (other.gameObject.tag == "TeenyPill")
        {
            gameObject.transform.localScale = new Vector3(.1f,.1f,.1f); // Will set the scale of the player to .1
            other.gameObject.SetActive(false);                          // 
        }
        // Check if Player Collides with the Gold Gate
        else if(other.gameObject.tag == "goldGate") 
        {
            if(goldenKey == 1) // Checks if the Player has the key
            {
                other.transform.parent.gameObject.SetActive(false);     // Disables the gold gate
            }
        }
        // Check if the Player Collides with the Gold Key
        else if (other.gameObject.tag == "goldKey")
        {
            goldenKey++;                                                // Adds a Golden Key Variable
            other.gameObject.SetActive(false);                          // disables the Key GameObject
        }
    }
}
