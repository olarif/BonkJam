using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using Cinemachine;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class FishController : MonoBehaviour
{
    [UnityEngine.Header("Movement")]
    public float moveSpeed = 5f;
    public float rotationSpeed = 2f;
    private float horizontalInput;
    private float verticalInput;

    public bool canMove = true;

    private Rigidbody2D rb;
    private Animator animator;

    private void Start()
    {
        animator = GetComponentInChildren<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (!canMove) return;

        Move();
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
    }
    
    private void Move()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        Vector2 movementDirection = new Vector2(horizontalInput, verticalInput);
        float inputMagnitude = Mathf.Clamp01(movementDirection.magnitude);
        movementDirection.Normalize();

        transform.Translate(movementDirection * moveSpeed * inputMagnitude * Time.deltaTime, Space.World);

        if(movementDirection != Vector2.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(Vector3.forward, movementDirection);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }
    }

}
