using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    public GameObject bullet_prefab;
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("shoot", 0f, .01f);
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
