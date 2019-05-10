using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;
//using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _walkSpeed, _runSpeed;
    private float _currentSpeed;
    public float sprintMultiplier;
    public float jumpForce;
    //public bool canMove;

    public bool canGoThruAngerDoor = false;

    private Rigidbody2D _rb;
    private Vector2 moveVelocity;

    private bool facingRight = true;

    private bool isGrounded;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask WhatIsGrounded;
    public float fallThreshold;

    public int MaxJumps;
    private int _jumpCount;

    public Animator animator;




    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        var h = Input.GetAxis("Horizontal");

        if (Input.GetKey(KeyCode.LeftShift) && Mathf.Abs(_rb.velocity.x) > 0)
        {
            _currentSpeed = _runSpeed;
        }
        else
        {
            _currentSpeed = _walkSpeed;
        }


        _rb.velocity = new Vector2(h * _currentSpeed, _rb.velocity.y);

        if (_rb.velocity.y < fallThreshold)
        {
            animator.SetTrigger("Fall");
        }
        if (_rb.gravityScale == -1)
        {
            animator.SetTrigger("Fall");
        }

        if (Mathf.Abs(_rb.velocity.y) <= 0 && _jumpCount == 0)
        {
            if (Mathf.Abs(h) <= 0)
            {
                animator.SetTrigger("Idle");
            }
            else
            {
                if (_currentSpeed == _runSpeed)
                {
                    animator.SetTrigger("Run");
                }
                else
                {
                    animator.SetTrigger("Walk");
                }
            }
        }


        if (h > 0 && !facingRight)
            Flip();
        else if (h < 0 && facingRight)
            Flip();

        if (Input.GetKeyDown(KeyCode.W) && _jumpCount < MaxJumps)
        {
            _rb.velocity = Vector2.up * jumpForce;
            _jumpCount++;
            //print("jump");
            animator.SetTrigger("Jump");
        }
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (_rb.velocity.y == 0)
        {
            _jumpCount = 0;
        }
    }
    public void Jump(int amount)
    {
        MaxJumps = Mathf.Clamp(MaxJumps += amount, 0, 2);
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("HouseDoor") && Input.GetKeyDown(KeyCode.E))
        {
            SceneManager.LoadScene(3);
            //findObjectOfType<AudioManager>().Play("");

        }
        if (other.gameObject.CompareTag("Door2") && Input.GetKeyDown(KeyCode.E))
        {
            SceneManager.LoadScene(4);
            //findObjectOfType<AudioManager>().Play("");
        }
        if (other.gameObject.CompareTag("Saada") && Input.GetKeyDown(KeyCode.E))
        {
            SceneManager.LoadScene(5);
            //findObjectOfType<AudioManager>().Play("");
        }


        if (other.gameObject.CompareTag("afterboss1") && Input.GetKeyDown(KeyCode.E))
        {
            SceneManager.LoadScene(6);
        }
        if (other.gameObject.CompareTag("toanger"))
        {
            SceneManager.LoadScene(7);
        }
        if (other.gameObject.CompareTag("tofinal") && Input.GetKeyDown(KeyCode.E) && canGoThruAngerDoor == true)
        {
            SceneManager.LoadScene(8);
        }
        if (other.gameObject.CompareTag("lastboss") && Input.GetKeyDown(KeyCode.E))
        {
            SceneManager.LoadScene(9);
        }
        if (other.gameObject.CompareTag("credits") && Input.GetKeyDown(KeyCode.E))
        {
            SceneManager.LoadScene(10);
        }
        if (other.gameObject.CompareTag("end") && Input.GetKeyDown(KeyCode.E))
        {
            SceneManager.LoadScene(0);
        }
            
    }
}

