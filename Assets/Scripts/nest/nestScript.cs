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
    public int numAnts = 0;
    public float healthLossRate = 1.0f;
    //public int numGrain = 0;
    public float twinChance = 0.25f;
    public float tripletChance = 0.1f;
    [SerializeField] TMP_Text num_msg;
    public Canvas loseScreen;
    public Canvas otherUI;
    public Canvas tutorialCanvas;
    public Text upgradeWeaponText;
    
    public int numStolen;
    public int numStolenToGiveHint = 3;

    public GameObject waveManager;
    private float timeToSpawnOriginal;

    private GameObject[] weaponStations;
    private GameObject[] towerDurStations;
    private GameObject[] playerSpeedStations;
    public GameObject player;
    public float enemySpeed;

    private bool enemiesStopped;
    private bool givenHint;

    private float timer;
    public GameObject speedButton;
    public Button startWaveButton;
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
        enemiesStopped = false;
        givenHint = false;
        //if (SceneManager.GetActiveScene().buildIndex != 5)
        //{
        //    numLarva = PlayerPrefs.GetInt("Larva");
        //}
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale == 1 && !startWaveButton.gameObject.activeSelf)
        {
            timer += Time.deltaTime;
        }

        if (timer >= 20 && !startWaveButton.gameObject.activeSelf)
        {
            speedButton.GetComponent<Scaling>().enabled = true;
        }
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

        if (numStolen >= numStolenToGiveHint && !givenHint && SceneManager.GetActiveScene().buildIndex == 3)
        {
            tutorialCanvas.gameObject.SetActive(true);
            upgradeWeaponText.gameObject.SetActive(true);
            if (!enemiesStopped)
            {
                enemieStop();
            }

            if (upgradeWeaponText.GetComponent<TextTyping>().isFinished)
            {
                tutorialCanvas.gameObject.SetActive(false);
                upgradeWeaponText.gameObject.SetActive(false);

                //numStolenToGiveHint += 2;




                foreach (GameObject station in weaponStations)
                {

                    station.GetComponent<Scaling>().enabled = true;
                    //station.GetComponent<Scaling>().OnPlay();
                }

                foreach (GameObject station in towerDurStations)
                {
                    station.GetComponent<Scaling>().enabled = true;
                    //station.GetComponent<Scaling>().OnPlay();
                }

                foreach (GameObject station in playerSpeedStations)
                {
                    station.GetComponent<Scaling>().enabled = true;
                    //station.GetComponent<Scaling>().OnPlay();
                }

                if (player.GetComponent<PlayerAttack>().hitUpgrade)
                {
                    //Debug.Log("hitupgrade");
                    foreach (GameObject station in weaponStations)
                    {
                        station.GetComponent<Scaling>().OnClose();
                    }

                    foreach (GameObject station in towerDurStations)
                    {
                        station.GetComponent<Scaling>().OnClose();
                    }

                    foreach (GameObject station in playerSpeedStations)
                    {
                        station.GetComponent<Scaling>().OnClose();
                    }
                    if (enemiesStopped)
                    {
                        enemieStart();
                    }


                    //var enemies = GameObject.FindGameObjectsWithTag("Enemy");

                    //numStolen = 0;
                }


            }

        }
    }

    private void enemieStop()
    {
        timeToSpawnOriginal = waveManager.GetComponent<tileWaveScript>().timeToSpawn;
        waveManager.GetComponent<tileWaveScript>().timeToSpawn = Mathf.Infinity;

        var enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject enemy in enemies)
        {
            enemySpeed = enemy.GetComponent<tileMovement>().moveSpeed;
            enemy.GetComponent<tileMovement>().moveSpeed = 0;
        }
        enemiesStopped = true;

    }

    private void enemieStart()
    {


        var enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject enemy in enemies)
        {
            //enemySpeed = enemy.GetComponent<tileMovement>().moveSpeed;
            enemy.GetComponent<tileMovement>().moveSpeed = enemySpeed;
        }
        waveManager.GetComponent<tileWaveScript>().timeToSpawn = timeToSpawnOriginal;
        givenHint = true;


    }

    private void tutorialOnUpgrade()
    {
        tutorialCanvas.gameObject.SetActive(true);
        upgradeWeaponText.gameObject.SetActive(true);
        timeToSpawnOriginal = waveManager.GetComponent<tileWaveScript>().timeToSpawn;
        waveManager.GetComponent<tileWaveScript>().timeToSpawn = Mathf.Infinity;
        var enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject enemy in enemies)
        {
            enemySpeed = enemy.GetComponent<tileMovement>().moveSpeed;
            enemy.GetComponent<tileMovement>().moveSpeed = 0;
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
