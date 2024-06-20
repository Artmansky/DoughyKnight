using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public bool isDying = false;
    public Animator animatorBasic;
    public GameObject attackPoint;
    public float radius;
    public LayerMask enemies;

    private Rigidbody2D rigid;
    private Vector2 movement;
    private bool isFacingRight = true;
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        animatorBasic = GetComponent<Animator>();
    }

    void Update()
    {
        MovementInput();
        if (Input.GetMouseButtonDown(0))
        {
            animatorBasic.SetBool("isAttacking", true);
        }
    }

    void FixedUpdate()
    {
        rigid.velocity = movement * moveSpeed;
        animatorBasic.SetFloat("Velocity", Math.Abs(rigid.velocity.x) + Math.Abs(rigid.velocity.y));
    }

    void MovementInput()
    {
        if (!isDying)
        {
            float speedX = Input.GetAxisRaw("Horizontal");
            float speedY = Input.GetAxisRaw("Vertical");

            FlipSprite(speedX);

            movement = new Vector2(speedX, speedY).normalized;
        }
        else
        {
            movement = Vector2.zero;
        }
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

    public void Attack()
    {
        Collider2D[] enemy = Physics2D.OverlapCircleAll(attackPoint.transform.position, radius, enemies);

        foreach(Collider2D enemyGameobject in enemy)
        {
            Debug.Log("We hit enemy");
        }
    }

    void endAttack()
    {
        animatorBasic.SetBool("isAttacking", false);
    }
}