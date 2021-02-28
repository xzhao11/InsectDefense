using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class enemy : MonoBehaviour
{

    public int health = 200;
    public Transform nest;
    public Transform player;
    [SerializeField] float hitDistance = 30f;

    private void Start()
    {
    }
    void Update()
    {

        if (health <= 0 && gameObject)
        {
            //Debug.Log("enemy down");
            //health_msg.text = "Enemy Down";
            Destroy(gameObject);

        }
        //if ((nest.position - transform.position).magnitude <= 0.1)
        //{
        //    nest.GetComponent<nestScript>().numLarva -= 1;
        //}

    }
    private void OnMouseDown()
    {
        if((player.position-transform.position).magnitude <= hitDistance)
        {
            Debug.Log("I hit you");
            health -= 5;
        }
        
    }
    private void OnMouseUp()
    {
    }
}
