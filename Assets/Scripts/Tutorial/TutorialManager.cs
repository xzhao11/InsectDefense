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
            }
        }

        if (timerIsRunning)
        {
            timer += Time.deltaTime;
        }


    }

}
