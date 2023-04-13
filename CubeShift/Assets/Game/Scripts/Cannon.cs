using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Cannon : MonoBehaviour
{
    public GameObject player;
    public GameObject bullet_prefab;
    private bool spawnDelay;

    // Start is called before the first frame update
    void Start()
    {
        spawnDelay = false;
        InvokeRepeating("shoot", 0f, 2f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(player.transform.position);
    }

    public void dActivation()
    {
        StartCoroutine(delayActivation());
    }

    public IEnumerator delayActivation()
    {
        spawnDelay = true;
        yield return new WaitForSeconds(2f);
        spawnDelay = false;
    }

    private void shoot()
    {
        if (spawnDelay == false)
        {
            Instantiate(bullet_prefab, GetComponent<Transform>().position,
                GetComponent<Transform>().rotation); // Attached to pos and rot
        }
    }
}
