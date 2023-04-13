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
    private bool UIMove;
    private bool fadeOn;
    // Start is called before the first frame update
    void Start()
    {
        startBut.onClick.AddListener(startGame);
        howtoBut.onClick.AddListener(howtoGame);
        quitBut.onClick.AddListener(quitGame);
        closeHowTo.onClick.AddListener(closeHow);

        //fading.a = 0;
        fading.SetActive(true);
        Color imgclr = fading.GetComponent<RawImage>().color;
        imgclr.a = 0f;
        fading.GetComponent<RawImage>().color = imgclr;
        fading.SetActive(false);
    }

    private void closeHow() 
    {
        howToAnim.SetTrigger("HowToClose");
    }
    private void startGame()
    {
        print("The game will start");
        mainAnim.SetTrigger("start");
        UIMove = true;

        fading.SetActive(true);
        fadeOn = true;
        StartCoroutine(StartDelay());
        

    }
    
    private IEnumerator StartDelay() 
    {
        yield return new WaitForSeconds(6f);
        SceneManager.LoadScene(1);
    }

    private void howtoGame()
    {
        print("How to play");
        howToAnim.SetTrigger("HowToOpen");
    }
    private void quitGame()
    {
        Application.Quit();
    }

    private void fade()
    {
        if(fadeOn == true)
        {
            Color imgclr = fading.GetComponent<RawImage>().color;
            imgclr.a += .3f * Time.deltaTime;
            fading.GetComponent<RawImage>().color = imgclr;
        }
    }

    // Update is called once per frame
    void Update()
    {
        fade();

        if (UIMove == true)
        {
            canvas.transform.position += Vector3.right * Time.deltaTime * 5000f;
        }

        if(canvas.transform.position.x > 3500f)
        {
            UIMove = false;
        }
    }
}
