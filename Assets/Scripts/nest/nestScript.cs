using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class nestScript : MonoBehaviour
{
    public int numLarva;
    private int numAnts = 0;
    public float healthLossRate = 1.0f;
    //public int numGrain = 0;
    public float twinChance = 0.25f;
    public float tripletChance = 0.25f;
    [SerializeField] TMP_Text num_msg;
    public Canvas loseScreen;
    public Canvas otherUI;
    // Start is called before the first frame update
    void Start()
    {
        numAnts = 0;
        //numGrain = 0;
        twinChance = 0.25f;
        tripletChance = 0.25f;
        
        //if (SceneManager.GetActiveScene().buildIndex != 5)
        //{
        //    numLarva = PlayerPrefs.GetInt("Larva");
        //}
    }

    // Update is called once per frame
    void Update()
    {
        num_msg.text = "Larva: " + numLarva; //+ "\nGrain: " + numGrain;
        if (numLarva < 0)
        {
            loseScreen.gameObject.SetActive(true);
            Time.timeScale = 0;
            otherUI.gameObject.SetActive(false);
            //num_msg.text = "";
        }

        
    }

    void decreaseLarva()
    {
        numLarva -= 1;
    }

    public void repopulate(int numWave)
    {
        int singleHatches = numLarva;
        int doubleHatches = (int)(singleHatches * Mathf.Exp(0.25f * numWave));
        int tripleHatches = (int)(doubleHatches * Mathf.Exp(0.25f * numWave));

        numAnts += singleHatches + doubleHatches + tripleHatches;
        numLarva = numAnts;
    }

    public void repopulateEnd()
    {
        numLarva += 30;
        var towers = GameObject.FindGameObjectsWithTag("Tower");
        numLarva += towers.Length * 10;
    }
}
