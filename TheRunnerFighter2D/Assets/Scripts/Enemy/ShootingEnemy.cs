using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingEnemy : MonoBehaviour, IEnemy
{
    [SerializeField] Animator _animator;

    private Rigidbody2D _rigidBody;

    private BoxCollider2D _boxCollider2D;

    [SerializeField] private int _maxHealth = 1;

    private int _currentHealth;

    private bool _isShooting;

    [SerializeField] private GameObject _bulletPrefab;

    [SerializeField] private Transform _shotPoint;

    private float _shootingInterval = 5f;

    private int _bulletsCount = 5;

    private bool _isDead;

    private void Awake()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
        _boxCollider2D = GetComponent<BoxCollider2D>();
        _isShooting = true;
    }
    private IEnumerator ShootingCoroutine()
    {
        for (int i = 0; i < _bulletsCount;i++)
        {
            if(_isShooting == false)
            {
                yield break;
            }
            Shoot();
            yield return new WaitForSeconds(_shootingInterval);
        }
    }
    public void Shoot()
    {
        
        _animator.SetTrigger("Shoot");
        GameObject bullet = Instantiate(_bulletPrefab, _shotPoint);
    }
    public void Die()
    {
        _boxCollider2D.enabled = false;
        _isDead = true;
        _animator.SetBool("isDead", true);
        _isShooting = false;
    }
    public void OnDieEvent()
    {
        this.gameObject.SetActive(false);
        
    }
    public void TakeDamage(int damageValue)
    {
        //if (_isDead) return;

        //print("Player hit the shooting enemy");

        //_animator.SetTrigger("TakeDamage");

        //_currentHealth -= damageValue;

        //if(_currentHealth <= 0)
        //{
        //    Die();
        //}
        Die();
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
