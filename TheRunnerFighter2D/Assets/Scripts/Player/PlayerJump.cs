using System.Collections;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    [SerializeField] private float _jumpForce = 1f;

    [SerializeField] private int _maxJumps = 2;

    private int _defaultJumpsCount;

    private int _jumps;

    private Rigidbody2D _rigidBody;

    private float _doubleJumpDelay = 0.1f;

    private bool _hasDoubleJumped;

    [SerializeField] private bool _isJump;

    public static PlayerJump instance;
    private void Awake()
    {
        _isJump = true;
        instance = this;
        _rigidBody = GetComponent<Rigidbody2D>();
        _defaultJumpsCount = _maxJumps;
        //_jumps = _maxJumps;
    }
    private void Update()
    {
        if (GroundCheck.instance.GetIsGrounded())
        {
            _jumps = _maxJumps - 1;
           // _isJump = true;
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
        EventService.OnTrampolineJump += TrampolineJump;
    }

    private void OnDisable()
    {
        EventService.OnTakeDamage -= FreezePlayer;
        EventService.OnPlayerLose -= DisableJump;
        EventService.OnTrampolineJump -= TrampolineJump;
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
    public void TrampolineJump()
    {
        _isJump = false;
        _rigidBody.velocity = Vector2.zero;
        _rigidBody.AddForce(Vector2.up * _jumpForce * 1.5f, ForceMode2D.Impulse);
        //_hasDoubleJumped = true;
        //StartCoroutine(ResetDoubleJump());
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
        if (collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            _isJump = true;
            EventService.CallOnPlayerLanding();
        }
    }

}
