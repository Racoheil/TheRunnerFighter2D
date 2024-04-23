using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D _rigidBody;

    [SerializeField]private float _speed = 10f;

    private Vector2 _moveVector;

    private bool _isMoving;

    private void OnEnable()
    {
        EventService.OnTakeDamage += FreezePlayer;
    }

    private void OnDisable()
    {
        EventService.OnTakeDamage -= FreezePlayer;
    }
    private void Start()
    {
        _isMoving = true;
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

    private void FreezePlayer()
    {
        _speed = 0f;
        StartCoroutine(FreezePlayerCoroutine());
    }

     IEnumerator FreezePlayerCoroutine()
    {
        yield return new WaitForSeconds(1f);
       // _moveVector.x = 1f;
        _speed = 10f;
    }
}
