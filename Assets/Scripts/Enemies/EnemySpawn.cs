using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    private Transform target;
    private float distance;
    public float spawnRate = 1f;
    public int maxEnemyLevel = 0;
    public GameObject[] enemyToSpawn;

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
                int randomEnemy = Random.Range(0, maxEnemyLevel+1);
                Instantiate(enemyToSpawn[randomEnemy], transform.position, Quaternion.identity);
            }
        }
    }

    void GetTarget()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }
}
