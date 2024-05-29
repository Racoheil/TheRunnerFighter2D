using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingShootingEnemy : MonoBehaviour
{
    [SerializeField] Animator _animator;

    [SerializeField] private int _maxHealth = 1;

    [SerializeField] private GameObject _bulletPrefab;

    [SerializeField] private Transform _shotPoint;

    private int _currentHealth;

    private BoxCollider2D _boxCollider2D;

    private Rigidbody2D _rigidBody;

    private float _speed = 3f;

    private Vector2 _moveVector;

    private float _shootingInterval = 5f;

    private int _bulletsCount = 5;

    private bool _isShooting = false;

    private bool _isDead = false;

    private void Awake()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
        _boxCollider2D = GetComponent<BoxCollider2D>();
        _isShooting = true;
    }
    private void Start()
    {
        _currentHealth = 1;
    }
    private void FixedUpdate()
    {
        //if (_isAttack)
        //{
        //    // Debug.Log("MOVE!!");
        //    _rigidBody.velocity = new Vector2(_moveVector.x * _speed, _rigidBody.velocity.y);
        //}
    }
    private IEnumerator ShootingCoroutine()
    {
        for (int i = 0; i < _bulletsCount; i++)
        {
            if (_isShooting == false)
            {
                yield break;
            }
            //Shoot();
            yield return new WaitForSeconds(_shootingInterval);
        }
    }

    public void Die()
    {
        _boxCollider2D.enabled = false;
        _isDead = true;
        _isShooting = false;
        _animator.SetBool("IsDead", true);
    }
    public void OnDieEvent()
    {
        this.gameObject.SetActive(false);
    }
 
    public void TakeDamage(int damageValue)
    {
        if (_isDead) return;

        _animator.SetTrigger("TakeDamage");

        _currentHealth -= damageValue;

        if (_currentHealth <= 0)
        {
            Die();
        }
    }
    private void ActivateEnemy()
    {
        Instantiate(_bulletPrefab, _shotPoint.position,new Quaternion(0,0,0,0));
        print("Shoot!");
    }

    private void OnTriggerEnter2D(Collider2D collider2D)
    {
        if (collider2D.transform.CompareTag("TriggerZone"))
        {
            ActivateEnemy();
        }
    }

}
