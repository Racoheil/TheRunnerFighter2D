using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingEnemy : MonoBehaviour, IEnemy
{
    [SerializeField] Animator _animator;

    [SerializeField] private int _maxHealth = 1;

    private int _currentHealth;

    [SerializeField] private float _startTimeBtwAttack = 1;

    private BoxCollider2D _boxCollider2D;

    private float _timeBtwAttack;

    private Rigidbody2D _rigidBody;

    private float _speed = 3f;

    private Vector2 _moveVector;

    private bool _isAttack = false;

    private bool isDead = false;
    private void Awake()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
        _boxCollider2D = GetComponent <BoxCollider2D>();
        _moveVector = new Vector2(-1, 0);
    }
    private void FixedUpdate()
    {
        if (_isAttack)
        {
           // Debug.Log("MOVE!!");
            _rigidBody.velocity = new Vector2(_moveVector.x * _speed, _rigidBody.velocity.y);
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && !PlayerHealthSystemService.instance.GetImmortality())
        {
            if (_timeBtwAttack <= 0)
            {
                Attack();
            }
            else
            {
                _timeBtwAttack -= Time.deltaTime;
            }
        }
        if(collision.gameObject.tag == "TriggerZone")
        {
            ActivateEnemy();
        }
    }
    public void Attack()
    {
        _animator.SetTrigger("AttackTrigger");
        _timeBtwAttack = _startTimeBtwAttack;
    }
    public void OnAttackEvent()
    {
        EventService.CallOnTakeDamage();
    }
    public void Die()
    {
        _boxCollider2D.enabled = false;
        //print("Flying enemy died");
        _animator.SetBool("IsDead", true);
    }
    public void OnDieEvent()
    {
        this.gameObject.SetActive(false);
    }
    private void ActivateEnemy()
    {
        //Debug.Log("Fly!!");
        _isAttack = true;
    }
    public void TakeDamage(int damageValue)
    {
        if (isDead) return;

        //print("Player hit the flyin enemy");

        _animator.SetTrigger("TakeDamage");

        _currentHealth -= damageValue;

        if(_currentHealth <= 0)
        {
            Die();
        }
    }
}
