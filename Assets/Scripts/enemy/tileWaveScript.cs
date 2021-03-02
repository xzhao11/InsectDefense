﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tileWaveScript : MonoBehaviour
{
    public GameObject enemy;
    public GameObject path;
    public int totalEnemies = 100;
    public int remaining;
    public float downTime = 1200f;
    private float timeToSpawn = 0f;
    private Vector3 spawn;
    public Transform nest;
    public GameObject player;
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
        if(timeToSpawn <= 0 && remaining != 0 && Time.timeScale == 1)
        {
            var curr_enemy = (GameObject)Instantiate(enemy, spawn, Quaternion.identity);
            curr_enemy.SetActive(true);
            curr_enemy.GetComponent<tileMovement>().path = path;
            curr_enemy.GetComponent<tileMovement>().nest = nest;
            //curr_enemy.GetComponent<enemy>().nest = nest.transform;
            curr_enemy.GetComponent<enemy>().health = 20;
            curr_enemy.GetComponent<enemy>().player = player.transform;
            remaining -= 1;
            timeToSpawn = downTime;
        }
        else
        {
            timeToSpawn -= 1;
        }
    }
}
