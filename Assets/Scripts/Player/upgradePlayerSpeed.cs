using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class upgradePlayerSpeed : MonoBehaviour
{
    public List<GameObject> displays;
    public GameObject player;
    public int numOfType;
    public int index = 0;

    public float speedUp = 10;

    public void doUpgrade()
    {
        if (index < numOfType)
        {
            for (int i = 0; i < displays.Count; i++)
            {
                displays[i].SetActive(false);
            }
            player.GetComponent<PlayerControl>().speed += speedUp;
            index++;
            if (index < numOfType)
            {
                displays[index].SetActive(true);
            }
        }
    }
}
