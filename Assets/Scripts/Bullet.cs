using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float _bulletSpeed = 2f;
    //[SerializeField] ParticleSystem _hitPrefab;

    float bulletLifeInSeconds = 4f;
    Vector3 _shootDir;
    Rigidbody _rgbd;

    void Awake()
    {
        _rgbd = GetComponent<Rigidbody>();
    }

    public void Setup(Vector3 shootDir)
    {
        _shootDir = shootDir;
        _rgbd.velocity = _shootDir * _bulletSpeed;
        Destroy(gameObject, bulletLifeInSeconds);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            //Debug.Log("hit");
            enemyMovement enemy = FindObjectOfType<enemyMovement>();
            enemy.health -= 1;
            //Debug.Log("health is " + enemy.health);
            Destroy(gameObject);

        }
        
    }
}
