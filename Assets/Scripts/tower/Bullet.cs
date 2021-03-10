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
    float bullet_damage;

    void Awake()
    {
        _rgbd = GetComponent<Rigidbody>();
    }

    public void Setup(Vector3 shootDir, float damage)
    {
        _shootDir = shootDir;
        _rgbd.velocity = _shootDir * _bulletSpeed;
        bullet_damage = damage;
        Destroy(gameObject, bulletLifeInSeconds);
    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.CompareTag("Enemy"))
    //    {
    //        enemyMovement enemy = FindObjectOfType<enemyMovement>();
    //        enemy.health -= 1;
    //        Destroy(gameObject);

    //    }

    //}

    private void OnCollisionEnter(Collision collision)
    {
        GameObject other = collision.gameObject;
        if (other.CompareTag("Enemy"))
        {

            enemy enemy = other.GetComponent<enemy>();
            enemy.health -= bullet_damage;
            Destroy(gameObject);
        }
    }
}
