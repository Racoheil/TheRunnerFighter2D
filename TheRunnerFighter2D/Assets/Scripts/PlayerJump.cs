using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    [SerializeField] private float _jumpForce = 1f;

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

    private void Jump(float jumpForce)
    {
       _rigidBody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
       _rigidBody.velocity = new Vector2(_rigidBody.velocity.x, jumpForce);
       Debug.Log("Jump!");


    }
}
