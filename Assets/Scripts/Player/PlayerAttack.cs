using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class PlayerAttack : MonoBehaviour
{
    public Camera cam;
    public Weapon myWeapon;
    public LayerMask mask;
    public Animator character;
    //public GameObject pivot;

    public Transform head;

    public AudioSource attack;
    public AudioSource repair;
    public AudioSource upgrade;
    public AudioSource whiff;

    private float attackTimer = 0.0f;
    private Ray ray;

    public bool hitUpgrade = false;
    // Start is called before the first frame update
    void Start()
    {
        //ray = DoAttack();
    }

    // Update is called once per frame
    void Update()
    {
        attackTimer += Time.deltaTime;
        /*if(attackTimer <= 0.2f)
        {
            pivot.transform.Rotate(360*Time.deltaTime, 0f, 0f, Space.Self);
        }
        else if(attackTimer <= 0.4f)
        {
            pivot.transform.Rotate(-360 * Time.deltaTime, 0f, 0f, Space.Self);
        }*/
        if (EventSystem.current.IsPointerOverGameObject())
        {
            //Debug.Log("Touched the UI");
            return;
        }
        if (character.GetBool("isAttacking") && attackTimer > 1.0f)
        {
            character.SetBool("isAttacking", false);
        }
        if(Input.GetMouseButtonUp(0) && attackTimer >= myWeapon.attackCoolDown)
        {
            character.SetBool("isAttacking", false);
            ray = DoAttack();
            attackTimer = 0f;
        }
        Debug.DrawRay(ray.origin, ray.direction * myWeapon.attackRange, Color.yellow);
    }

    private Ray DoAttack()
    {
        /*Vector3 orig = head.position + Vector3.Normalize(head.forward) * 0.5f;
        Vector3 dire = cam.transform.forward;
        dire.y = 0.0f;
        Ray ray = new Ray(orig, dire);*/
        //Ray rayCam = Camera.main.ScreenPointToRay(Input.mousePosition);
        Vector3 orig = head.position;
        orig.y = 1.5f;
        //Vector3 orig = head.position + Vector3.Normalize(head.forward) * 0.5f;
        //orig.y = 1.0f;
        //Vector3 dir = transform.position - cam.transform.position;
        Vector3 dir = head.forward;
        dir.y = 0.0f;
        //dir = Vector3.Normalize(dir);
        //orig += dir * 0.5f;
        Ray ray = new Ray(orig, dir);

        RaycastHit hit;
        if(Physics.Raycast(ray, out hit, myWeapon.attackRange, mask))
        {
            //print("Hit something!");
            if(hit.collider.tag == "Enemy")
            {
                print("Hit Enemy!");
                enemy en = hit.collider.GetComponent<enemy>();
                en.TakeDamage(myWeapon.attackDamage);
                attack.Play();
            }
            else if (hit.collider.tag == "Tower")
            {
                print("Hit Tower!");
                tower to= hit.collider.GetComponent<tower>();
                to.repair(myWeapon.repairAmount);
                repair.Play();
            }
            else if(hit.collider.tag == "UpgradeWeapon")
            {
                print("Hit Weapon Upgrade!");
                hitUpgrade = true;
                upgradeWeapon up = hit.collider.GetComponent<upgradeWeapon>();
                up.doUpgrade();
                upgrade.Play();
            }
            else if (hit.collider.tag == "UpgradeTowerDuration")
            {
                print("Hit Tower Regen Upgrade!");
                hitUpgrade = true;
                upgradeTowerDuration up = hit.collider.GetComponent<upgradeTowerDuration>();
                up.doUpgrade();
                upgrade.Play();
            }
            else if (hit.collider.tag == "UpgradePlayerSpeed")
            {
                print("Hit Player Speed Upgrade!");
                hitUpgrade = true;
                upgradePlayerSpeed up = hit.collider.GetComponent<upgradePlayerSpeed>();
                up.doUpgrade();
                upgrade.Play();
            }
            else
            {
                whiff.Play();
            }

        }
        else
        {
            whiff.Play();
        }
        character.SetBool("isAttacking", true);
        return ray;
    }
}
