using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed = 10f;

    private float _addingSpeedValue = 2f;

    private Rigidbody2D _rigidBody;

    private Vector2 _moveVector;

    private bool _isHurting = false;

    private bool _isMoving;

    private void OnEnable()
    {
        EventService.OnTakeDamage += FreezePlayer;
        EventService.OnPlayerChangeLevel += IncreaseSpeed;
    }

    private void OnDisable()
    {
        EventService.OnTakeDamage -= FreezePlayer;
        EventService.OnPlayerChangeLevel -= IncreaseSpeed;
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
        if (_isMoving)
        {
            MovePlayer();
        }
    }
    private void MovePlayer()
    {
        _rigidBody.velocity = new Vector2(_moveVector.x * _speed, _rigidBody.velocity.y);
        PlayerAnimation.instance.animator.SetBool("isHurting", _isHurting);
    }
    private void FreezePlayer()
    {
        _moveVector.x = 0;
        StartCoroutine(FreezePlayerCoroutine());
    }
    private void IncreaseSpeed()
    {
        _speed += _addingSpeedValue;
    }
     IEnumerator FreezePlayerCoroutine()
    {
        _isHurting = true;
        yield return new WaitForSeconds(0.6f);
        _moveVector.x = 1f;
        _isHurting = false;
    }
}
