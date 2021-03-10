using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class upgradeWeapon : MonoBehaviour
{
    // Start is called before the first frame update
    public List<GameObject> weapons;
    public List<GameObject> displays;
    public upgradeWeapon other;
    public PlayerAttack pa;
    public int offset;
    public int numOfType;
    public int index = 0;
    
    public void doUpgrade()
    {
        for(int i = 0; i < displays.Count; i++)
        {
            displays[i].SetActive(false);
        }
        if(index == 0)
        {
            for (int i = 0; i < other.displays.Count; i++)
            {
                other.displays[i].SetActive(false);
            }
            other.displays[0].SetActive(true);
            other.index = 0;
        }
        if(index < numOfType)
        {
            for (int i = 0; i < weapons.Count; i++)
            {
                weapons[i].SetActive(false);
            }
            weapons[offset + index].SetActive(true);
            pa.myWeapon = weapons[offset + index].GetComponent<Weapon>();
            index++;
            if(index < numOfType)
            {
                displays[index].SetActive(true);
            }
        }
    }
}
