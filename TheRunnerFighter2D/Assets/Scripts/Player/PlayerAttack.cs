using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using UnityEngine;
public class PlayerAttack : MonoBehaviour
{
    [SerializeField] Transform _attackPoint;

    private bool _isAttack;

    [SerializeField] private float _attackRange = 0.5f;

    [SerializeField] private LayerMask _enemyLayer;

    private int _damageValue = 1;
    private void Awake()
    {
        _isAttack = true;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z) && _isAttack)
        {
            Attack();
        }
    }

    private void Attack()
    {
        PlayerAnimation.instance.animator.SetTrigger("AttackTrigger");
    }
    public void OnAttackEvent()
    {
        Collider2D[] enemyColliders2D = Physics2D.OverlapCircleAll(_attackPoint.position, _attackRange, _enemyLayer);

        foreach (Collider2D enemy in enemyColliders2D)
        {
            // Debug.Log("We hit " + collider.name);
            enemy.GetComponent<EnemyHealthSystem>().TakeDamage(_damageValue);
            
        }
    }
    private void OnDrawGizmosSelected()
    {
        if (_attackPoint == null) return;
        Gizmos.DrawWireSphere(_attackPoint.position, _attackRange);
    }

}
