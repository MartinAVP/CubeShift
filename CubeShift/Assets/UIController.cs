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
    // Start is called before the first frame update
    void Start()
    {
        introduction.SetActive(true);
        levelNumber.text = "Level " + LevelN;
        levelDesc.text = levelDescription;
        deathMessage.text = "";
    }

    // Update is called once per frame
    void Update()
    {

    }
}
