using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingEnemy : MonoBehaviour
{
    private Rigidbody2D _rigidBody;

    private float _speed = 3f;

    private Vector2 _moveVector;

    private bool _isAttack = false;
    private void Awake()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
        _moveVector = new Vector2(-1, 0);
    }
    private void FixedUpdate()
    {
        if (_isAttack)
        {
            Debug.Log("MOVE!!");
            _rigidBody.velocity = new Vector2(_moveVector.x * _speed, _rigidBody.velocity.y);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Flying enemy!!!!");
        if (collision.gameObject.tag == "Player")
        {
            if (!PlayerHealthSystemService.instance.GetImmortality())
            {
                EventService.CallOnTakeDamage();
            }
        }
        else if(collision.gameObject.tag == "TriggerZone")
        {
            ActivateEnemy();
        }
    }
    private void ActivateEnemy()
    {
        Debug.Log("Fly!!");
        _isAttack = true;
    }
}
