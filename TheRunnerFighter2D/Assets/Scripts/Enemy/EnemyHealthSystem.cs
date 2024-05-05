using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthSystem : MonoBehaviour
{
    [SerializeField] Animator _animator;

    private int _maxHealth = 3;

    private int _currentHealth;

    private bool _isDead;
    private void Start()
    {
        _isDead = false;
        _currentHealth = _maxHealth;
    }
    public void TakeDamage(int damageValue)
    {
        _animator.SetTrigger("TakeDamage");

        _currentHealth -= damageValue;

        if (_currentHealth <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
       // _isDead = true;
        _animator.SetBool("IsDead", true);
        Debug.Log("Enemy is died");
    }
}
