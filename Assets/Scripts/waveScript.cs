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
            Instantiate(enemy, new Vector3(-122.6f, -13.478f, 143.75f), Quaternion.identity);
            timeLeft = downTime;
            numEnemies += 1;
        }
        else
        {
            timeLeft -= 1;
        }
    }
}
