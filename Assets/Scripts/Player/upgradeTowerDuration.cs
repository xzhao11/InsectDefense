using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class upgradeTowerDuration : MonoBehaviour
{
    public List<GameObject> displays;
    public nestScript nest;
    public int numOfType;
    public int index = 0;

    public int price = 10;
    public int priceDiff = 0;

    public float durationChange = 0.25f;

    public void doUpgrade()
    {
        if(nest.numLarva > (price + priceDiff * index) && index < numOfType)
        {
            for (int i = 0; i < displays.Count; i++)
            {
                displays[i].SetActive(false);
            }
            nest.healthLossRate -= durationChange;
            nest.numLarva -= (price + priceDiff * index);
            index++;
            if (index < numOfType)
            {
                displays[index].SetActive(true);
            }
        }
    }

}
