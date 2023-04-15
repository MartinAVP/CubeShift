using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public Button startBut;
    public Button howtoBut;
    public Button quitBut;
    public Button closeHowTo;

    public Animator mainAnim;
    public Animator howToAnim;
    public GameObject canvas;
    public GameObject fading;
    public GameObject howToPlayContent;
    private bool UIMove;
    private bool fadeOn;

    void Start()
    {
        startBut.onClick.AddListener(startGame); // Will Check if the Button startBut is clicked and call startGame function
        howtoBut.onClick.AddListener(howtoGame); // Will Check if the Button howToBut is clicked and call howtoGame function
        quitBut.onClick.AddListener(quitGame);   // Will Check if the Button quitBut is clicked and call quitGame function
        closeHowTo.onClick.AddListener(closeHow); // Will Check if the Button closeHowTo is clicked and call the closeHow function

        fading.SetActive(true);                                 // Activate de Fading Effect  
        Color imgclr = fading.GetComponent<RawImage>().color;   // Gets the color from the Raw Image in the GameObject
        imgclr.a = 0f;                                          // Sets the oppacity of the color to 0 - Transparent

        fading.GetComponent<RawImage>().color = imgclr;         // Sets the color component to imgclr
        fading.SetActive(false);                                // Disabled the GameObject
        howToPlayContent.SetActive(true);                       // Enables the How to Play GameObject
    }

    // Function to sets the Animator Trigger so the How To UI is closed
    private void closeHow() 
    {
        howToAnim.SetTrigger("HowToClose");
    }

    // Function to set the start the game
    private void startGame()
    {
        print("The game will start");
        mainAnim.SetTrigger("start");   // starts the Animator trigger
        UIMove = true;                  // Move the Main UI

        fading.SetActive(true);         // Activates the Fading Effect
        fadeOn = true;                  // makes the fading
        StartCoroutine(StartDelay());   // Calls the start delay
    }
    
    // Delay for when the fading effect has ended
    private IEnumerator StartDelay() 
    {
        // Delays the Game about 6 seconds
        yield return new WaitForSeconds(6f);
        SceneManager.LoadScene(1); // Loads the first Scene
    }

    // Function to open the How to Play UI
    private void howtoGame()
    {
        print("How to play");
        howToAnim.SetTrigger("HowToOpen");
    }

    // Function to quit the game
    private void quitGame()
    {
        Application.Quit();
    }

    // Function to fade the screen
    private void fade()
    {
        if(fadeOn == true)
        {
            Color imgclr = fading.GetComponent<RawImage>().color;
            imgclr.a += .3f * Time.deltaTime; // Starts increasing the opacity until the screen is filled
            fading.GetComponent<RawImage>().color = imgclr;
        }
    }

    // Update is called once per frame
    void Update()
    {
        fade(); // Fade Function

        if (UIMove == true)
        {
            canvas.transform.position += Vector3.right * Time.deltaTime * 5000f; // Moves the UI to the Right
        }

        if(canvas.transform.position.x > 3500f) // Limits the Canvas position
        {
            UIMove = false;
        }
    }
}
