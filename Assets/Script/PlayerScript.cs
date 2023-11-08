using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    [SerializeField] private float _pSpeed;
    [SerializeField] private float _pJump;

    private Rigidbody2D _rb;
    private Vector2 _movement;
    private float _direction;
    private bool _isGrounded = true;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //Movement Logic
        _direction = Input.GetAxis("Horizontal");
        _movement = new Vector2(_direction, 0);
        transform.Translate(_movement * Time.deltaTime * _pSpeed);

        //jump logic
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Joystick1Button0))
        {
            if(_isGrounded)
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

}