using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public CharacterController controller;
    public float speed;
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Code Source: THIRD PERSON MOVEMENT in Unity
        //https://www.youtube.com/watch?v=4HpC--2iowE&t=1002s
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 movement = new Vector3(horizontal, 0.0f, vertical).normalized;
        if (movement.magnitude >= 0)
        {

  


            controller.Move(movement * speed * Time.deltaTime);

        }
    }
}
