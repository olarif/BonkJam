using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class TopDownPlayer : MonoBehaviour
{
    public float speed;

    private Rigidbody2D rb;
    private Animator anim;
    public float health;
    public float maxVelocity;
    private Vector3 mousePos;

    public Transform resetPos;

    private Vector2 moveAmount;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //anim = GetComponent<Animator>();
    }

    private void Update() 
    {

    }

    public void ResetPosition()
    {
        transform.position = resetPos.position;
    }

    private void FixedUpdate()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        var mouseDir = mousePos - gameObject.transform.position;
        mouseDir.z = 0;
        mouseDir = mouseDir.normalized;
        //mousePos.z = Camera.main.transform.position.z + Camera.main.nearClipPlane;


        //transform.position = Vector2.MoveTowards(transform.position, mousePos, speed);
        rb.velocity = Vector2.ClampMagnitude(rb.velocity, maxVelocity);
        rb.AddForce(mouseDir * speed);
        //rb.MovePosition(rb.position + moveAmount * Time.fixedDeltaTime);
    }

}
