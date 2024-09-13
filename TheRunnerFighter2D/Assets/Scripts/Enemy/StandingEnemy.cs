using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandingEnemy : MonoBehaviour, IEnemy
{
    [SerializeField] Animator _animator;

    [SerializeField] private int _maxHealth = 2;

    [SerializeField] private Collider2D _swingZone;

    [SerializeField] private Collider2D _damageZone;

    private bool _isSwinging;

    [SerializeField] private int _currentHealth;

    private Collider2D _collider;

    private bool _isDead;

    private Rigidbody2D _rigidBody;

    private float _timeBtwAttack;

    private float _startTimeBtwAttack = 1f;

    private float _freezeTime;

    [SerializeField] Vector2 bounceForce = new Vector2(9, 3);

    private int _pointsCount = 10;

    private void Awake()
    {
        _collider = GetComponent<Collider2D>();
        _rigidBody = GetComponent<Rigidbody2D>();
    }
    private void Start()
    {
        _isDead = false;
        _currentHealth = _maxHealth;
    }
    public void TakeDamage(int damageValue)
    {
        if (_isDead) return;
        

        _animator.SetTrigger("TakeDamage");

        _currentHealth -= damageValue;

        Bounce();

        EventService.CallOnEnemyTakeDamageSound();

        if (_currentHealth <= 0)
        {
            _rigidBody.freezeRotation = false;
            
            Bounce();
            Die();
        }
    }

    public void Die()
    {
        _isDead = true;
        _animator.SetBool("IsDead", _isDead);
        
        print("Player kill " + this.name);
        EventService.CallOnKillEnemy(_pointsCount);

        EventService.CallOnEnemyDieSound();
    }
    public void Attack()
    {
        print("Enemy Attacking!");
        EventService.CallOnEnemySwingSound();

        _animator.SetTrigger("Attack");

        if (_isSwinging)
        {
            _timeBtwAttack = _startTimeBtwAttack / 2;
        }
        else if (!_isSwinging)
        {
            _timeBtwAttack = _startTimeBtwAttack;
        }
    }
    public void OnAttackEvent()
    {
        if (_isSwinging) return;

        EventService.CallOnTakeDamage();

    }
    public void OnDieEvent()
    {
        this.gameObject.SetActive(false);
        
    }
    public void Bounce()
    {
  
        _rigidBody.velocity = Vector2.zero;
        _rigidBody.AddForce(bounceForce * 10000, ForceMode2D.Impulse);
        Debug.Log("Enemy is bounced");
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.IsTouching(_swingZone) && collision.gameObject.tag == "Player")
        {
            print("SWING ZONE!!");
            _isSwinging = true;

            if (_timeBtwAttack <= 0)
            {
                Attack();
            }
            else
            {
                _timeBtwAttack -= Time.deltaTime;
            }
        }
        else if (collision.IsTouching(_damageZone) && collision.gameObject.tag == "Player" && !PlayerHealthSystemService.instance.GetImmortality())
        {
            _isSwinging = false;

            if (_timeBtwAttack <= 0)
            {
                Attack();
            }
            else
            {
                _timeBtwAttack -= Time.deltaTime;
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Obstacle")
        {
            print("Obstacle!!");
            TakeDamage(_currentHealth);
        }
    }
}
