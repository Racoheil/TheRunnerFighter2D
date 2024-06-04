using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed = 7f;

    private float _defaultSpeed;

    private float _addingSpeedValue = 2f;

    private Rigidbody2D _rigidBody;

    [SerializeField] private Vector2 _moveVector;

    private bool _isHurting = false;

    private bool _isMoving;

    private float _defaultGravityScale;

    private float _defaultMass;

    public static PlayerMovement instance;
    private void OnEnable()
    {
        EventService.OnTakeDamage += FreezePlayer;
        EventService.OnPlayerChangeLevel += IncreaseSpeed;
        EventService.OnPlayerLose += StopPlayer;
    }

    private void OnDisable()
    {
        EventService.OnTakeDamage -= FreezePlayer;
        EventService.OnPlayerChangeLevel -= IncreaseSpeed;
        EventService.OnPlayerLose -= StopPlayer;
    }
    private void Awake()
    {
        instance = this;

        _defaultSpeed = _speed;
        _rigidBody = GetComponent<Rigidbody2D>();
        _defaultGravityScale = _rigidBody.gravityScale;
        _defaultMass = _rigidBody.mass;
    }

    private void Update()
    {
        //print("Time.time = " + Time.deltaTime);
        if (Input.GetKeyDown(KeyCode.J))
        {
            StopPlayer();
        }
    }
    private void Start()
    {
        DeactivatePlayer();
    }


    private void FixedUpdate()
    {
        if (_isMoving)
        {
            MovePlayer();
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            ActivatePlayer();
        }
    }
    private void DeactivatePlayer()
    {
        _isMoving = false;
        PlayerAnimation.instance.animator.SetBool("isMoving", false);
        _moveVector = new Vector2(0f, 0f);
    }
    private void ActivatePlayer()
    {
        _isMoving = true;
        PlayerAnimation.instance.animator.SetBool("isMoving", true);
        _moveVector = new Vector2(1f, 0f);
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
    private void StopPlayer()
    {
        //_moveVector.x = 0f;
        _speed = 0;
    }
    public void SetGravityScale(float value)
    {
        _rigidBody.gravityScale = value;
    }

    public void SetMass(float value)
    {
        _rigidBody.mass = value;
    }
    
    public void SetDefaultRigidBodyPropeties()
    {
        _rigidBody.gravityScale = _defaultGravityScale;
        _rigidBody.mass = _defaultMass;
    }
    public float GetRigidBodyVectorX()
    {
       // print("defSpeed = " + _defaultSpeed);
        //print("value = "+_rigidBody.velocity.x / _defaultSpeed);
        return _rigidBody.velocity.x/_defaultSpeed;
    }
}
