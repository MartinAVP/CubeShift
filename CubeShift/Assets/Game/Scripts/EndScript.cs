using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class EndScript : MonoBehaviour
{
    public Button returnMain;
    public Button quitGame;
    public GameObject content;

    // Start is called before the first frame update
    void Start()
    {
        returnMain.onClick.AddListener(loadMain); // Will Check if the Button startBut is clicked and call startGame function
        quitGame.onClick.AddListener(loadMain); // Will Check if the Button startBut is clicked and call startGame function
        content.SetActive(false);
    }

    public void enableEndMenu()
    {
        content.SetActive(true);
    }

    public void loadMain()
    {
        SceneManager.LoadScene(0);
    }

    public void quitting()
    {
        Application.Quit();
    }
}
