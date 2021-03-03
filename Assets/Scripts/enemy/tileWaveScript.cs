using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tileWaveScript : MonoBehaviour
{
    public GameObject[] enemies;
    public GameObject[] paths;
    public int totalEnemies = 100;
    public int remaining;
    public float downTime = 1200f;
    private float timeToSpawn = 0f;
    private Vector3[] spawns;
    public Transform nest;
    public GameObject player;
    private int num = 0;
    private int whichPath = 0;

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
    }

    // Update is called once per frame
    void Update()
    {
        if(timeToSpawn <= 0 && remaining != 0 && Time.timeScale >0)
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
            num++;
            whichPath++;
        }
        else
        {
            timeToSpawn -= 1;
        }
    }

    public void decrementRemaining()
    {
        remaining -= 1;
    }
}
