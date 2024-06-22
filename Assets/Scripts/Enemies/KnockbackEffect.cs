using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MADD;

[Docs("This script applies a knockback effect to the object it is attached to.")]
public class KnockbackEffect : MonoBehaviour
{
    public float knockbackForce = 10f;
    private Rigidbody2D rb;

    [Docs("This method sets rigidbody value.")]
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    [Docs("This method applies knockback to the object.")]
    public void ApplyKnockback(Vector2 knockbackDirection, float knockbackPlayer)
    {
        knockbackDirection.Normalize();
        rb.AddForce(knockbackDirection * knockbackForce * knockbackPlayer, ForceMode2D.Impulse);
    }
}
