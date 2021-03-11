using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class upgradeTowerDuration : MonoBehaviour
{
    public List<GameObject> displays;
    public GameObject nest;
    public int numOfType;
    public int index = 0;

    public float durationChange = 0.25f;

    public void doUpgrade()
    {
        if(index < numOfType)
        {
            for (int i = 0; i < displays.Count; i++)
            {
                displays[i].SetActive(false);
            }
            nest.GetComponent<nestScript>().healthLossRate -= durationChange;
            index++;
            if (index < numOfType)
            {
                displays[index].SetActive(true);
            }
        }
    }

}
