using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    [SerializeField] private float _jumpForce = 1f;

    [SerializeField] private int _maxJumps = 2;

    private bool _isButtonPressed;

    private int _jumps = 0;

    private Rigidbody2D _rigidBody;

    private float _doubleJumpDelay = 0.2f;

    private bool _hasDoubleJumped;

    private bool _isJump = true;
    private void Awake()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {

        if (GroundCheck.instance.GetIsGrounded())
        {
            _jumps = _maxJumps - 1;
           // PlayerAnimation.instance.ChangeAnimation("Run");
        }
        else if (GroundCheck.instance.GetIsGrounded()==false)
        {
         //   PlayerAnimation.instance.ChangeAnimation("jump");
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump(_jumpForce);
        }
    }
    private void OnEnable()
    {
        EventService.OnTakeDamage += FreezePlayer;
    }

    private void OnDisable()
    {
        EventService.OnTakeDamage -= FreezePlayer;
    }
    private void Jump(float jumpForce)
    {
       // PlayerAnimation.instance.ChangeAnimation("jump");
        if (_jumps > 0 && !_hasDoubleJumped && _isJump)
        {
            _rigidBody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            _jumps -= 1;
            _hasDoubleJumped = true;
            StartCoroutine(ResetDoubleJump());
            Debug.Log("Jump!");
            
        }
        if(_jumps == 0)
        {
            return;
        }
      
    }
    IEnumerator ResetDoubleJump()
    {
        yield return new WaitForSeconds(_doubleJumpDelay);
        _hasDoubleJumped = false;
    }

    private void FreezePlayer()
    {
        // _moveVector.x = 0f;
        _isJump = false;
        StartCoroutine(FreezePlayerCoroutine());
    }

    IEnumerator FreezePlayerCoroutine()
    {
        yield return new WaitForSeconds(1f);
        // _moveVector.x = 1f;
        _isJump = true;
    }
}
