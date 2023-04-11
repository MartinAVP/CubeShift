using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    public GameObject bullet_prefab;
    public GameObject player;
    public int estado;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("shoot", 0f, .3f);
    }

    // Update is called once per frame
    void Update()
    {
        estado = gameObject.GetComponentInParent<TurretMain>().state;
    }
    private void shoot()
    {
        if(estado == 1)
        {
            Instantiate(bullet_prefab, GetComponent<Transform>().position,
                GetComponent<Transform>().rotation); // Attached to pos and rot
        }
    }
}
