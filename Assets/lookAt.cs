using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lookAt : MonoBehaviour
{
    public GameObject player;
    public float mindistance=30;
    public float distance = 30;

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        distance = (player.transform.position - transform.position).magnitude;
        if ( distance >= mindistance)
        {
            gameObject.transform.LookAt(player.transform);
        }
       
    }
}
