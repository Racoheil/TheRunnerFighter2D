using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    [SerializeField] private float _jumpForce = 1f;

    [SerializeField] private bool _isGrounded;

    [SerializeField] private Transform _groundCheckObject;

    [SerializeField] private float _checkRadius;

    [SerializeField] private LayerMask _groundLayer;

    [SerializeField] private int _maxJumps = 2;

    private int _jumps = 0;

    private Rigidbody2D _rigidBody;

    private void Awake()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump(_jumpForce);
        } 

    }
    private void FixedUpdate()
    {
        _isGrounded = Physics2D.OverlapCircle(_groundCheckObject.position,_checkRadius,_groundLayer);

        if (_isGrounded == true)
        {
            _jumps = _maxJumps - 1;
        }
    }

    private void Jump(float jumpForce)
    {
        if(_jumps > 0)
        {
            _rigidBody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            _isGrounded = false;
            _jumps -= 1;
            Debug.Log("Jump!");
        }
        if(_jumps == 0)
        {
            return;
        }
      
    }
}
