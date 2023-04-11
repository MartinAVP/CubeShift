using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public GameObject introduction;
    public int LevelN;
    public Text deathMessage;
    public Text levelNumber;
    public Text levelDesc;
    public string levelDescription;
    private Animator animatore;
    // Start is called before the first frame update
    void Start()
    {
        introduction.SetActive(true);
        animatore = introduction.gameObject.GetComponent<Animator>();
        levelNumber.text = "Level " + LevelN;
        levelDesc.text = levelDescription;
        deathMessage.text = "";
    }

    public void Death()
    {
        print("UI Death");
        levelNumber.text = " ";
        deathMessage.text = "You Died";
        levelDesc.text = "do better.";
        animatore.SetTrigger("ScreenIn");
        animatore.SetTrigger("ScreenOut");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("o"))
        {
            animatore.SetTrigger("ScreenIn");
        }
        else if (Input.GetKey("p"))
        {
            animatore.SetTrigger("ScreenOut");
        }
    }
}
