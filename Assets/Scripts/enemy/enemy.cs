using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class enemy : MonoBehaviour
{

    public float health = 30f;
    public float startHealth;
    public int value = 1;
    public Transform nest;
    public Transform player;
    public GameObject wave;
    //[SerializeField] float hitDistance = 30f;
    [SerializeField] Image healthBar;
    [SerializeField] ParticleSystem diedEffect;
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
            wave.GetComponent<tileWaveScript>().decrementRemaining();
            Debug.Log(nest);
            Debug.Log(value);
            Debug.Log(nest.GetComponent<nestScript>().numGrain);
            nest.GetComponent<nestScript>().numGrain += value;
            Instantiate(diedEffect, transform.position+new Vector3(0, 1, 0), Quaternion.identity);
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
