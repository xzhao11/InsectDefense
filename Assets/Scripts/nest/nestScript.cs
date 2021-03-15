using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class nestScript : MonoBehaviour
{
    public int numLarva;
    private int numAnts = 0;
    public float healthLossRate = 1.0f;
    //public int numGrain = 0;
    public float twinChance = 0.25f;
    public float tripletChance = 0.1f;
    [SerializeField] TMP_Text num_msg;
    public Canvas loseScreen;
    public Canvas otherUI;
    public Canvas tutorialCanvas;
    public Text upgradeWeaponText;
    public Text zoomoutText;
    public int numStolen;
    public int numStolenToGiveHint = 3;

    public GameObject waveManager;
    private float timeToSpawnOriginal;
    public GameObject topDownCamera;
    private GameObject[] weaponStations;
    private GameObject[] towerDurStations;
    private GameObject[] playerSpeedStations;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        numAnts = 0;
        //numGrain = 0;
        twinChance = 0.25f;
        tripletChance = 0.25f;
        numStolen = 0;
        weaponStations = GameObject.FindGameObjectsWithTag("UpgradeWeapon");
        towerDurStations = GameObject.FindGameObjectsWithTag("UpgradeTowerDuration");
        playerSpeedStations = GameObject.FindGameObjectsWithTag("UpgradePlayerSpeed");
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
            //Time.timeScale = 0;
            otherUI.gameObject.SetActive(false);
            var enemies = GameObject.FindGameObjectsWithTag("Enemy");
            foreach (GameObject theenemy in enemies)
            {
                theenemy.GetComponent<tileMovement>().moveSpeed = 0;
            }
            //num_msg.text = "";
        }

        if (numStolen >= numStolenToGiveHint)
        {
            tutorialCanvas.gameObject.SetActive(true);
            upgradeWeaponText.gameObject.SetActive(true);
            timeToSpawnOriginal = waveManager.GetComponent<tileWaveScript>().timeToSpawn;
            waveManager.GetComponent<tileWaveScript>().timeToSpawn =  Mathf.Infinity;
            if (upgradeWeaponText.GetComponent<TextTyping>().isFinished)
            {
                tutorialCanvas.gameObject.SetActive(false);
                upgradeWeaponText.gameObject.SetActive(false);
                numStolen = 0;
                numStolenToGiveHint += 2;
                CameraControl camCon = topDownCamera.GetComponent<CameraControl>();
                if (camCon.cam.orthographicSize <= camCon.startSize + 20 )
                {
                    tutorialCanvas.gameObject.SetActive(true);
                    zoomoutText.gameObject.SetActive(true);
                    if (zoomoutText.GetComponent<TextTyping>().isFinished)
                    {
                        tutorialCanvas.gameObject.SetActive(false);
                        zoomoutText.gameObject.SetActive(false);
                    }
                }


                foreach (GameObject station in weaponStations)
                {
                    station.GetComponent<Scaling>().enabled = true;
                }

                foreach (GameObject station in towerDurStations)
                {
                    station.GetComponent<Scaling>().enabled = true;
                }

                foreach (GameObject station in playerSpeedStations)
                {
                    station.GetComponent<Scaling>().enabled = true;
                }

                if (player.GetComponent<PlayerAttack>().hitUpgrade)
                {
                    foreach (GameObject station in weaponStations)
                    {
                        station.GetComponent<Scaling>().enabled = false;
                    }

                    foreach (GameObject station in towerDurStations)
                    {
                        station.GetComponent<Scaling>().enabled = false;
                    }

                    foreach (GameObject station in playerSpeedStations)
                    {
                        station.GetComponent<Scaling>().enabled = false;
                    }

                    waveManager.GetComponent<tileWaveScript>().timeToSpawn = timeToSpawnOriginal;
                }
            }

        }

        
    }

    void decreaseLarva()
    {
        numLarva -= 1;
    }

    public void repopulate(int numWave)
    {
        int singleHatches = numLarva;
        int doubleHatches = (int)(singleHatches * twinChance * Mathf.Exp(0.25f * numWave));
        int tripleHatches = (int)(doubleHatches * tripletChance * Mathf.Exp(0.25f * numWave));

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
