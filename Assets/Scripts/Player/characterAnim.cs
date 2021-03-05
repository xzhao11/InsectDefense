using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterAnim : MonoBehaviour
{
    Animator anim;
    [SerializeField] Weapon weapon;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!anim.GetBool("isRunning") && (Input.GetAxisRaw("Vertical") != 0 || Input.GetAxisRaw("Horizontal") != 0))
        {
            anim.SetBool("isRunning", true);
            //weapon.transform.Rotate(0,0,-60, Space.Self);
        }
        else if(anim.GetBool("isRunning") && Input.GetAxisRaw("Vertical") == 0 && Input.GetAxisRaw("Horizontal") == 0)
        {
            anim.SetBool("isRunning", false);
            //weapon.transform.Rotate(0, 0, 60, Space.Self);
        }

    }
}
