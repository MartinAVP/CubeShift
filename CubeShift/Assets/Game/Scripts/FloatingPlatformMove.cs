using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        leftPos = leftPoint.transform.position;
        rightPos = rightPoint.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void checkPoints()
    {

    }


    //Make the platform move from one place to the other
    private void Move()
    {
        if (goingLeft)
        {
            if (transform.position.x <= leftPos.x)
            {
                //Then we are not going left
                goingLeft = false;
            }
            else
            {
                //Go left instead
                transform.position += Vector3.left * Time.deltaTime * speed;
            }
        }
        else
        {
            if (transform.position.x >= rightPos.x)
            {
                //Then we're going left
                goingLeft = true;
            }
            else
            {
                //Go right instead
                transform.position += Vector3.right * Time.deltaTime * speed;
            }
        }
    }
}
