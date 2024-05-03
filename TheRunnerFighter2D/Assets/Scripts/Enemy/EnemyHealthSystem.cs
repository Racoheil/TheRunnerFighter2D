using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthSystem : MonoBehaviour
{
    private int _maxHealth = 2;

    private int _currentHealth;

    private void Start()
    {
        _currentHealth = _maxHealth;
    }
    public void TakeDamage(int damageValue)
    {
        _currentHealth -= damageValue;

        if (_currentHealth <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        Debug.Log("Enemy is died");
    }
}
