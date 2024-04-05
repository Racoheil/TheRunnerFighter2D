using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D _rigidBody;

    [SerializeField] private float _speed = 10f;

    private Vector2 _moveVector;

    private void Start()
    {
        _moveVector = new Vector2(1f, 0f);
    }
    void Awake()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        _rigidBody.velocity = new Vector2(_moveVector.x * _speed, _rigidBody.velocity.y);
    }
}
