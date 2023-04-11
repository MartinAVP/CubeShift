using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretMain : MonoBehaviour
{
    public GameObject player;

    private int state;
    public float speed;
    public float maxAngle;
    public bool goingLeft;
    // Start is called before the first frame update
    void Start()
    {
        // 0 Idle // 1 Active 
        state = 1;
        maxAngle = 30f;
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
        float Angle = gameObject.transform.rotation.eulerAngles.y;
        //print(Angle);
        if (state == 0)
        {
            if(goingLeft == false)
            {
                if(Angle <= maxAngle)
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
                if (Angle > 360 - maxAngle && Angle <= maxAngle)
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
}
