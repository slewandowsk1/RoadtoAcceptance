﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;
//using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{

    public float speed;
    public float jumpForce;
    //public bool canMove;

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
        _rb.velocity = new Vector2(h * speed, _rb.velocity.y);

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
                animator.SetTrigger("Walk");
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
            print("jump");
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
        if (other.gameObject.CompareTag("Finish") && Input.GetKeyDown(KeyCode.W))
        {
            SceneManager.LoadScene(2);
        }
    }
}