using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneSwitch : MonoBehaviour
{
    public GameObject mainLevel;
    public bool islastlevel;
    private int currentLevelID;

    // Check if the player Collides with the player
    private void OnTriggerEnter(Collider other)
    {
        // Check if the Collision tag is Player
        if(other.gameObject.tag == "Player")
        {
            mainLevel.GetComponent<UIController>().LevelComplete(); // Calls the Level Complete Function on the UI
            StartCoroutine(switchlvl());    // Starts the switch level Coroutine
        }
    }

    // Function will switch the Scene
    private IEnumerator switchlvl()
    {
        yield return new WaitForSeconds(2f); // 2 Second Delay
        currentLevelID = SceneManager.GetActiveScene().buildIndex; // Will get the current index of the Scene
        if (islastlevel == false)   // Will check if the last player bool is enabled
        {
            SceneManager.LoadScene(currentLevelID + 1); // Will load the next scene in the index
        }
    }
}
