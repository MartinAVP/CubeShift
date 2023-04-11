using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        gameObject.transform.GetComponent<Rigidbody>().AddForce((player.transform.position - transform.position) * 80f);
        StartCoroutine(lifetime());
    }
    private IEnumerator lifetime()
    {
        yield return new WaitForSeconds(5f);
        Destroy(this.gameObject);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
