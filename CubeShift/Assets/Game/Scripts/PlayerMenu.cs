using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMenu : MonoBehaviour
{
    public float speed;
    private int rotID;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("newDirection");
    }

    private IEnumerator newDirection()
    {
        yield return new WaitForSeconds(3f);
        rotID = Random.Range(1, 6);
        StartCoroutine("newDirection");
    }

    // Update is called once per frame
    void Update()
    {
        //gameObject.transform.rotation = Random.rotation;
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
