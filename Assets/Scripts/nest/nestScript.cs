using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class nestScript : MonoBehaviour
{
    public int numLarva;
    private int numAnts = 0;
    public int numGrain = 0;
    public float twinChance = 0.25f;
    public float tripletChance = 0.25f;
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

    public void repopulate(int numWave)
    {
        int singleHatches = numLarva;
        int doubleHatches = (int)(singleHatches * Mathf.Exp(0.25f * numWave));
        int tripleHatches = (int)(doubleHatches * Mathf.Exp(0.25f * numWave));

        numAnts += singleHatches + doubleHatches + tripleHatches;
        numLarva = numAnts;
    }
}
