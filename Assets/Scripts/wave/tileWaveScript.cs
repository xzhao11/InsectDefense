using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class tileWaveScript : MonoBehaviour
{
    public GameObject[] enemies;
    public GameObject[] paths;
    public int totalEnemies = 100;
    public int remaining;
    public int toSpawn;
    public float downTime = 1200f;
    private float timeToSpawn = 0f;
    private Vector3[] spawns;
    public Transform nest;
    public GameObject player;
    private int num = 0;
    private int whichPath = 0;
    public int numWaves = 1;
    public int finishedWaves = 0;

    public Button startWaveButton;

    // Start is called before the first frame update
    void Start()
    {
        spawns = new Vector3[paths.Length];

        for (int i = 0; i < enemies.Length; i++)
        {
            enemies[i].SetActive(false);
        }
        for (int j = 0; j < paths.Length; j++)
        {
            Debug.Log(paths[j]);
            spawns[j] = paths[j].transform.GetChild(0).GetChild(0).position;
        }

        remaining = totalEnemies;
        toSpawn = totalEnemies;
        timeToSpawn = Mathf.Infinity;
    }

    public void newWave()
    {
        if (finishedWaves != numWaves)
        {
            finishedWaves++;
            remaining = totalEnemies;
            toSpawn = totalEnemies;
            num = 0;
            whichPath = 0;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(timeToSpawn <= 0 && toSpawn != 0 && Time.timeScale >0)
        {
            num = num % enemies.Length;
            whichPath = whichPath % paths.Length;

            var curr_enemy = (GameObject)Instantiate(enemies[num], spawns[whichPath], Quaternion.identity);
            curr_enemy.SetActive(true);
            curr_enemy.GetComponent<tileMovement>().path = paths[whichPath];
            curr_enemy.GetComponent<tileMovement>().nest = nest;
            //curr_enemy.GetComponent<enemy>().nest = nest.transform;
            curr_enemy.GetComponent<enemy>().health = 20;
            curr_enemy.GetComponent<enemy>().player = player.transform;
            curr_enemy.GetComponent<enemy>().wave = GameObject.FindGameObjectsWithTag("Wave")[0];

            timeToSpawn = downTime;
            toSpawn -= 1;
            num++;
            whichPath++;
        }
        else if(toSpawn != 0)
        {
            timeToSpawn -= 1;
        }
    }

    public void startWave()
    {
        timeToSpawn = 0;
        startWaveButton.gameObject.SetActive(false);
    }

    public void decrementRemaining()
    {
        remaining -= 1;
    }
}
