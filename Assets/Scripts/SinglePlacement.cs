using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SinglePlacement : MonoBehaviour
{
    public Color hoverColor;
    public Vector3 posOffset;

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
        tower = (GameObject)Instantiate(towerToBuild, transform.position+posOffset, transform.rotation);
    }
    void Start()
    {
        rendr = GetComponent<Renderer>();
        startColor = rendr.material.color;
        buildManager = BuildManager.instance;
    }

}
