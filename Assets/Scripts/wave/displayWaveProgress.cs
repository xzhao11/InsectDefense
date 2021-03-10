using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;

public class displayWaveProgress : MonoBehaviour
{
    public TMP_Text output;
    [SerializeField] Image progressBar;
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
        float toSpawn = this.GetComponent<tileWaveScript>().toSpawn;
        float total = this.GetComponent<tileWaveScript>().getTotalEnemies();
        float prog = (total-toSpawn) / total;
       // output.text = "WAVE PROGRESS";
        if(prog == total)
        {
            output.text = "WAVE COMPLETE";
        }
        progressBar.fillAmount = prog;
    }
}
