using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class nestScript : MonoBehaviour
{
    public int numLarva;
    [SerializeField] TMP_Text num_msg;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        num_msg.text = "number of larva is "+ numLarva;
    }

    void decreaseLarva()
    {
        numLarva -= 1;
    }
}
