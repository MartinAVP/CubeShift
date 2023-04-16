using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuUI;
    public bool gameIsPaused;
    // Start is called before the first frame update
    void Start()
    {
        pauseMenuUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gameIsPaused) // = True
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Pause()
    {
        gameIsPaused = true;
        Time.timeScale = 0.0f;
        pauseMenuUI.SetActive(true);
    }
    
    public void Resume()
    {
        gameIsPaused = false;
        Time.timeScale = 1.0f;
        pauseMenuUI.SetActive(false);
    }

    public void mainMenu()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(0);
    }

    public void quitGame()
    {
        Application.Quit();
    }

}
