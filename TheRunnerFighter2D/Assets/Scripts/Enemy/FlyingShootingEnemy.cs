using DG.Tweening;
using System.Collections;
using UnityEngine;


public class FlyingShootingEnemy : MonoBehaviour, IEnemy
{
    [SerializeField] Animator _animator;

    [SerializeField] private int _maxHealth = 1;

    [SerializeField] private GameObject _bulletPrefab;

    [SerializeField] private Transform _shotPoint;

    [SerializeField] private int _bulletsCount = 5;

    private int _currentHealth;

    private BoxCollider2D _boxCollider2D;

    private Rigidbody2D _rigidBody;

    private float _duration = 1.5f;

    private Vector2 _moveVector;

    private float _shootingInterval = 5f;

    private bool _isShooting = false;

    private bool _isDead = false;

    private bool _isMoving = false;

    private float _movingDistance = 0.8f;

    private int _pointsCount = 15;

    private float _freezingTime = 0.4f;

    private Tweener _animationsTweener;

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
     
    }
    private IEnumerator ActivatingCoroutine()
    {
        for (int i = 0; i < _bulletsCount; i++)
        {
            if (_isShooting == false)
            {
                yield break;
            }
            Shoot();
            yield return new WaitForSeconds(_shootingInterval);
        }
    }

    private IEnumerator MovingCoroutine()
    {
        float topPositionY = transform.position.y + _movingDistance;
        float lowPositionY = transform.position.y - _movingDistance;

        while (_isMoving)
        {

            yield return  transform.DOMoveY(topPositionY, _duration).SetEase(Ease.Linear).WaitForCompletion();
          
            yield return transform.DOMoveY(lowPositionY, _duration).SetEase(Ease.Linear).WaitForCompletion();
        }  
    }

    public void Die()
    {
        _boxCollider2D.enabled = false;
        _isDead = true;
        _isShooting = false;
        _animator.SetBool("IsDead", true);

        print("Player kill " + this.name);
        EventService.CallOnKillEnemy(_pointsCount);
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
        StartCoroutine(ActivatingCoroutine());
        _isMoving = true;
        StartCoroutine(MovingCoroutine());
    }
    private void Shoot()
    {
        _animator.SetTrigger("Shoot");
    }

    public void OnShootEvent()
    {
        StartCoroutine(ShootingCoroutine());
    }

    private void OnTriggerEnter2D(Collider2D collider2D)
    {
        if (collider2D.transform.CompareTag("TriggerZone"))
        {
            ActivateEnemy();
        }
    }

    private IEnumerator ShootingCoroutine()
    {
        transform.DOPause();
        Instantiate(_bulletPrefab, _shotPoint.position, _shotPoint.rotation);

        yield return new WaitForSecondsRealtime(_freezingTime);
        transform.DOPlay();
    }

}
