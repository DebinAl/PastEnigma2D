using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour
{
    [SerializeField] private float _pSpeed;
    [SerializeField] private float _pJump;

    private Rigidbody2D _rb;
    private SpriteRenderer _spriteRenderer;
    private Vector2 _movement;
    private float _direction;
    private bool _isGrounded = false;
    private bool _isActive = true;
   
    Animator animator;
    [SerializeField] Animator finishAnimator;

    void Start()
    {
        if (SceneManager.GetActiveScene().name == "LevelScene")
        {
            GameEventHandler.instance.OnStartButtonPress += Instance_OnStartButtonPress;
            GameEventHandler.instance.OnPuzzleDone += Instance_OnPuzzleDone;
            GameEventHandler.instance.OnPuzzleFailed += Instance_OnPuzzleDone;
        }

        _rb = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    private void OnDisable()
    {
        if (SceneManager.GetActiveScene().name == "LevelScene")
        {
            GameEventHandler.instance.OnStartButtonPress -= Instance_OnStartButtonPress;
            GameEventHandler.instance.OnPuzzleDone -= Instance_OnPuzzleDone;
            GameEventHandler.instance.OnPuzzleFailed -= Instance_OnPuzzleDone;
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

    private void PlayerMovement()
    {
        //Movement Logic
        _direction = Input.GetAxis("Horizontal");
        _movement = new Vector2(_direction, 0);
        transform.Translate(_pSpeed * Time.deltaTime * _movement);

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
        if (other.CompareTag("SpikeTrap"))
        {
            SceneManager.LoadScene("LevelScene");
        }
        if (other.CompareTag("Finish"))
        {
            finishAnimator.SetBool("finish", true);

            StartCoroutine(Finish());
        }
    }

    private IEnumerator Finish()
    {
        yield return new WaitForSeconds(3f);

        SceneManager.LoadScene("MainMenuScene");
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
        // Set the scale based on the direction of movement
        transform.localScale = new Vector3(Mathf.Sign(_direction) * Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
    }

    void Animations()
    {
        // if player is moving then play walking animation
        animator.SetFloat("Moving", Mathf.Abs(_direction));
        animator.SetBool("_isGrounded", _isGrounded);
    }   
}