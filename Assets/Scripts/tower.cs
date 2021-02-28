
using UnityEngine;
using UnityEngine.UI;
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
    [Header("Unity Setup")]
    
    public string enemyTag = "Enemy";
    public float rotateSpeed = 10f;
    [SerializeField] Transform partToRotate;
    private float _nextShootTime;
    [SerializeField] Transform UI;

    [SerializeField] Transform _bulletPrefab;
    [SerializeField] Transform _shootPoint;

    [SerializeField] Image healthBar;
    public GameObject UI3D;
    public GameObject UI2D;
    public GameObject menu3D;
    public GameObject menu2D;
    public bool isTopDown;
    public GameObject menu;


    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
        startHealth = health;
        isBroken = false;
        menu = menu3D;
        menu3D.SetActive(false);
        menu2D.SetActive(false);
        UI2D.SetActive(false);
    }

    void FixedUpdate()
    {
        if (target)
        {
            Vector3 direction = target.position - _shootPoint.position;
            Gunfiring(direction);
            health -= Time.deltaTime;
            healthBar.fillAmount = health / startHealth;
        }
        if (health <= 0)
        {
            isBroken = true;
        }




    }

    private void Gunfiring(Vector3 direction)
    {
        if (!direction.Equals(Vector3.zero) && CanShoot() &&!isBroken)
        {
            //Debug.Log("shooting");
            Transform bulletTransform = Instantiate(_bulletPrefab, _shootPoint.position, _shootPoint.rotation);
            bulletTransform.GetComponent<Bullet>().Setup(direction);
            _nextShootTime = Time.time + _shootDelay;
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

    public void showMenu()
    {
        menu.SetActive(true);
    }


    public void hideMenu()
    {
        menu.SetActive(false);
    }

    public void switchTopDown()
    {
        if (menu.activeSelf)
        {
            menu2D.SetActive(true);
        }
        menu = menu2D;
        menu3D.SetActive(false);
        UI2D.SetActive(true);
        UI3D.SetActive(false);
    }
    public void switchThirdPerson()
    {
        
        if (menu.activeSelf)
        {
            menu3D.SetActive(true);
        }
        menu = menu3D;
        menu2D.SetActive(false);
        UI2D.SetActive(false);
        UI3D.SetActive(true);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }

    public void repair()
    {
        health = startHealth;
        isBroken = false;
    }

    public void sell()
    {
        Destroy(gameObject);
    }

    public void upgrade()
    {
        Debug.Log("upgrade");
    }
}
