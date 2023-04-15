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

    private int deathMsgId;

    void Start()
    {
        introduction.SetActive(true); // sets the GameObject enabled
        animatore = introduction.gameObject.GetComponent<Animator>(); // references the Animator component in the introduction GameObject
        levelNumber.text = "Level " + LevelN;       // Sets the UI level to what is defined
        levelDesc.text = levelDescription;          // Sets the Level Description to whatever set in the script
        deathMessage.text = "";                     // Sets the Level Death Message to Nothing
    }

    // Function of public access that will call the Death
    public void Death()
    {
        levelNumber.text = " ";                     // Sets the Level Number to nothing
        deathMessage.text = "You Died";             // Sets the Death message to "You Died"
        RandomDeath();                              // Calls the Random Death Function
        animatore.SetTrigger("ScreenIn");           // Triggers the Animation For Screen In
        animatore.SetTrigger("ScreenOut");          // Triggers the Animation For Screen Out
    }
    
    // Function of public access that plays when the player ends the level
    public void LevelComplete()
    {
        levelNumber.text = " ";                     // Sets the level number to nothing
        deathMessage.text = " ";                    // Sets the Death message to nothing
        levelDesc.text = " ";                       // Sets the level description
        animatore.SetTrigger("ScreenIn");           // Triggers the Animation For Screen In
    }

    private void RandomDeath()                      
    {
        deathMsgId = Random.Range(1, 6);            // Will Generate a number between 1 and 5
        switch (deathMsgId)                         // Will Choose a random number and assign it a death message.
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
}
