using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Transform target;
    public float speed = 3f;

    // Start is called before the first frame update
    void Start()
    {
        GetTarget();
    }

    // Update is called once per frame
    void Update()
    {
        if (!target) GetTarget();
    }

    void FixedUpdate()
    {
        transform.position = Vector3.MoveTowards(this.transform.position, target.position, speed*Time.deltaTime);
    }

    void GetTarget()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }
}
