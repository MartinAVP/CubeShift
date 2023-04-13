using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneSwitch : MonoBehaviour
{
    public GameObject mainLevel;
    public bool islastlevel;
    private int currentLevelID;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator switchlvl()
    {
        yield return new WaitForSeconds(2f);
        currentLevelID = SceneManager.GetActiveScene().buildIndex;
        if (islastlevel == false)
        {
            SceneManager.LoadScene(currentLevelID + 1);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            mainLevel.GetComponent<UIController>().LevelComplete();
            StartCoroutine(switchlvl());
        }
    }
}
