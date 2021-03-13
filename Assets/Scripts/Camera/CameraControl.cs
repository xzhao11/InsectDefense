using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public GameObject player;
    Vector3 offset;
    // change this value to get desired smoothness
    public float SmoothTime = 0.3f;
    // This value will change at the runtime depending on target movement. Initialize with zero vector.
    private Vector3 velocity = Vector3.zero;
    public Camera cam;
    public float ScollSpeed;
    public float maxSize;
    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - player.transform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 targetPosition = player.transform.position + offset;
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, SmoothTime);

        if (cam.orthographic)
        {
            if (cam.orthographicSize < maxSize)
            {
                cam.orthographicSize -= Input.GetAxis("Mouse ScrollWheel") * ScollSpeed;
            }
           
        }
    }
}


//cam.orthographicSize -= .1f;