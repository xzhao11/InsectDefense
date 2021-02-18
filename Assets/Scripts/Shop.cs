using UnityEngine;

public class Shop : MonoBehaviour
{
    BuildManager buildManager;
    public void purchaseStandardTower()
    {
        Debug.Log("Purchased Standard Tower");
        buildManager.SetTowerToBuild(buildManager.standardTowerPrefab);
    }

    public void purchaseEMPTower()
    {
        Debug.Log("Purchased EMP Tower");
        buildManager.SetTowerToBuild(buildManager.EMPTowerPrefab);
    }
    void Start()
    {
        buildManager = BuildManager.instance;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
