using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class CannonBullet : MonoBehaviour
{
    public GameObject cannon;
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(lifetime());
        cannon = GameObject.FindGameObjectWithTag("Cannon");
        transform.parent = cannon.transform;
    }

    private IEnumerator lifetime()
    {
        yield return new WaitForSeconds(5f);
        Destroy(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        gameObject.transform.GetComponent<Rigidbody>().AddForce((player.transform.position - transform.position) * 1);
    }
}
