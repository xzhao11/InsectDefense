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
        float remaining = this.GetComponent<tileWaveScript>().remaining;
        float total = this.GetComponent<tileWaveScript>().totalEnemies;
        float prog = (total - remaining) / total;
        output.text = "Wave Progress";
        progressBar.fillAmount = prog;
    }
}
