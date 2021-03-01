using UnityEngine;
using Cinemachine;

public class ThirdCameraControl : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        CinemachineCore.GetInputAxis = GetAxisCustom;
    }

    private float GetAxisCustom(string axisName)
    {
        if (axisName == "Mouse X")
        {
            if (Input.GetKey(KeyCode.Escape))
            {
                return 0 ;
            }
            else
            {
                return UnityEngine.Input.GetAxis("Mouse X");
            }
        }
        return UnityEngine.Input.GetAxis(axisName);
    }



}
