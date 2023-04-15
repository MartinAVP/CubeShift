using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Constantly get the rotation of the Main Level
//Add the rotation angle to the platform
// Move it along that fake axis.

public class FloatingPlatformMove : MonoBehaviour
{
    public GameObject leftPoint;
    public GameObject rightPoint;
    private Vector3 leftPos;
    private Vector3 rightPos;
    public int speed;
    public bool goingLeft;

    void Start()
    {
        //leftPos = leftPoint.transform.position;
        //rightPos = rightPoint.transform.position;
    }

    void FixedUpdate()
    {
        movement();
    }

    private void movement()
    {
        if(goingLeft == false) // Right or Left Switch
        {
            if (gameObject.transform.position == leftPoint.transform.position) // Checks if the platform is at the left boundary
            {
                goingLeft = true; // Switches and now Goes Right
            }
            else
            {
                transform.position = Vector3.MoveTowards(transform.position, leftPoint.transform.position, speed * Time.deltaTime);
                // Moves the platform Towards the Left Boundary position
            }
        }
        else
        {
            if (gameObject.transform.position == rightPoint.transform.position) // Checks if the platform is at the right boundary
            {
                goingLeft = false; // Switches and now Goes Left
            }
            else
            {
                transform.position = Vector3.MoveTowards(transform.position, rightPoint.transform.position, speed * Time.deltaTime);
                // Moves the platform Towards the Right Boundary position
            }
        }
    }

    // GRAVITY PLATFORM TEST
    /*
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            //print("player in range stayed");
            //other.transform.position = Vector3.MoveTowards(other.transform.position, transform.position, 1.3f * speed * Time.deltaTime);
        }
    }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.tag == "Player")
            {
                print("player collided");
                if(goingLeft) 
                {
                    collision.transform.position = Vector3.MoveTowards(collision.transform.position, leftPoint.transform.position, speed * Time.deltaTime);
                }
                else
                {
                    collision.transform.position = Vector3.MoveTowards(collision.transform.position, leftPoint.transform.position, speed * Time.deltaTime);
                }
            }
        }
    */
}
