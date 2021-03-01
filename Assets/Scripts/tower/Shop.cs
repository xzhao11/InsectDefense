using UnityEngine;

public class Shop : MonoBehaviour
{
    BuildManager buildManager;
    public void purchaseStandardTower()
    {
        buildManager.SetTowerToBuild(buildManager.standardTowerPrefab);
    }

    public void purchaseEMPTower()
    {
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
