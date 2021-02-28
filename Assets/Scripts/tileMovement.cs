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
    private Vector3 startPosition;

    public Transform nest;

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
        Timer = 0;

        //Debug.Log("Path increment");

        //Debug.Log(path);
        //Debug.Log(path.transform.GetChild(curr_path));
        //Debug.Log(path.transform.GetChild(curr_path).GetChild(0));
        //Debug.Log(path.transform.GetChild(curr_path).GetChild(0).GetChild(curr_node));

        startPosition = this.transform.position;

        numNodes = path.transform.GetChild(curr_path).GetChild(0).childCount;

        dest = path.transform.GetChild(curr_path).GetChild(0).GetChild(curr_node).position;

        //Debug.Log("Start position is - " + startPosition + " and destination is - " + dest);
    }

    void incrementNode()
    {
        Timer = 0;

        //Debug.Log("Node increment");

        //Debug.Log(path);
        //Debug.Log(path.transform.GetChild(curr_path));
        //Debug.Log(path.transform.GetChild(curr_path).GetChild(0));
        //Debug.Log(path.transform.GetChild(curr_path).GetChild(0).GetChild(curr_node));

        startPosition = this.transform.position;

        dest = path.transform.GetChild(curr_path).GetChild(0).GetChild(curr_node).position;

        //Debug.Log("Start position is - " + startPosition + " and destination is - " + dest);
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
            curr_node += 1;

            if(curr_node >= numNodes)
            {
                curr_path += 1;
                curr_node = 1;

                if(curr_path >= numPaths)
                {
                    Destroy(gameObject);
                    nest.GetComponent<nestScript>().numLarva -= 1;
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
