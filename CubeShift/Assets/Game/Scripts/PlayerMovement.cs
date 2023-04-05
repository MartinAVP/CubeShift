using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 10f;
    public Rigidbody rb;

    // Update is called once per frame
    void FixedUpdate()
    {
        movement();
    }

    private void movement()
    {
        if (Input.GetKey("a"))
        {
            gameObject.transform.Rotate(0f, 0f, 10f * Time.deltaTime * speed);
            print(gameObject.transform.rotation);
        }
        else if (Input.GetKey("d"))
        {
            gameObject.transform.Rotate(0f, 0f, -10f * Time.deltaTime * speed);
            print(gameObject.transform.rotation.ToString());
        }
        else if(Input.GetKey("e")) 
        {
            rb.AddForce(Vector3.up * speed);
        }
    }
}
