using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerThirdPersonControl : MonoBehaviour
{
    public CharacterController controller;
    //Animator animator;
    

    [SerializeField] float speed = 5f;
    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;
    private float gravity;
    [SerializeField] float groundY = 3;

    public Transform cam;
    public Vector3 moveDir;
    

    //AudioSource step;
    void Start()
    {
        //isThirdPerson = GetComponent<CheckCamera>().isThirdPerson;
    }

    void Update()
    {
        //Code Source: THIRD PERSON MOVEMENT in Unity
        //https://www.youtube.com/watch?v=4HpC--2iowE&t=1002s
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        gravity -= (float)9.81 * Time.deltaTime;
        if (transform.position.y == groundY)
        {
            gravity = 0.0f;
        }
        else
        {
            Vector3 down = new Vector3(0, gravity, 0);
            controller.Move(down);
        }
        
        Vector3 movement = new Vector3(horizontal, 0.0f, vertical).normalized;
        if (movement.magnitude >= 0.1f)
        {

            float targetAngle = Mathf.Atan2(movement.x, movement.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;

            controller.Move(moveDir.normalized * speed * (Time.deltaTime * (1 / Time.timeScale)));

        }
    }
}
