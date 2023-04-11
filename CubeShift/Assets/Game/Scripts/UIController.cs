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

    public int deathMsgId;
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
        RandomDeath();
        animatore.SetTrigger("ScreenIn");
        animatore.SetTrigger("ScreenOut");
    }

    private void RandomDeath()
    {
        deathMsgId = Random.Range(1, 6);
        switch (deathMsgId)
        {
            case 1:
                levelDesc.text = "do better.";
                break;
            case 2:
                levelDesc.text = "Is that the best you can do?";
                break;
            case 3:
                levelDesc.text = "Try not dying";
                break;
            case 4:
                levelDesc.text = "Is this really a hard game?";
                break;
            case 5:
                levelDesc.text = "Wow...";
                break;

        }
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
