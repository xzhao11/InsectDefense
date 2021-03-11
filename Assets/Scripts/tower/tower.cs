﻿
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class tower : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform target;

    [Header("Attibutes")]
    public float range = 30f;
    [SerializeField] float _shootDelay = 0.2f;
    public float health = 60.0f;
    public float startHealth = 60.0f;
    public bool isBroken;
    [SerializeField] ParticleSystem shootEffects;
    public int repairCost = 1;
    public int upgradeCost = 10;
    public int buildCost = 20;
    private int towerValue = 0;
    public float damage = 2f;
    int numUpgrades = 0;
    public int towerType = 0;

    public AudioSource shootingSound;
    [Header("Unity Setup")]
    public GameObject nest;
    public string enemyTag = "Enemy";
    public float rotateSpeed = 10f;
    [SerializeField] Transform partToRotate;
    private float _nextShootTime;

    [SerializeField] Transform _bulletPrefab;
    [SerializeField] Transform _shootPoint;

    [SerializeField] Image healthBar3D;
    [SerializeField] Image healthBar2D;
    public GameObject UI3D;
    public GameObject UI2D;
    //public GameObject menu3D;
    public GameObject menu2D;
    private Transform repairButton;
    private Transform upgradeButton;
    private Transform sellButton;
    private GameObject levelUI;
    private int level;
    public bool isTopDown;
    //public GameObject menu;

    public GameObject placement;
    public Transform player;
    



    public GameObject partToChangeColor;
    private Color[] colors = new Color[7];
    private int curColor;
    Renderer colorRenderer;


    void Start()
    {
        towerValue += buildCost;
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
        startHealth = health;
        isBroken = false;
        //menu = menu2D;
        //menu3D.SetActive(false);
        menu2D.SetActive(false);
        UI2D.SetActive(false);

        Transform buttons = menu2D.transform.GetChild(0);
        repairButton = buttons.GetChild(0);
        upgradeButton = buttons.GetChild(1);
        sellButton = buttons.GetChild(2);
        levelUI = menu2D.transform.GetChild(1).gameObject;
        level = 1;
        
        colors[0] = new Color(255f / 255f, 255f / 255f, 255f / 255f, 1);
        colors[1] = new Color(141f / 255f, 238f / 255f, 255f / 255f, 0.5f);
        colors[2] = new Color(141f / 255f, 255f / 255f, 155f / 255f, 0.5f);
        colors[3] = new Color(255f / 255f, 238f / 255f, 141f / 255f, 0.5f);
        colors[4] = new Color(255f / 255f, 153f / 255f, 141f / 255f, 0.5f);
        colors[5] = new Color(255f / 255f, 141f / 255f, 227f / 255f, 0.5f);
        colors[6] = new Color(180f / 255f, 241f / 255f, 255f / 255f, 0.5f);
        colorRenderer = partToChangeColor.GetComponent<Renderer>();
        curColor = 0;
        colorRenderer.material.SetColor("_Color", colors[0]);

    }

    void FixedUpdate()
    {
        if (target)
        {
            Vector3 direction = target.position - _shootPoint.position;
            Gunfiring(direction);
            health -= nest.GetComponent<nestScript>().healthLossRate * Time.deltaTime;
            healthBar3D.fillAmount = health / startHealth;
            healthBar2D.fillAmount = health / startHealth;
        }
        else
        {
            shootingSound.Stop();
        }

        if (health <= 0)
        {
            isBroken = true;
        }

        if (!FindObjectOfType<CameraSwitch>().thirdActive)
        {
            switchTopDown();
        }
        else
        {
            switchThirdPerson();
        }
        repairButton.GetComponentInChildren<Text>().text = "Repair\n" + repairCost;
        upgradeButton.GetComponentInChildren<Text>().text = "Upgrade\n" + upgradeCost;
        sellButton.GetComponentInChildren<Text>().text = "Sell\n" + (int)(0.5 * towerValue);
        colorRenderer.material.SetColor("_Color", colors[curColor]);
        levelUI.GetComponentInChildren<Text>().text = "Level " + level;
    }

    private void Gunfiring(Vector3 direction)
    {
        if (!direction.Equals(Vector3.zero) && CanShoot() &&!isBroken)
        {
            //Debug.Log("shooting");
            Transform bulletTransform = Instantiate(_bulletPrefab, _shootPoint.position, _shootPoint.rotation);
            
            bulletTransform.GetComponent<Bullet>().Setup(direction, (float)((damage / 3) * (1 + 2 * health / startHealth)));
            _nextShootTime = Time.time + _shootDelay;
            if (shootEffects)
            {
                shootEffects.Play();
            }
            if (!shootingSound.isPlaying)
            {
                shootingSound.Play(0);
            }

        }
        else
        {
            shootingSound.Stop();
        }
    }

    private bool CanShoot()
    {
        return Time.time > _nextShootTime;
    }

    private void updateUpgradeCost()
    {
        numUpgrades += 1;
        upgradeCost = (int)(10 * Mathf.Exp(0.25f * numUpgrades));
        towerValue += upgradeCost;
    }

    private void updateDamage()
    {
        damage = 2f * Mathf.Exp(0.15f * numUpgrades);
    }

    private void updateShootDelay()
    {
        _shootDelay = 0.2f * 1/Mathf.Exp(0.5f * numUpgrades);
    }

    private void updateTowerHealth()
    {
        if (towerType == 0)
        {
            health = 25f * Mathf.Exp(0.15f * numUpgrades);
        }
        else
        {
            health = 40f * Mathf.Exp(0.35f * numUpgrades);
        }
        
        startHealth = health;
    }

    void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortest = Mathf.Infinity;
        GameObject nearest = null;
        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < shortest)
            {
                shortest = distanceToEnemy;
                nearest = enemy;
            }
        }
        if (nearest!=null && shortest <= range)
        {
            target = nearest.transform;
        }
        else
        {
            target = null;
        }
    }

    void Update()
    {
        if (target == null)
            return;

        Vector3 dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime * rotateSpeed).eulerAngles;
        if (partToRotate && !isBroken)
        {
            partToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);
        }
        

    }

    public void OnMouseDown()
    {
        //Debug.Log("clicked tower");
        if (EventSystem.current.IsPointerOverGameObject())
        {
            //Debug.Log("Touched the UI");
            return;
        }
        placement.GetComponent<SinglePlacement>().SetPlacement();
    }

        public void showMenu()
    {
        menu2D.SetActive(true);
    }


    public void hideMenu()
    {
        menu2D.SetActive(false);
    }

    public void switchTopDown()
    {
        if (menu2D.activeSelf)
        {
            menu2D.SetActive(true);
        }
        //menu3D.SetActive(false);
        UI2D.SetActive(true);
        UI3D.SetActive(false);

    }
    public void switchThirdPerson()
    {
        
        menu2D.SetActive(false);
        UI2D.SetActive(false);
        UI3D.SetActive(true);
        UI3D.transform.rotation = Quaternion.LookRotation(transform.position - player.position);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }

    public void repair(float repairAmount)
    {
        health += repairAmount;
        if (health > startHealth) health = startHealth;
        Debug.Log("repair");
        isBroken = false;
    }
    /*public void repair()
    {
        if(nest.GetComponent<nestScript>().numGrain >= repairCost)
        {
            health = startHealth;
            Debug.Log("repair");
            isBroken = false;
            nest.GetComponent<nestScript>().numGrain -= repairCost;
        }
    }*/

    public void sell()
    {
        Debug.Log("sell");
        Destroy(gameObject);
        nest.GetComponent<nestScript>().numLarva += (int)(0.5 * towerValue);
    }

    public void upgrade()
    {
        if(nest.GetComponent<nestScript>().numLarva >= upgradeCost)
        {
            Debug.Log("upgrade");
            nest.GetComponent<nestScript>().numLarva -= upgradeCost;

            updateUpgradeCost();
            updateDamage();
            if (curColor == colors.Length - 1)
            {
                curColor = 0;
            }
            else
            {
                curColor++;
            }
            Debug.Log(colors[curColor]);


            if (towerType == 0)
            {
                updateDamage();
            }
            else if (towerType == 1)
            {
                updateShootDelay();
            }
            level++;

            updateTowerHealth();

            repairCost++;
        }
    }


    public void build()
    {
        if(nest.GetComponent<nestScript>().numLarva >= buildCost)
        {
            Debug.Log("build");
            nest.GetComponent<nestScript>().numLarva -= buildCost;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
