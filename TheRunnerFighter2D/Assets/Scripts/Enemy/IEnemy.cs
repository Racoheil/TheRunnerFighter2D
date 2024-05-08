using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEnemy
{
    public void TakeDamage(int damageValue);
    public void Attack();

    public void Die();
}
