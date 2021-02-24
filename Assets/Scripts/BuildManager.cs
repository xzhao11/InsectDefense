using System;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;

    private GameObject towerToBuild;
    private SinglePlacement selectedPlacement;
    public GameObject standardTowerPrefab;
    public GameObject EMPTowerPrefab;
    public GameObject GetTowerToBuild()
    {
        return towerToBuild;
    }
    void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("More than one instance of BuildNanager");
            return;
        }
        instance = this;
    }
    public void SetTowerToBuild(GameObject tower)
    {
        towerToBuild = tower;
        selectedPlacement = null;
    }

    public void SetPlacement(SinglePlacement placement)
    {
        if (selectedPlacement == placement)
        {
            DeselectPlacement();
        }
        Debug.Log("setting placement");
        selectedPlacement = placement;
        towerToBuild.GetComponent<tower>().showMenu();
        Debug.Log(towerToBuild);
        //towerToBuild = null;
    }

    public void DeselectPlacement()
    {
        Debug.Log("hiding menu");
        selectedPlacement = null;
        towerToBuild.GetComponent<tower>().hideMenu();
    }
}
