using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Cannon : MonoBehaviour
{
    public GameObject player;
    public GameObject bullet_prefab;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("shoot", 0f, 2f);
    }

    // Update is called once per frame
    void Update()
    {

        transform.LookAt(player.transform.position);
    }

    private void shoot()
    {
        Instantiate(bullet_prefab, GetComponent<Transform>().position,
            GetComponent<Transform>().rotation); // Attached to pos and rot
    }
}
