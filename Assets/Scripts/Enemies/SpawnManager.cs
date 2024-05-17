using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private EnemySpawn[] list;
    [SerializeField] private GameObject[] enemyToSpawn;
    [SerializeField] private float spawnRate = 1f;

    void Start()
    {
        for (int i=0;i<list.Length; i++)
        {
            list[i].enemyToSpawn = enemyToSpawn;
            list[i].spawnRate = spawnRate;
        }
    }
}
