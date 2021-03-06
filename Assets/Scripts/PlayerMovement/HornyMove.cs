using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class HornyMove : MonoBehaviour
{
    public float speed;

    private Rigidbody2D rb;
    private Animator anim;
    public float health;
    public float maxVelocity;
    private Vector3 mousePos;
    private Vector2 moveInput;

    public Transform resetPos;

    private int random;

    private Vector2 moveAmount;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        random = Random.Range(0, 3);

    }

    public void ResetPosition()
    {
        transform.position = resetPos.position;
    }

    private void Update() 
    {
        if (rb.velocity.magnitude > 0.1)
        {
            anim.SetBool("Walking", true);
        }
        else
        {
            anim.SetBool("Walking", false);
        }

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

        moveAmount = moveInput.normalized * speed;

        if (moveInput == new Vector2(-1,0))
        {
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
        else
        {
            transform.localRotation = Quaternion.Euler(0, 180, 0);
        }
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + moveAmount * Time.fixedDeltaTime);
    }
}
