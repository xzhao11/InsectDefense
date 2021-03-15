using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class upgradePlayerSpeed : MonoBehaviour
{
    public List<GameObject> displays;
    public GameObject description;
    public GameObject cost;
    public ParticleSystem particles;
    public GameObject player;
    public nestScript nest;
    public int index = 0;

    public GameObject audioS;

    public int price = 10;
    public int priceDiff = 0;

    public float speedUp = 10;

    void Start()
    {
        cost.GetComponent<TMPro.TextMeshPro>().text = "-" + price.ToString() + " Larva";
    }
    public void doUpgrade()
    {
        if (nest.numLarva > (price + priceDiff * index) && index < displays.Count)
        {
            for (int i = 0; i < displays.Count; i++)
            {
                displays[i].SetActive(false);
            }
            description.SetActive(false);
            cost.SetActive(false);
            audioS.SetActive(true);
            player.GetComponent<PlayerControl>().speed += speedUp;
            player.GetComponent<PlayerThirdPersonControl>().speed += speedUp;
            nest.numLarva -= (price + priceDiff * index);
            index++;
            particles.Play();
            if (index < displays.Count)
            {
                displays[index].SetActive(true);
                description.SetActive(true);
                cost.SetActive(true);
                cost.GetComponent<TMPro.TextMeshPro>().text = "-" + (price).ToString() + " Larva";
            }

        }
        else
        {
            audioS.SetActive(false);
        }
    }
}
