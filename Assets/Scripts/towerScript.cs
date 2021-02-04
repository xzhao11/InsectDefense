using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class towerScript : MonoBehaviour
{
    [SerializeField] Transform enemy;
    [SerializeField] float _shootDelay = 0.2f;
    [SerializeField] Transform _bulletPrefab;
    [SerializeField] Transform _shootPoint;
    private float _nextShootTime;

    void Update()
    {
        transform.LookAt(enemy);
    }


    void FixedUpdate()
    {
        if (enemy)
        {
            Vector3 direction = enemy.position - _shootPoint.position;
            Gunfiring(direction);
        }
        
    }

    private void Gunfiring(Vector3 direction)
    {
        if (!direction.Equals(Vector3.zero) && CanShoot())
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
}
