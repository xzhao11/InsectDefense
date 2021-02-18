using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class enemyMovement : MonoBehaviour
{

    public int health = 200;
    [SerializeField] Transform player;
    //[SerializeField] TMP_Text health_msg;
    //[SerializeField] TMP_Text hit_msg;
    [SerializeField] float hitDistance = 30f;

    private void Start()
    {
        //hit_msg.gameObject.SetActive(false);
    }
    void Update()
    {
        //health_msg.text = "Health : " + health;

        if (health <= 0 && gameObject)
        {
            //Debug.Log("enemy down");
            //health_msg.text = "Enemy Down";
            Destroy(gameObject);
        }

    }
    private void OnMouseDown()
    {
        if((player.position-transform.position).magnitude <= hitDistance)
        {
            Debug.Log("I hit you");
            health -= 5;
            //hit_msg.gameObject.SetActive(true);
        }
        
    }
    private void OnMouseUp()
    {
        //hit_msg.gameObject.SetActive(false);
    }
}
