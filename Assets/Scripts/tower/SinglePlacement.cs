using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SinglePlacement : MonoBehaviour
{
    public Color hoverColor;
    public Vector3 standardposOffset;
    public Vector3 EMPposOffset;

    private GameObject tower;
    private Renderer rendr;
    private Color startColor;
    BuildManager buildManager;
    private SinglePlacement selectedPlacement;
    public Camera topcam;
    public Transform player;
    public GameObject nest;

    public ParticleSystem buildEffect;

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
        if (EventSystem.current.IsPointerOverGameObject())
        {
            //Debug.Log("Touched the UI");
            return;
        }
        if (tower)
        {
            SetPlacement();
        }
       
    }

    private void OnMouseDown()
    {
        //if (buildManager.GetTowerToBuild() == null)
        //{
        //    return;
        //}
        if (tower != null)
        {
            //tower.GetComponent<tower>().showMenu();
            if (EventSystem.current.IsPointerOverGameObject())
            {
                //Debug.Log("Touched the UI");
                return;
            }
            //SetPlacement();
            return;
        }
        GameObject towerToBuild = buildManager.GetTowerToBuild();
        //if (nest.GetComponent<nestScript>().numLarva >= buildCost)
        //{
        //    Debug.Log("build");
        //    nest.GetComponent<nestScript>().numLarva -= buildCost;
        //}
        if (towerToBuild == buildManager.standardTowerPrefab)
        {
            tower = (GameObject)Instantiate(towerToBuild, transform.position + standardposOffset, transform.rotation);
        }
        else if (towerToBuild == buildManager.EMPTowerPrefab)
        {
            tower = (GameObject)Instantiate(towerToBuild, transform.position + EMPposOffset, transform.rotation);
        }
        if (towerToBuild)
        {
            //Instantiate(buildEffect, transform.position+new Vector3(0, 3, 0), Quaternion.identity);
            tower.GetComponent<tower>().menu2D.GetComponent<Canvas>().worldCamera = topcam;
            tower.GetComponent<tower>().UI2D.transform.GetChild(0).GetComponent<Canvas>().worldCamera = topcam;
            tower.GetComponent<tower>().placement = this.gameObject;
            tower.GetComponent<tower>().player = player;
            tower.GetComponent<tower>().nest = nest;
            tower.GetComponent<tower>().build();
            tower.GetComponent<tower>().topcam = topcam;
        }



    }

    public void SetPlacement()
    {
        //Debug.Log("Setting placement" + this);
        if (selectedPlacement == this && tower.GetComponent<tower>().menu2D.activeSelf)
        {
            DeselectPlacement();
            return;
        }
        selectedPlacement = this;
        
        var towers = GameObject.FindGameObjectsWithTag("Tower");
        foreach (GameObject thetower in towers)
        {
            thetower.GetComponent<tower>().hideMenu();
        }
        if (tower)
        {
            tower.GetComponent<tower>().showMenu();
        }
       
    }

    public void DeselectPlacement()
    {
        selectedPlacement = null;
        tower.GetComponent<tower>().hideMenu();
    }
    void Start()
    {
        rendr = GetComponent<Renderer>();
        startColor = rendr.material.color;
        buildManager = BuildManager.instance;
    }

}
