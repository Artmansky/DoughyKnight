using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    private Transform target;
    private float distance;
    private bool canSpawn = true;
    public float spawnRate = 1f;
    public GameObject enemyToSpawn;
    // Start is called before the first frame update
    void Start()
    {
        GetTarget();
        StartCoroutine(Spawner());
    }

    IEnumerator Spawner()
    {
        WaitForSeconds wait = new WaitForSeconds(spawnRate);

        while (true)
        {
            yield return wait;

            distance = Vector2.Distance(transform.position, target.position);
            if (distance > 12.5)
            {
                Instantiate(enemyToSpawn, transform.position, Quaternion.identity);
            }
        }
    }

    void GetTarget()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }
}
