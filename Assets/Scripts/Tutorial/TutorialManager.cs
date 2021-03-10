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
    public GameObject shopCanvas;
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
            tutorialCanvas.gameObject.SetActive(true);
            placeTower1.gameObject.SetActive(true);
            if (placeTower1.GetComponent<TextTyping>().isFinished)
            {
                tutorialCanvas.gameObject.SetActive(false);
                placeTower1.gameObject.SetActive(false);
                LeanTween.moveY(shopCanvas, shopCanvas.transform.position.y + 1f, shopCanvas.transform.position.y).setLoopPingPong();
            }

        }

        if (timerIsRunning)
        {
            timer += Time.deltaTime;
        }

    }

}
