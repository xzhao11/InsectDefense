using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;

public class displayWaveProgress : MonoBehaviour
{
    public TMP_Text output;
    public GameObject waveData;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        int num = waveData.GetComponent<waveScript>().numEnemies;
        int total = waveData.GetComponent<waveScript>().totalEnemies;
        int prog = (int)Math.Round(((double) num / (double) total) * 100);
        output.text = "Wave Progress: " + prog + "%";
    }
}
