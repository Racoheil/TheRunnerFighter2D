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

    private float doubleJumpDelay = 0.2f;

    private bool hasDoubleJumped;
    private void Awake()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {

        if (GroundCheck.instance.GetIsGrounded())
        {
            _jumps = _maxJumps - 1;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump(_jumpForce);
        }
    }

    private void Jump(float jumpForce)
    {
        if(_jumps > 0 && !hasDoubleJumped)
        {
            _rigidBody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            //_isGrounded = false;
            _jumps -= 1;
            hasDoubleJumped = true;
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
        yield return new WaitForSeconds(doubleJumpDelay);
        hasDoubleJumped = false;
    }
}
