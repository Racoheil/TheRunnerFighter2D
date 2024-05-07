using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthSystem : MonoBehaviour
{
    [SerializeField] Animator _animator;

    [SerializeField] private int _maxHealth = 3;

    private int _currentHealth;

    private Collider2D _collider;

    private bool _isDead;

    private Rigidbody2D _rigidBody;

    private float _timeBtwAttack;

    [SerializeField] private float _startTimeBtwAttack = 1;

    private float _freezeTime;

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

        if (_currentHealth <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        _isDead = true;
        _animator.SetBool("IsDead", _isDead);
        //_collider.enabled = false;
        //_rigidBody.gravityScale = 0;
        
    }
    public void Attack()
    {
        _animator.SetTrigger("Attack");
        _timeBtwAttack = _startTimeBtwAttack;

    }
    public void OnAttackEvent()
    {
        EventService.CallOnTakeDamage();

    }
    public void OnDieEvent()
    {
        this.gameObject.SetActive(false);
    }
    public void Bounce()
    {
        Vector2 bounceForce = new Vector2(9, 3);
        _rigidBody.velocity = Vector2.zero;
        _rigidBody.AddForce(bounceForce * 10000, ForceMode2D.Impulse);
        Debug.Log("Enemy is died");
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
    }
    //private void OnCollisionStay2D(Collision2D collision)
    //{
    //    //
    //    if (collision.gameObject.tag == "Player" && !PlayerHealthSystemService.instance.GetImmortality())
    //    {
    //        if (_timeBtwAttack <= 0)
    //        {
    //            Attack();
    //        }
    //        else
    //        {
    //            _timeBtwAttack -= Time.deltaTime;
    //        }
    //    }
    //}
}
