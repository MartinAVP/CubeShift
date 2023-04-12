using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerChar : MonoBehaviour
{

    private Vector3 spawnPoint;
    public GameObject mainLevel;
    public int goldenKey;
    // Start is called before the first frame update
    void Start()
    {
        spawnPoint = gameObject.transform.position;
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
        //gameObject.transform.localScale = new Vector3(1, 1, 1);
        gameObject.transform.localScale *= 1f;

    }

    private void Respawn()
    {
        mainLevel.GetComponent<UIController>().Death();
        StartCoroutine("deathDelay");
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
