using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
   // private Rigidbody2D _rigidBody;

    private float _speed = 0.005f;

    private Vector2 _moveVector;

    private void Awake()
    {
       // _rigidBody = GetComponent<Rigidbody2D>();
        _moveVector = new Vector2(-1, 0);
    }
    private void FixedUpdate()
    {
        // _rigidBody.velocity = new Vector2(_moveVector.x * _speed, _rigidBody.velocity.y);
        transform.Translate(Vector3.left * _speed);
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
    }
}
