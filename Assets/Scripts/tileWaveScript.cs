using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tileWaveScript : MonoBehaviour
{
    public GameObject enemy;
    public GameObject path;
    public int totalEnemies = 100;
    private int remaining;
    public float downTime = 1200f;
    private float timeToSpawn = 0f;
    private Vector3 spawn;

    // Start is called before the first frame update
    void Start()
    {
        enemy.SetActive(false);
        spawn = path.transform.GetChild(0).GetChild(0).position;
        remaining = totalEnemies;
    }

    // Update is called once per frame
    void Update()
    {
        if(timeToSpawn <= 0 && remaining != 0)
        {
            var curr_enemy = (GameObject)Instantiate(enemy, spawn, Quaternion.identity);
            curr_enemy.SetActive(true);
            remaining -= 1;
            timeToSpawn = downTime;
        }
        else
        {
            timeToSpawn -= 1;
        }
    }
}
