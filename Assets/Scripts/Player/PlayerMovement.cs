using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MADD;

[Docs("Class that controls the player movement, attack and flip sprite")]
public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public bool isDying = false;
    public Animator animatorBasic;
    public GameObject attackPoint;
    public float damage = 2f;
    public float knockbackForce = 1f;
    public float radius;
    public LayerMask enemies;

    private Rigidbody2D rigid;
    private Vector2 movement;
    private bool isFacingRight = true;

    [Docs("Start is called before the first frame update")]
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        animatorBasic = GetComponent<Animator>();
    }

    [Docs("Update is called once per frame, it checks if player clicked attack button or movement keys")]
    void Update()
    {
        MovementInput();
        if (Input.GetMouseButtonDown(0))
        {
            animatorBasic.SetBool("isAttacking", true);
        }
    }

    [Docs("FixedUpdate is called once per frame, it moves the player based on the movement vector")]
    void FixedUpdate()
    {
        rigid.velocity = movement * moveSpeed;
        animatorBasic.SetFloat("Velocity", Math.Abs(rigid.velocity.x) + Math.Abs(rigid.velocity.y));
    }

    [Docs("Method that checks if player is moving and sets the movement vector")]
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

    [Docs("Method that flips the sprite based on the horizontal movement")]
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

    [Docs("Method that checks if player is attacking and calls the Attack method, plus applies knockback direction")]
    void Attack()
    {
        Collider2D[] enemy = Physics2D.OverlapCircleAll(attackPoint.transform.position, radius, enemies);

        foreach(Collider2D enemyGameobject in enemy)
        {
            enemyGameobject.GetComponent<Enemy>().TakeDamage(damage);
            if (isFacingRight)
            {
                enemyGameobject.GetComponent<KnockbackEffect>().ApplyKnockback(new Vector2(1, 0),knockbackForce);
            }
            else
            {
                enemyGameobject.GetComponent<KnockbackEffect>().ApplyKnockback(new Vector2(-1, 0),knockbackForce);
            }
        }
    }

    [Docs("Method that sets the isAttacking parameter to false")]
    void endAttack()
    {
        animatorBasic.SetBool("isAttacking", false);
    }

    [Docs("Method that draws a wire sphere around the attack point")]
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(attackPoint.transform.position, radius);
    }
}