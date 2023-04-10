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

    // Start is called before the first frame update
    void Start()
    {
        //leftPos = leftPoint.transform.position;
        //rightPos = rightPoint.transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        movement();
        //Move();
    }

    private void movement()
    {
        if(goingLeft == false) 
        {
            if (gameObject.transform.position == leftPoint.transform.position)
            {
                print("toco el punto izquierdo");
                goingLeft = true;
            }
            else
            {
                transform.position = Vector3.MoveTowards(transform.position, leftPoint.transform.position, speed * Time.deltaTime);
            }
        }
        else
        {
            if (gameObject.transform.position == rightPoint.transform.position)
            {
                print("toco el punto derecho");
                goingLeft = false;
            }
            else
            {
                transform.position = Vector3.MoveTowards(transform.position, rightPoint.transform.position, speed * Time.deltaTime);
            }
        }
    }

    //Make the platform move from one place to the other
    private void Move()
    {
        if (goingLeft == false)
        {
            if (transform.position.x == rightPoint.transform.position.x && transform.position.y == rightPoint.transform.position.y)
            {
                //Then we are not going left
                print("leftPoint");
                goingLeft = true;
            }
            else
            {
                //Go left instead
                //transform.position += Vector3.left * Time.deltaTime * speed;
                transform.position = Vector3.MoveTowards(transform.position, leftPoint.transform.position, speed * Time.deltaTime);
            }
        }
        else
        {
            if (transform.position == leftPoint.transform.position)
            {
                //Then we're going left
                goingLeft = false;
                print("touched position");
            }
            else
            {
                //Go right instead
                //transform.position += Vector3.right * Time.deltaTime * speed;
                transform.position = Vector3.MoveTowards(transform.position, rightPoint.transform.position, speed * Time.deltaTime);
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            //print("player in range stayed");
            //other.transform.position = Vector3.MoveTowards(other.transform.position, transform.position, 1.3f * speed * Time.deltaTime);
        }
    }

    /*
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
