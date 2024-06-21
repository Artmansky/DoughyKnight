using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnockbackEffect : MonoBehaviour
{
    public float knockbackForce = 10f; // The force of the knockback
    private Rigidbody2D rb; // The Rigidbody2D component of the enemy

    private void Awake()
    {
        // Get the Rigidbody2D component
        rb = GetComponent<Rigidbody2D>();
    }

    // This method applies the knockback effect
    public void ApplyKnockback(Vector2 knockbackDirection)
    {
        // Normalize the direction to ensure consistent knockback force
        knockbackDirection.Normalize();
        // Apply force to the Rigidbody2D component
        rb.AddForce(knockbackDirection * knockbackForce, ForceMode2D.Impulse);
    }

    // This method can be called when the enemy is hit
    public void OnHit(Vector2 attackerPosition)
    {
        // Calculate the direction from the attacker to the enemy
        Vector2 knockbackDirection = (rb.position - (Vector2)attackerPosition).normalized;
        // Apply the knockback effect
        ApplyKnockback(knockbackDirection);
    }
}
