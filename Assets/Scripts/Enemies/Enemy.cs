using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Transform target;
    public float speed = 3f;

    void Start()
    {
        GetTarget();
    }

    void FixedUpdate()
    {
        transform.position = Vector3.MoveTowards(this.transform.position, target.position, speed * Time.deltaTime);
    }

    void GetTarget()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }
}
