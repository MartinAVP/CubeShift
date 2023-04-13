using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        defaultScale = new Vector3(0.3f, .3f, .3f);
        spawnPoint = gameObject.transform.position;
        isDead = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator deathDelay()
    {
        yield return new WaitForSeconds(.8f);
        mainLevel.GetComponent<PlayerMovement>().Respawn();
        transform.position = spawnPoint;
        transform.rotation = Quaternion.Euler(0, 0, 0);
        isDead = false;
        if(bulletGrp != null)
        {
            foreach (Transform child in bulletGrp.transform)
            {
                GameObject.Destroy(child.gameObject);
            }
        }
        
        if(Enemies != null)
        {
            foreach (Transform child in Enemies.transform)
            {
                //GameObject.Destroy(child.gameObject);
                child.GetComponentInChildren<CubeEnemy>().respawnEnemy();
            }
        }
        //Enemies.GetComponentInChildren<CubeEnemy>().respawnEnemy(); // Resets Enemies
        transform.localScale = defaultScale;
        goldKey.gameObject.SetActive(true);
        goldGate.gameObject.SetActive(true);
        goldenKey = 0;

        if (Pills != null)
        {
            foreach (Transform child in Pills.transform)
            {
                //GameObject.Destroy(child.gameObject);
                child.gameObject.SetActive(true);
            }
        }

        //gameObject.transform.localScale = new Vector3(1, 1, 1);
        //gameObject.transform.localScale *= 1f;

    }

    private void Respawn()
    {
        if (isDead == false)
        {
            isDead = true;
            mainLevel.GetComponent<UIController>().Death();
            if(CannonGrp != null)
            {
                CannonGrp.GetComponentInChildren<Cannon>().dActivation();
            }
            /*
            foreach (GameObject child in CannonGrp.transform)
            {
                child.gameObject.GetComponent<Cannon>().dActivation();
            }
            */
            StartCoroutine("deathDelay");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Finish")
        {
            gameObject.GetComponent<Rigidbody>().isKinematic = true;
            print("You reached the finish line");
        }
        else if(other.gameObject.tag == "enemy") 
        {
            Respawn();
        }
        else if (other.gameObject.tag == "TeenyPill")
        {
            gameObject.transform.localScale = new Vector3(.1f,.1f,.1f);
            other.gameObject.SetActive(false);
        }
        else if(other.gameObject.tag == "goldGate") 
        {
            print("golden gate");
            if(goldenKey == 1) 
            {
                other.transform.parent.gameObject.SetActive(false);
                //other.gameObject.SetActive(false);
            }
            else
            {
                print("you don't have a key");
            }
        }
        else if (other.gameObject.tag == "goldKey")
        {
            goldenKey++;
            other.gameObject.SetActive(false);
            print("key");
        }
    }

}
