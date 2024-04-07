using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    [SerializeField] private LayerMask _groundLayer;

    [SerializeField] private bool _isGrounded;

    [SerializeField] private float _distance;

    public static GroundCheck instance;

    private void Awake()
    {
        instance = this;
    }
    public bool GetIsGrounded()
    {
        return _isGrounded;
    }

    public void SetIsGrounded(bool value)
    {
        _isGrounded = value;
    }
    private void FixedUpdate()
    {
        _isGrounded = Physics2D.Raycast(this.transform.position, Vector2.down, _distance);

        Debug.Log("isGrounded = " + Physics2D.Raycast(this.transform.position, Vector2.down, _distance, _groundLayer));
    }
}
