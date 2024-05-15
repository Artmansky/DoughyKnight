using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Animator animator;

    private Rigidbody2D rigid;
    private Vector2 movement;
    private bool isFacingRight = true;
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        MovementInput();
    }

    void FixedUpdate()
    {
        rigid.velocity = movement * moveSpeed;
        animator.SetFloat("Velocity", Math.Abs(rigid.velocity.x));
    }

    void MovementInput()
    {
        float speedX = Input.GetAxisRaw("Horizontal");
        float speedY = Input.GetAxisRaw("Vertical");

        FlipSprite(speedX);

        movement = new Vector2(speedX, speedY).normalized;
    }

    void FlipSprite(float horizontal)
    {
        if(isFacingRight && horizontal<0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 ls = transform.localScale;
            ls.x *= -1f;
            transform.localScale = ls;
        }
    }
}