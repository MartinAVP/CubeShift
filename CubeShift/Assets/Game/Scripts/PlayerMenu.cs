using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMenu : MonoBehaviour
{
    public float speed;
    private int rotID;

    void Start()
    {
        // Will Start the rotation of the player
        StartCoroutine("newDirection");
    }

    // Recursive Function that will change the direction of the player every 3 seconds
    private IEnumerator newDirection()
    {
        yield return new WaitForSeconds(3f);        // 3 Second Delay
        rotID = Random.Range(1, 6);                 // Choose a random Number between 1 and 5
        StartCoroutine("newDirection");             // Call the Function again, making it recursive
    }

    // Will Change a Number on every frame
    void FixedUpdate()
    {
        // Switch for the Random Rotation of the Cubes
        switch (rotID)
        {
            case 0:
                gameObject.transform.Rotate(0f, 0f, 10f * Time.deltaTime * speed);
                break;
            case 1:
                gameObject.transform.Rotate(0f, 0f, -10f * Time.deltaTime * speed);
                break;
            case 2:
                gameObject.transform.Rotate(0f, 10f * Time.deltaTime * speed, 0f);
                break;
            case 3:
                gameObject.transform.Rotate(0f, -10f * Time.deltaTime * speed, 0f);
                break;
            case 4:
                gameObject.transform.Rotate(10f * Time.deltaTime * speed, 0f, 0f);
                break;
            case 5:
                gameObject.transform.Rotate(-10f * Time.deltaTime * speed, 0f, 0f);
                break;
        }
    }
}
