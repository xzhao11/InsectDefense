using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class enemy : MonoBehaviour
{

    public float health = 30f;
    public float startHealth;
    public Transform nest;
    public Transform player;
    //[SerializeField] float hitDistance = 30f;
    [SerializeField] Image healthBar;

    private void Start()
    {
        startHealth = health;
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
    /*private void OnMouseDown()
    {
        if((player.position-transform.position).magnitude <= hitDistance)
        {
            Debug.Log("I hit you");
            health -= 5;
        }
        
    }
    private void OnMouseUp()
    {
    }*/
    public void TakeDamage(float damage)
    {
        health -= damage;
    }

    void FixedUpdate()
    {
        healthBar.fillAmount = health / startHealth;
    }
}
