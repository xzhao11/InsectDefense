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

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    //void Update()
    //{

    //}

    void Update()
    {
        
        float remaining = this.GetComponent<tileWaveScript>().remaining;
        float total = this.GetComponent<tileWaveScript>().totalEnemies;
        float prog = (total - remaining) / total;
        // output.text = "WAVE PROGRESS";
        if (remaining == 0 && isTrue == 0)
        {
            //output.text = "WAVE COMPLETE";
            Invoke(output.text = "WAVE COMPLETE, GET READY FOR THE NEXT ONE!", 10);
            isTrue = 1;
        }
        /*else
        {
            Invoke(output.text = "", 10);
        }*/
     
    }
}


