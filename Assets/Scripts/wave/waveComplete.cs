using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;
using UnityEngine.SceneManagement;

public class waveComplete : MonoBehaviour
{
    public TMP_Text output;
    static float isTrue = 0;
    public GameObject nest;
    public float betweenWaves = 1200f;
    private float downTime;
    public GameObject wave;
    public Canvas finishedScreen;
    public Canvas otherUI;
    public Text score;
    // Start is called before the first frame update
    void Start()
    {
        downTime = betweenWaves;
    }

    // Update is called once per frame
    //void Update()
    //{

    //}

    void Update()
    {
        
        float remaining = this.GetComponent<tileWaveScript>().remaining;
        float total = this.GetComponent<tileWaveScript>().getTotalEnemies();
        int num = wave.GetComponent<waveData>().numWaves;
        int waves = this.GetComponent<tileWaveScript>().finishedWaves;
        float prog = (total - remaining) / total;
        // output.text = "WAVE PROGRESS";
        if (remaining == 0 && isTrue == 0 && num != waves)
        {
            //output.text = "WAVE COMPLETE";
            output.text = "WAVE COMPLETE, GET READY FOR THE NEXT ONE!";
            //Invoke(output.text = "WAVE COMPLETE, GET READY FOR THE NEXT ONE!", 3);
            isTrue = 1;
            nest.GetComponent<nestScript>().repopulate(waves);
        }
        else if(remaining == 0 && isTrue == 0 && num == waves)
        {
            output.text = "YOU BEAT ALL OF THE WAVES! CONGRATS!";
            finishedScreen.gameObject.SetActive(true);
            otherUI.gameObject.SetActive(false);
            isTrue = 1;
            nest.GetComponent<nestScript>().repopulate(waves);
            Debug.Log(nest.GetComponent<nestScript>().numAnts);
            score.GetComponent<Text>().text = "Your score is " + nest.GetComponent<nestScript>().numAnts;
            if (SceneManager.GetActiveScene().buildIndex == 5)
            {
                PlayerPrefs.SetInt("LevelTScore", nest.GetComponent<nestScript>().numAnts);
            }
            else if (SceneManager.GetActiveScene().buildIndex == 3)
            {
                PlayerPrefs.SetInt("Level1Score", nest.GetComponent<nestScript>().numAnts);
            }
            else if (SceneManager.GetActiveScene().buildIndex == 4)
            {
                PlayerPrefs.SetInt("Level2Score", nest.GetComponent<nestScript>().numAnts);
            }

            Time.timeScale = 0;
            //PlayerPrefs.SetInt("Larva", nest.GetComponent<nestScript>().numLarva);
            PlayerPrefs.SetInt("LevelFinish", SceneManager.GetActiveScene().buildIndex);
        }

        if(isTrue == 1 && Time.timeScale > 0)
        {
            downTime -= 1;

            if(downTime <= 0)
            {
                downTime = betweenWaves;
                this.GetComponent<tileWaveScript>().newWave();
                output.text = "";
                isTrue = 0;
            }
        }
        /*else
        {
            Invoke(output.text = "", 10);
        }*/
     
    }
}


