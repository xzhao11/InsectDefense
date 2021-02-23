using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tileMovement : MonoBehaviour
{
    public GameObject path;
    private int curr_path = 0;
    private int curr_node = 0;
    private float Timer;
    public float moveSpeed;
    private int numNodes;
    private int numPaths;
    private Vector3 dest;
    private Vector2 startPosition;

    // Start is called before the first frame update
    void Start()
    {
        startPosition = this.transform.position;
        curr_node += 1;
        numNodes = path.transform.GetChild(0).GetChild(0).childCount;
        numPaths = path.transform.childCount;
        Timer = 0;
        dest = path.transform.GetChild(curr_path).GetChild(0).GetChild(curr_node).position;
    }

    void incrementPath()
    {
        curr_path += 1;
        Timer = 0;

        startPosition = dest;

        numNodes = path.transform.GetChild(curr_path).GetChild(0).childCount;
        curr_node = 0;

        dest = path.transform.GetChild(curr_path).GetChild(0).GetChild(curr_node).position;
    }

    void incrementNode()
    {
        curr_node += 1;
        Timer = 0;

        startPosition = dest;

        dest = path.transform.GetChild(curr_path).GetChild(0).GetChild(curr_node).position;
    }

    // Update is called once per frame
    void Update()
    {
        Timer += Time.deltaTime * moveSpeed;
        if(this.transform.position != dest)
        {
            this.transform.position = Vector3.Lerp(startPosition, dest, Timer);
        }
        else
        {
            if(curr_node + 1 >= numNodes)
            {
                if(curr_path + 1 >= numPaths)
                {
                    Destroy(gameObject);
                }
                else
                {
                    incrementPath();
                }
            }
            else
            {
                incrementNode();
            }
        }
    }
}
