using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SinglePlacement : MonoBehaviour
{
    public Color hoverColor;
    public Vector3 standardposOffset;
    public Vector3 EMPposOffset;

    private GameObject tower;
    private Renderer rendr;
    private Color startColor;
    BuildManager buildManager;
    private void OnMouseEnter()
    {
        if (buildManager.GetTowerToBuild() == null)
        {
            return;
        }
        rendr.material.color = hoverColor;
    }

    private void OnMouseExit()
    {
        rendr.material.color = startColor;
    }

    private void OnMouseDown()
    {
        if (buildManager.GetTowerToBuild() == null)
        {
            return;
        }
        if (tower != null)
        {
            Debug.Log("there is tower on this placement");
            return;
        }
        GameObject towerToBuild = buildManager.GetTowerToBuild();
        if (towerToBuild == buildManager.standardTowerPrefab)
        {
            tower = (GameObject)Instantiate(towerToBuild, transform.position + standardposOffset, transform.rotation);
        }
        else if (towerToBuild == buildManager.EMPTowerPrefab)
        {
            tower = (GameObject)Instantiate(towerToBuild, transform.position + EMPposOffset, transform.rotation);
        }

    }
    void Start()
    {
        rendr = GetComponent<Renderer>();
        startColor = rendr.material.color;
        buildManager = BuildManager.instance;
    }

}
