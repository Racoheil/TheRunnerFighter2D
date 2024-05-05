using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthSystem : MonoBehaviour
{
    [SerializeField] Animator _animator;

    [SerializeField] private int _maxHealth = 3;

    [SerializeField] private int _currentHealth;

    private Collider2D _collider;

    private bool _isDead;

    private Rigidbody2D _rigidBody;

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
        _collider.enabled = false;
        _rigidBody.gravityScale = 0;
        
    }
    public void Bounce()
    {
        _rigidBody.velocity = Vector2.zero;
        _rigidBody.AddForce(new Vector2(50000f, 50000f), ForceMode2D.Impulse);
        Debug.Log("Enemy is died");
    }
}
