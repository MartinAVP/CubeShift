using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("w"))
        {
            //gameObject.transform.GetComponent<Rigidbody>().AddForce(Vector3.forward * Time.deltaTime * speed);
            gameObject.transform.position += Vector3.forward * Time.deltaTime * speed;
        }
        if (Input.GetKey("s"))
        {
            //gameObject.transform.GetComponent<Rigidbody>().AddForce(Vector3.forward * Time.deltaTime * speed);
            gameObject.transform.position += Vector3.back * Time.deltaTime * speed;
        }
        if (Input.GetKey("d"))
        {
            //gameObject.transform.GetComponent<Rigidbody>().AddForce(Vector3.forward * Time.deltaTime * speed);
            gameObject.transform.position += Vector3.right * Time.deltaTime * speed;
        }
        if (Input.GetKey("a"))
        {
            //gameObject.transform.GetComponent<Rigidbody>().AddForce(Vector3.forward * Time.deltaTime * speed);
            gameObject.transform.position += Vector3.left * Time.deltaTime * speed;
        }
    }
}
