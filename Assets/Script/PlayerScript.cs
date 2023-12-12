using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    [SerializeField] private float _pSpeed;
    [SerializeField] private float _pJump;

    private Rigidbody2D _rb;
    private SpriteRenderer _spriteRenderer;
    private Vector2 _movement;
    private float _direction;
    private bool _isGrounded = true;
    private bool _isActive = true;
   

    Animator animator;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        GameEventHandler.instance.OnStartButtonPress += Instance_OnStartButtonPress;
        GameEventHandler.instance.OnPuzzleDone += Instance_OnPuzzleDone;
        GameEventHandler.instance.OnPuzzleFailed += Instance_OnPuzzleDone;
        animator = GetComponent<Animator>();
    }

    private void OnDisable()
    {
        GameEventHandler.instance.OnStartButtonPress -= Instance_OnStartButtonPress;
        GameEventHandler.instance.OnPuzzleDone -= Instance_OnPuzzleDone;
        GameEventHandler.instance.OnPuzzleFailed -= Instance_OnPuzzleDone;
    }


    void Update()
    {
        if (_isActive)
        {
            _spriteRenderer.enabled = true;
            PlayerMovement();
            Facing();
            Animations();
        }
        else
        {
            _spriteRenderer.enabled = false;
        }


    }

    private void Instance_OnPuzzleDone()
    {
        _isActive = true;
    }

    private void Instance_OnStartButtonPress()
    {
        _isActive = false;
    }

    private void PlayerMovement()
    {
        //Movement Logic
        _direction = Input.GetAxis("Horizontal");
        _movement = new Vector2(_direction, 0);
        transform.Translate(_movement * Time.deltaTime * _pSpeed);

        //jump logic
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Joystick1Button0))
        {
            if (_isGrounded)
            {
                _rb.velocity = new Vector2(0, _pJump);
            }
        }
    }
    
    private void OnTriggerEnter2D (Collider2D other)
    {
        if (other.CompareTag("Ground"))
        {
            _isGrounded = true;
        }
    }

    private void OnTriggerExit2D (Collider2D other)
    {
        if (other.CompareTag("Ground"))
        {
            _isGrounded = false;
        }
    }


    void Facing()
    {
        // if player is moving left scale = -1
        if (_direction < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        // if player is moving right scale = 1
        if (_direction > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
    }

    void Animations()
    {
        // if player is moving then play walking animation
        animator.SetFloat("Moving", Mathf.Abs(_direction));
        animator.SetBool("_isGrounded", _isGrounded);
    }

   
}