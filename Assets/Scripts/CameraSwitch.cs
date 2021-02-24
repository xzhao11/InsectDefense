using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitch : MonoBehaviour
{
    public Camera thirdPerson;
    public Camera topDown;
    public GameObject thirdPersonController;
    public bool thirdActive;
    public bool switchKeyDown = false;
    
    // Start is called before the first frame update
    void Start()
    {
        thirdPerson.enabled = true;
        thirdPersonController.SetActive(true);
        topDown.enabled = false;
        thirdActive = true;
        GetComponent<PlayerThirdPersonControl>().enabled = true;
        GetComponent<PlayerControl>().enabled = false;

    }

    // Update is called once per frame
    void Update()
    {
        if(switchKeyDown == true)
        {
            float horizontal = -Input.GetAxisRaw("Horizontal");
            float vertical = -Input.GetAxisRaw("Vertical");
            if (horizontal == 0 && vertical == 0)
            {
                GetComponent<PlayerThirdPersonControl>().enabled = false;
                GetComponent<PlayerControl>().enabled = true;
                switchKeyDown = false;
            }
        }
        if(Input.GetKeyDown(KeyCode.LeftShift))
        {
            switchKeyDown = false;
            if (thirdActive) 
            {
                thirdPerson.enabled = false;
                thirdPersonController.SetActive(false);
                topDown.enabled = true;
                thirdActive = false;
                float horizontal = -Input.GetAxisRaw("Horizontal");
                float vertical = -Input.GetAxisRaw("Vertical");
                if (horizontal == 0 && vertical == 0)
                {
                    GetComponent<PlayerThirdPersonControl>().enabled = false;
                    GetComponent<PlayerControl>().enabled = true;
                    switchKeyDown = false;
                }
                else
                {
                    switchKeyDown = true;
                }

            }
            else
            {
                thirdPerson.enabled = true;
                thirdPersonController.SetActive(true);
                topDown.enabled = false;
                thirdActive = true;
                //float horizontal = -Input.GetAxisRaw("Horizontal");
                //float vertical = -Input.GetAxisRaw("Vertical");
                //if (horizontal == 0 && vertical == 0)
                //{
                //    GetComponent<PlayerThirdPersonControl>().enabled = true;
                //    GetComponent<PlayerControl>().enabled = false;
                //    switchKeyDown = false;
                //}
                //else
                //{
                //    switchKeyDown = true;
                //}
     
                GetComponent<PlayerThirdPersonControl>().enabled = true;
                GetComponent<PlayerControl>().enabled = false;
            }
        }
    }
}
