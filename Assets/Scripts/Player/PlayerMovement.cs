using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;

    private Rigidbody2D rigid;
    private Vector2 movement;
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        MovementInput();
    }

    void FixedUpdate()
    {
        rigid.velocity = movement * moveSpeed;
    }

    void MovementInput()
    {
        float speedX = Input.GetAxisRaw("Horizontal");
        float speedY = Input.GetAxisRaw("Vertical");

        movement = new Vector2(speedX, speedY).normalized;
    }
}