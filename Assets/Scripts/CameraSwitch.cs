using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitch : MonoBehaviour
{
    public Camera thirdPerson;
    public Camera topDown;
    public bool thirdActive;
    
    // Start is called before the first frame update
    void Start()
    {
        thirdPerson.enabled = true;
        topDown.enabled = false;
        thirdActive = true;
        GetComponent<PlayerThirdPersonControl>().enabled = true;
        GetComponent<PlayerControl>().enabled = false;

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.LeftShift))
        {
            if (thirdActive) 
            {
                thirdPerson.enabled = false;
                topDown.enabled = true;
                thirdActive = false;
                GetComponent<PlayerThirdPersonControl>().enabled = false;
                GetComponent<PlayerControl>().enabled = true;
            }
            else
            {
                thirdPerson.enabled = true;
                topDown.enabled = false;
                thirdActive = true;
                GetComponent<PlayerThirdPersonControl>().enabled = true;
                GetComponent<PlayerControl>().enabled = false;
            }
        }
    }
}
