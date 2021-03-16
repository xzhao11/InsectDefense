using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lockCursor : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Confined;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Screen.fullScreen = !Screen.fullScreen;
            Cursor.lockState = CursorLockMode.None;
        }
    }

    //void OnGUI()
    //{

    //        Cursor.lockState = CursorLockMode.Locked;


    //}
}
