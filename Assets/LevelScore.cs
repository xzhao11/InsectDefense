using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelScore : MonoBehaviour
{
    public Text level1;
    public Text level2;
    public Text tutorial;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerPrefs.GetInt("Level1Score") >= 0){
            level1.GetComponent<Text>().text = ""+ PlayerPrefs.GetInt("Level1Score");
        }
        else
        {
            level1.GetComponent<Text>().text = "";
        }
        if (PlayerPrefs.GetInt("Level2Score") >= 0)
        {
            level2.GetComponent<Text>().text = "" + PlayerPrefs.GetInt("Level2Score");
        }
        else
        {
            level2.GetComponent<Text>().text = "";
        }
        if (PlayerPrefs.GetInt("LevelTScore") >= 0)
        {
            tutorial.GetComponent<Text>().text = "" + PlayerPrefs.GetInt("LevelTScore");
        }
        else
        {
            tutorial.GetComponent<Text>().text = "";
        }

        
        
    }
}
