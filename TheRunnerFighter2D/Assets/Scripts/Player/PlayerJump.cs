using System.Collections;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    [SerializeField] private float _jumpForce = 1f;

    [SerializeField] private int _maxJumps = 2;

    [SerializeField] private int _groundLayer = 3;

    private int _defaultJumpsCount;

    private bool _isButtonPressed;

    private int _jumps;

    private Rigidbody2D _rigidBody;

    private float _doubleJumpDelay = 0.2f;

    private bool _hasDoubleJumped;

    private bool _isJump = true;

    private bool _isJumping = false;

    public static PlayerJump instance;
    private void Awake()
    {
        instance = this;
        _rigidBody = GetComponent<Rigidbody2D>();
        _defaultJumpsCount = _maxJumps;
        //_jumps = _maxJumps;
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

    private void OnEnable()
    {
        EventService.OnTakeDamage += FreezePlayer;
        EventService.OnPlayerLose += DisableJump;
    }

    private void OnDisable()
    {
        EventService.OnTakeDamage -= FreezePlayer;
        EventService.OnPlayerLose -= DisableJump;
    }
    private void Jump(float jumpForce)
    {
        if (_jumps > 0 && !_hasDoubleJumped && _isJump)
        {
            
            EventService.CallOnPlayerJumpSound();

            _rigidBody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            //StartCoroutine(LandingRoutine());
            _jumps--;
            _hasDoubleJumped = true;
            StartCoroutine(ResetDoubleJump());
        }
        if (_jumps == 0)
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
        if (!_isJump == false) return;

        _isJump = false;
        StartCoroutine(FreezePlayerCoroutine());
    }

    IEnumerator FreezePlayerCoroutine()
    {
        yield return new WaitForSeconds(1f);
        _isJump = true;
    }

    //IEnumerator LandingRoutine()
    //{
    //    print("JUMPING SUKA");
    //    while(GroundCheck.instance.GetIsGrounded() == false)
    //    {
    //        print("Is jumping");
    //        yield return new WaitForSeconds(0.01f);
    //    }
    //        EventService.CallOnPlayerLanding();

    //}

    public void SetJumpsCount(int value)
    {
        _maxJumps = value;
    }
    public void SetDefaultJumpsCount()
    {
        _maxJumps = _defaultJumpsCount;
    }

    public void DisableJump()
    {
        _isJump = false;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == _groundLayer)
        {
            EventService.CallOnPlayerLanding();
            print("Landing!");
        }
    }

}
