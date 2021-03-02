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
        var towers = GameObject.FindGameObjectsWithTag("Tower");
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            switchKeyDown = false;
            if (thirdActive) 
            {
                thirdPerson.enabled = false;
                thirdPersonController.SetActive(false);
                GetComponent<PlayerAttack>().enabled = false;
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

                //FindObjectOfType<tower>().isTopDown = true;
                
                //foreach (GameObject thetower in towers)
                //{
                //    thetower.GetComponent<tower>().switchTopDown();
                //}



            }
            else
            {
                thirdPerson.enabled = true;
                thirdPersonController.SetActive(true);
                GetComponent<PlayerAttack>().enabled = false;
                topDown.enabled = false;
                thirdActive = true;
                GetComponent<PlayerThirdPersonControl>().enabled = true;
                GetComponent<PlayerControl>().enabled = false;
                switchKeyDown = false;

                //foreach (GameObject thetower in towers)
                //{
                //    thetower.GetComponent<tower>().switchThirdPerson();
                //}
                //FindObjectOfType<tower>().isTopDown = false;
                //GetComponent<PlayerThirdPersonControl>().enabled = true;
                //GetComponent<PlayerControl>().enabled = false;
            }
        }
    }
}
