using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;

    private GameObject towerToBuild;
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
    }

}
