using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waveScript : MonoBehaviour
{
    public int numEnemies = 0;
    public int totalEnemies;
    public float downTime = 60f;
    public GameObject enemy;
    private float timeLeft;
    public GameObject nest;
    public GameObject player;
    public Transform spawn;

    // Start is called before the first frame update
    void Start()
    {
        timeLeft = downTime;
    }

    // Update is called once per frame
    void Update()
    {
        if(timeLeft <= 0 && numEnemies < totalEnemies)
        {
            var enemynow = (GameObject)Instantiate(enemy, spawn.position, Quaternion.identity);
            enemynow.GetComponent<enemyMovement>().nest = nest.transform; 
            enemynow.GetComponent<enemyMovement>().health = 20;
            enemynow.GetComponent<enemyMovement>().player = player.transform;
            enemynow.GetComponent<enemyPath>().eggs = nest.transform;
            timeLeft = downTime;
            numEnemies += 1;
        }
        else
        {
            timeLeft -= 1;
        }
    }
}
