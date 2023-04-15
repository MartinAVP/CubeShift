using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 10f;
    public Rigidbody rb;
    public Text degrees;
    public GameObject UICon;

    private float rotation = 45f;
    private bool keyPaused;
    private bool isSnapped = false;
    private float myAngle;
    private Vector3 spawnPoint;

    private bool canRotate;
    private void Start()
    {
        spawnPoint = transform.position;
        canRotate = true;
    }

    void FixedUpdate()
    {
        movement();
        updateUI();
    }

    // Pauses the player so the function is not called infinitely.
    private IEnumerator keyPause()
    {
        yield return new WaitForSeconds(.2f);
        keyPaused = false;
    }
    
    // Small delay for Respawning
    private IEnumerator respawnDelay()
    {
        yield return new WaitForSeconds(2f);
        canRotate = true;
    }

    //Checks for keys the player has pressed
    private void movement()
    {
        if (canRotate == true)
        {
            if (Input.GetKey("a"))
            {
                //Rotates the object to the right over time
                gameObject.transform.Rotate(0f, 0f, 10f * Time.deltaTime * speed);
                isSnapped = false;
            }
            else if (Input.GetKey("d"))
            {
                //Rotates the object to the left over time
                gameObject.transform.Rotate(0f, 0f, -10f * Time.deltaTime * speed);
                isSnapped = false;
            }
            else if(Input.GetKey("q")) // Snaps the Object and Rotates it Right
            {
                if(keyPaused == false)
                {
                    changeDegree(); // Snaps
                    keyPaused = true; //Prevents infinite rotation
                    gameObject.transform.Rotate(0f, 0f, 0f + rotation); // Rotates
                    StartCoroutine(keyPause());
                }
            }
            else if(Input.GetKey("e")) // Snaps the Object and Rotates it Left
            {
                if(keyPaused == false)
                {
                    changeDegree(); // Snaps
                    keyPaused = true; //Prevents infinite rotation
                    gameObject.transform.Rotate(0f, 0f, 0f - rotation); //Rotates
                    StartCoroutine(keyPause());
                }
            }        
        }
    }

    //Keeps the the Angle UI Updated
    private void updateUI()
    {
        float Angle = gameObject.transform.rotation.eulerAngles.z;
        Angle = Mathf.Round(Angle); // Rounds the number so 2.00001 -> 2
        degrees.text = Angle.ToString() + "°"; // Displays and adds degree symbol
    }

    //Snaps the rotation to the neerest degree with a difference of 22.5
    private void changeDegree()
    {
        myAngle = gameObject.transform.rotation.eulerAngles.z;
        if (myAngle > 0f && myAngle <= 22.5f) // Check if the angle is higher than 0 but less than 22.5 // 0°
        {
            //print("angle is near 0");
            transform.rotation = Quaternion.Euler(0, 0, 0);
            isSnapped = true;
        }
        else if(myAngle > 22.5f && myAngle <= 67.5f) // Check if the angle is higher than 22.5 but less than 67.5 // 45°
        {
            //print("angle is near 45");
            transform.rotation = Quaternion.Euler(0, 0, 45);
            isSnapped = true;
        }
        else if (myAngle > 67.5f && myAngle <= 112.5f) // Check if the angle is higher than 67.5 but less than 112.5 // 90°
        { 
            //print("angle is near 90");
            transform.rotation = Quaternion.Euler(0, 0, 90);
            isSnapped = true;
        }
        else if (myAngle > 112.5f && myAngle <= 157.5f) // Check if the angle is higher than 112.5 but less than 157.5 // 135°
        {
            //print("angle is near 135");
            transform.rotation = Quaternion.Euler(0, 0, 135);
            isSnapped = true;
        }
        else if (myAngle > 157.5f && myAngle <= 202.5f) // Check if the angle is higher than 157.5 but less than 202.5 // 180°
        {
            //print("angle is near 180");
            transform.rotation = Quaternion.Euler(0, 0, 180);
            isSnapped = true;
        }
        else if (myAngle > 202.5f && myAngle <= 247.5f) // Check if the angle is higher than 202.5 but less than 247.5 // 225°
        {
            //print("angle is near 225");
            transform.rotation = Quaternion.Euler(0, 0, 225);
            isSnapped = true;
        }
        else if (myAngle > 247.5f && myAngle <= 292.5f) // Check if the angle is higher than 247.5 but less than 292.5 // 270°
        {
            //print("angle is near 270");
            transform.rotation = Quaternion.Euler(0, 0, 270);
            isSnapped = true;
        }
        else if (myAngle > 292.5f && myAngle <= 337.5f) // Check if the angle is higher than 292.5 but less than 337.5 // 315°
        {
            //print("angle is near 315");
            transform.rotation = Quaternion.Euler(0, 0, 315);
            isSnapped = true;
        }
        else if (myAngle > 337.5f && myAngle <= 360.5f) // Check if the angle is higher than 337.5 but less than 360.5 // 360°
        {
            //print("angle is near 360 or 0");
            transform.rotation = Quaternion.Euler(0, 0, 0);
            isSnapped = true;
        }
        else
        {
            print("no angle found");
        }
    }

    // Function that will respawn the rotation of the level and start a small delay for moving it
    public void Respawn()
    {
        gameObject.transform.position = spawnPoint;
        transform.rotation = Quaternion.Euler(0, 0, 0);
        canRotate = false;
        StartCoroutine(respawnDelay());
    }
}
