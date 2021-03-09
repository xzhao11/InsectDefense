
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
    private bool isBroken;
    [SerializeField] ParticleSystem shootEffects;
    public int repairCost = 1;
    public int upgradeCost = 10;
    public int sellCost = -5;
    public int buildCost = 20;
    public int damage = 2;

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
        colors[0]= new Color(255f / 255f, 255f / 255f, 255f / 255f, 1);
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
            health -= Time.deltaTime;
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
        sellButton.GetComponentInChildren<Text>().text = "Sell\n" + sellCost;
        colorRenderer.material.SetColor("_Color", colors[curColor]);

    }

    private void Gunfiring(Vector3 direction)
    {
        if (!direction.Equals(Vector3.zero) && CanShoot() &&!isBroken)
        {
            //Debug.Log("shooting");
            Transform bulletTransform = Instantiate(_bulletPrefab, _shootPoint.position, _shootPoint.rotation);
            bulletTransform.GetComponent<Bullet>().Setup(direction, damage);
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

    public void repair()
    {
        health = startHealth;
        Debug.Log("repair");
        isBroken = false;
        nest.GetComponent<nestScript>().numLarva -= repairCost;
    }

    public void sell()
    {
        Debug.Log("sell");
        Destroy(gameObject);
        nest.GetComponent<nestScript>().numLarva -= sellCost;
    }

    public void upgrade()
    {
        Debug.Log("upgrade");
        nest.GetComponent<nestScript>().numLarva -= upgradeCost;
        if (curColor == colors.Length - 1)
        {
            curColor = 0;
        }
        else
        {
            curColor++;
        }
        Debug.Log(colors[curColor]);
    }


    public void build()
    {
        nest.GetComponent<nestScript>().numLarva -= buildCost;
    }
}
