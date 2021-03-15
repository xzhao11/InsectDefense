using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class upgradeWeapon : MonoBehaviour
{
    // Start is called before the first frame update
    public List<GameObject> weapons;
    public List<GameObject> displays;
    public GameObject descriptionGood;
    public GameObject descriptionBad;
    public GameObject cost;
    public ParticleSystem particles;
    public GameObject audioS;

    public nestScript nest;
    public upgradeWeapon other;
    public PlayerAttack pa;
    public int offset;
    public int numOfType;
    public int index = 0;

    public int price = 10;
    public int priceDiff = 0;

    void Start()
    {
        cost.GetComponent<TMPro.TextMeshPro>().text = "-" + price.ToString() + " Larva";
    }

    public void doUpgrade()
    {
        if (nest.numLarva > (price + priceDiff * index))
        {
            for (int i = 0; i < displays.Count; i++)
            {
                displays[i].SetActive(false);
            }
            descriptionGood.SetActive(false);
            descriptionBad.SetActive(false);
            audioS.SetActive(false);
            cost.SetActive(false);
            if (index == 0)
            {
                for (int i = 0; i < other.displays.Count; i++)
                {
                    other.displays[i].SetActive(false);
                }
                other.displays[0].SetActive(true);
                other.descriptionBad.SetActive(true);
                other.index = 0;
            }
            if (index < numOfType)
            {
                nest.numLarva -= (price + priceDiff * index);
                for (int i = 0; i < weapons.Count; i++)
                {
                    weapons[i].SetActive(false);
                }
                weapons[offset + index].SetActive(true);
                audioS.SetActive(true);
                pa.myWeapon = weapons[offset + index].GetComponent<Weapon>();
                index++;
                particles.Play();
                if (index < numOfType)
                {
                    displays[index].SetActive(true);
                    descriptionGood.SetActive(true);
                    cost.SetActive(true);
                    cost.GetComponent<TMPro.TextMeshPro>().text = "-" + (price).ToString() + " Larva";
                }
            }
        }
    }
}
