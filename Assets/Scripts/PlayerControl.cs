using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class PlayerControl : MonoBehaviour
{
    [SerializeField] CharacterController controller;
    [SerializeField] float speed;

    public float turnSmoothTime = 0.1f;
    float smooth=5.0f;


    public CinemachineFreeLook vcam;
    void FixedUpdate()
    {
        //Code Source: THIRD PERSON MOVEMENT in Unity
        //https://www.youtube.com/watch?v=4HpC--2iowE&t=1002s
        float horizontal = -Input.GetAxisRaw("Horizontal");
        float vertical = -Input.GetAxisRaw("Vertical");
        Vector3 movement = new Vector3(horizontal, 0.0f, vertical).normalized;
        
        if (movement.magnitude > 0)
        {
            var delta = -transform.position;
            Quaternion targetRotation = Quaternion.LookRotation(movement);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * smooth);
            controller.Move(movement.normalized * speed * Time.deltaTime);
            vcam.m_XAxis.Value = Quaternion.Lerp(Quaternion.Euler(0, vcam.m_XAxis.Value, 0), targetRotation, Time.deltaTime * smooth).eulerAngles.y;

        }


    }
}
