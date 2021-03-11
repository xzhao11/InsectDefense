using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialManager : MonoBehaviour
{
    private float timer;
    public bool timerIsRunning = false;
    public Canvas tutorialCanvas;
    public Text startStory;
    public Text placeTower1;
    public Text shift;
    public GameObject shopCanvas;
    public Image arrowTower;

    public Button startWaveButton;

    private int timerWhole = 0;
    void Start()
    {
        timerIsRunning = true;
        timer = 0;

    }

    // Update is called once per frame
    void Update()
    {
        if (timer == 0)
        {
            timerIsRunning = false;
            tutorialCanvas.gameObject.SetActive(true);
            startStory.gameObject.SetActive(true);
            if (startStory.GetComponent<TextTyping>().isFinished)
            {
                timerIsRunning = true;
                tutorialCanvas.gameObject.SetActive(false);
                startStory.gameObject.SetActive(false);
            }
        }


        if (timer >= 2)
        {
            timerIsRunning = false;
            
            if (shopCanvas.GetComponent<Scaling>().isFinished)
            {
                timerIsRunning = true;
            }
            else
            {
                shopCanvas.GetComponent<Scaling>().enabled = true;
            }
        }



        //if (timer >= 2)
        //{
        //    timerIsRunning = false;
        //    tutorialCanvas.gameObject.SetActive(true);
        //    placeTower1.gameObject.SetActive(true);
        //    if (placeTower1.GetComponent<TextTyping>().isFinished)
        //    {
        //        //timerIsRunning = true;
        //        tutorialCanvas.gameObject.SetActive(false);
        //        placeTower1.gameObject.SetActive(false);
        //        shopCanvas.GetComponent<Scaling>().enabled = true;
        //        if (shopCanvas.GetComponent<Scaling>().isFinished)
        //        {
        //            timerIsRunning = true;
        //        }

        //    }
        //}
        var towers = GameObject.FindGameObjectsWithTag("Tower");
        if (timer >= 4)
        {
            timerIsRunning = false;
            
            if (towers.Length == 0)
            {
                arrowTower.gameObject.SetActive(true);
            }
            else
            {
                arrowTower.gameObject.SetActive(false);
                timerIsRunning = true;
                arrowTower.GetComponent<Scaling>().OnClose();
            }
        }


        if (timer >= 5)
        {
            timerIsRunning = false;
            tutorialCanvas.gameObject.SetActive(true);
            shift.gameObject.SetActive(true);
            if (shift.GetComponent<TextTyping>().isFinished)
            {
                timerIsRunning = true;
                tutorialCanvas.gameObject.SetActive(false);
                shift.gameObject.SetActive(false);
            }
        }


        if (timer >= 7)
        {
            if (startWaveButton.gameObject.activeSelf)
            {
                startWaveButton.GetComponent<Scaling>().enabled = true;
            }
            else 
            {
                startWaveButton.GetComponent<Scaling>().OnClose();
                timerIsRunning = true;
            }
        }

        if (timerIsRunning)
        {
            timer += Time.deltaTime;
        }

        
        if (timerWhole!= (int)timer)
        {
            timerWhole = (int)timer;
            Debug.Log(timerWhole);
        }
        
    }

}
