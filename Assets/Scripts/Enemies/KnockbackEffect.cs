using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MADD;

public class KnockbackEffect : MonoBehaviour
{
    public float knockbackForce = 10f;
    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void ApplyKnockback(Vector2 knockbackDirection, float knockbackPlayer)
    {
        knockbackDirection.Normalize();
        rb.AddForce(knockbackDirection * knockbackForce * knockbackPlayer, ForceMode2D.Impulse);
    }
}
