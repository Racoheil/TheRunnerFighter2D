using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingEnemy : MonoBehaviour
{
    [SerializeField] private GameObject _bulletPrefab;

    [SerializeField] private Transform _shotPoint;

    private float _shootingInterval = 5f;

    private int _bulletsCount = 5;
    private IEnumerator ShootingCoroutine()
    {
        for (int i = 0; i < _bulletsCount;i++)
        {
            Shoot();
            yield return new WaitForSeconds(_shootingInterval);
        }
    }
    private void Shoot()
    {
        GameObject bullet = Instantiate(_bulletPrefab, _shotPoint);

    }
    private void ActivateEnemy()
    {
        StartCoroutine(ShootingCoroutine());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "TriggerZone")
        {
            ActivateEnemy();
        }
    }
}
