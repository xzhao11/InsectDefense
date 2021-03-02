using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public Camera cam;
    public Weapon myWeapon;
    public LayerMask mask;

    public Transform head;

    private float attackTimer = 0.0f;
    private Ray ray;
    
    // Start is called before the first frame update
    void Start()
    {
        ray = DoAttack();
    }

    // Update is called once per frame
    void Update()
    {
        attackTimer += Time.deltaTime;
        if(Input.GetMouseButtonUp(0) && attackTimer >= myWeapon.attackCoolDown)
        {
            ray = DoAttack();
        }
        Debug.DrawRay(ray.origin, ray.direction * 100, Color.yellow);
    }

    private Ray DoAttack()
    {
        /*Vector3 orig = head.position + Vector3.Normalize(head.forward) * 0.5f;
        Vector3 dire = cam.transform.forward;
        dire.y = 0.0f;
        Ray ray = new Ray(orig, dire);*/
        Ray rayCam = Camera.main.ScreenPointToRay(Input.mousePosition);
        Vector3 orig = rayCam.origin;
        orig.y = 1.5f;
        //Vector3 orig = head.position + Vector3.Normalize(head.forward) * 0.5f;
        //orig.y = 1.0f;
        Vector3 dir = rayCam.direction;
        dir.y = 0.0f;
        orig += rayCam.direction * 2.0f;
        Ray ray = new Ray(orig, dir);

        RaycastHit hit;
        if(Physics.Raycast(ray, out hit, myWeapon.attackRange + 20f, mask))
        {
            print("Hit something!");
            if(hit.collider.tag == "Enemy")
            {
                print("Hit Enemy!");
                enemy en = hit.collider.GetComponent<enemy>();
                en.TakeDamage(myWeapon.attackDamage);
                attackTimer = 0f;
            }
        }
        return ray;
    }
}
