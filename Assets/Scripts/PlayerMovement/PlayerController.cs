using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using Cinemachine;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    public enum moveState{ normal, horny, depressed }
    public moveState state;

    [UnityEngine.Header("Horny Movement")]
    private Vector2 moveAmount;
    private Vector2 moveInput;
    private int random;
    public float hornySpeed;

    [UnityEngine.Header("Depressed Movement")]
    public float depressedSpeed;
    public float maxVelocity;
    private Vector3 mousePos;

    [UnityEngine.Header("Normal Movement")]
    public float gravity = 2.5f;
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

    private void Start()
    {
        animator = GetComponentInChildren<Animator>();
        rb = GetComponent<Rigidbody2D>();

        random = Random.Range(0, 3);

        state = moveState.normal;
    }

    private void Update()
    {
        if (DialogueManager.GetInstance().isPlaying) canMove = false;
        else canMove = true;

        if (!canMove)
        {
            rb.velocity = new Vector2(0, 0);
            return;
        }

        if (state == moveState.normal)
        {
            JumpCheck();
            GroundCheck();
        }
        
        Flip();
    }

    private void FixedUpdate()
    {
        if (!canMove) return;

        switch (state)
        {
            case moveState.normal:
                NormalMove();
                break;
            case moveState.horny:
                HornyMove();
                break;
            case moveState.depressed:
                DepressedMove();
                break;
        }

    }

    private void LateUpdate()
    {
        if (isGrounded && rb.velocity.magnitude > 0.1)
        {
            animator.SetBool("Walking", true);
        }
        else
        {
            animator.SetBool("Walking", false);
        }
    }

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
            if (jumpTimeCounter > 0)
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
    
    private void NormalMove()
    {
        rb.gravityScale = gravity;
        moveDirection = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(moveDirection * moveSpeed, rb.velocity.y);
    }

    private void HornyMove()
    {
        rb.gravityScale = 0f;
        switch (random)
        {
            case 0:
                moveInput = new Vector2(-Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
                break;
            case 1:
                moveInput = new Vector2(-Input.GetAxisRaw("Horizontal"), -Input.GetAxisRaw("Vertical"));
                break;
            case 2:
                moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), -Input.GetAxisRaw("Vertical"));
                break;
        }

        moveAmount = moveInput.normalized * hornySpeed;
        rb.MovePosition(rb.position + moveAmount * Time.fixedDeltaTime);
    }

    private void DepressedMove()
    {
        rb.gravityScale = 0f;
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        var mouseDir = mousePos - gameObject.transform.position;
        mouseDir.z = 0;
        mouseDir = mouseDir.normalized;

        rb.velocity = Vector2.ClampMagnitude(rb.velocity, maxVelocity);
        rb.AddForce(mouseDir * depressedSpeed);
    }

    public void SetState(moveState newState)
    {
        state = newState;
    }

    private void Flip() 
    {
        if (moveDirection > 0)
        {
            transform.localRotation = Quaternion.Euler(0, 180, 0);
        }
        else if (moveDirection < 0)
        {
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
    }
}
