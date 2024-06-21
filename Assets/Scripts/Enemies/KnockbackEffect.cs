using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnockbackEffect : MonoBehaviour
{
    public float knockbackForce = 10f;
    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void ApplyKnockback(Vector2 knockbackDirection)
    {
        knockbackDirection.Normalize();
        rb.AddForce(knockbackDirection * knockbackForce, ForceMode2D.Impulse);
    }

    public void OnHit(Vector2 attackerPosition)
    {
        Vector2 knockbackDirection = (rb.position - (Vector2)attackerPosition).normalized;
        ApplyKnockback(knockbackDirection);
    }
}
