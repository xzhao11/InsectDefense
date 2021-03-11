using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;

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


