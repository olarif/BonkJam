using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using Cinemachine;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    public ParticleSystem dust;

    [UnityEngine.Header("Movement")]
    public float moveSpeed = 5f;
    public float jumpForce = 5f;
    private float moveDirection;
    private bool isGrounded;
    [SerializeField] float groundCheckRadius = 0.2f;
    [SerializeField] Transform groundCheckCollider;

    [UnityEngine.Header("Physics")]
    public LayerMask groundLayer;
    private float jumpTimeCounter;
    public float jumpTime;
    private bool isJumping = false;

    public bool canMove = true;

    //Coyote time
    [SerializeField] private float coyoteTime = 0.1f;
    private float coyoteTimeCounter;

    //Jump buffer
    [SerializeField] private float jumpButterTime = 0.1f;
    private float jumpBufferCounter;

    private Rigidbody2D rb;
    private Animator animator;
    private Inventory inventory;

    private void Start()
    {
        animator = GetComponentInChildren<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (!canMove) return;

        GroundCheck();
        Move();
    }

    private void Awake()
    {
        inventory = new Inventory();
    }

    private void Update()
    {
        if (DialogueManager.GetInstance().isPlaying) canMove = false;
        else canMove = true;

        if (!canMove)
        {
            rb.velocity = new Vector2(0, -moveSpeed);
            return;
        }

        JumpCheck();
        Flip();

    }

    /*
    private void LateUpdate()
    {
        if (isGrounded)
        {
            animator.SetBool("Ground", true);
        } else
        {
            animator.SetBool("Ground", false);
        }

        if (rb.velocity.magnitude > 0.1)
        {
            animator.SetBool("Walking", true);
        } else
        {
            animator.SetBool("Walking", false);
        }
    }

    */

    private void GroundCheck()
    {
        isGrounded = false;

        Collider2D[] colliders = Physics2D.OverlapCircleAll(groundCheckCollider.position, groundCheckRadius - Physics.defaultContactOffset, groundLayer);

        if (colliders.Length > 0)
        {
            isGrounded = true;
        }
    }

    private void JumpCheck()
    {
        if (isGrounded)
        {
            coyoteTimeCounter = coyoteTime;
        }
        else
        {
            coyoteTimeCounter -= Time.deltaTime;
        }

        if (Input.GetButtonDown("Jump"))
        {
            jumpTimeCounter = jumpTime;
            jumpBufferCounter = jumpButterTime;
        }
        else
        {
            jumpBufferCounter -= Time.deltaTime;
        }

        if (coyoteTimeCounter > 0f && jumpBufferCounter > 0f)
        {
            isJumping = true;
            Jump();
            jumpBufferCounter = 0f;
        }

        if(Input.GetButton("Jump") && isJumping)
        {
            if(jumpTimeCounter > 0)
            {
                Jump();
                jumpTimeCounter -= Time.deltaTime;
            } else
            {
                isJumping = false;
            }
        }

        if (Input.GetButtonUp("Jump"))
        {
            isJumping = false;
            coyoteTimeCounter = 0f;
        }
    }

    private void Jump()
    {
        rb.velocity = Vector2.up * jumpForce;
    }
    
    private void Move()
    {
        moveDirection = Input.GetAxisRaw("Horizontal");

        rb.velocity = new Vector2(moveDirection * moveSpeed, rb.velocity.y);
    }

    private void Flip() 
    {
        /*

        var mouse = new Vector2(Input.mousePosition.x, Screen.height - Input.mousePosition.y);
        var playerScreenPoint = Camera.main.WorldToScreenPoint(transform.position);

        if(moveDirection > 0 || mouse.x > playerScreenPoint.x)
        {
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        } else if (moveDirection < 0 || mouse.x < playerScreenPoint.x)
        {
            transform.localRotation = Quaternion.Euler(0, 180, 0);
        }

        */

        if (moveDirection > 0)
        {
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
        else if (moveDirection < 0)
        {
            transform.localRotation = Quaternion.Euler(0, 180, 0);
        }
    }
    
    void CreateDust()
    {
        dust.Play();
    }
}
