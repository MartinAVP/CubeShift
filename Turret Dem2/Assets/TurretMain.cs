using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretMain : MonoBehaviour
{
    public GameObject player;

    public int state;
    public float speed;
    public float startAngle;
    public bool goingLeft;
    private bool playerInRange;
    // Start is called before the first frame update
    void Start()
    {
        // 0 Idle // 1 Active 
        startAngle = 0f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        idleTurret();
        activeTurret();
    }

    private void activeTurret()
    {
        if(state == 1)
        {
            transform.LookAt(player.transform.position);
        }
    }

    private void idleTurret()
    {
        float Angle = gameObject.transform.rotation.y;
        print(Angle);
        if (state == 0)
        {
            if(goingLeft == false)
            {
                if(Angle <= startAngle + 0.3f)
                {
                    gameObject.transform.Rotate(0f, 2f, 0f * Time.deltaTime * speed);
                }
                else
                {
                    goingLeft = true;
                }
            }
            else
            {
                if (Angle >= startAngle - 0.3f)
                {
                    gameObject.transform.Rotate(0f, -2f, 0f * Time.deltaTime * speed);
                }
                else
                {
                    goingLeft = false;
                }
            }
        }
    }

    IEnumerator range()
    {
        yield return new WaitForSeconds(5f);
        if (playerInRange == true)
        {
            StartCoroutine(range());
        }
        else
        {
            state = 0;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            state = 1;
            playerInRange = true;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            playerInRange = true;
            StartCoroutine(range());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        playerInRange = false;
    }
}
