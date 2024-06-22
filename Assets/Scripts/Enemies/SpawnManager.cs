using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private EnemySpawn[] list;
    [SerializeField] private GameObject[] enemyToSpawn;
    [SerializeField] private PlayerExperience playerExperience;
    [SerializeField] private float spawnRate = 1000f;
    private int lastLevel = 0;

    void Start()
    {
        playerExperience = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerExperience>();
        for (int i=0;i<list.Length; i++)
        {
            list[i].enemyToSpawn = enemyToSpawn;
            list[i].spawnRate = spawnRate;
        }
    }

    void Update()
    {
        if(lastLevel != playerExperience.level)
        {
            lastLevel = playerExperience.level;
            if (playerExperience.level%5==0)
            {
                Difficulty();
            }
            spawnRate -= 25;
        }
    }

    void Difficulty()
    {
        switch (playerExperience.level)
        {
            case 5:
                for (int i = 0; i < list.Length; i++)
                {
                    list[i].maxEnemyLevel = 1;
                }
                break;
            case 10:
                for(int i = 0; i < list.Length; i++)
                {
                    list[i].maxEnemyLevel = 2;
                }
                break;
            case 15:
                for (int i = 0; i < list.Length; i++)
                {
                    list[i].maxEnemyLevel = 3;
                }
                break;
            case 20:
                for (int i = 0; i < list.Length; i++)
                {
                    list[i].maxEnemyLevel = 4;
                }
                break;
            case 25:
                for (int i = 0; i < list.Length; i++)
                {
                    list[i].maxEnemyLevel = 5;
                }
                break;
            case 30:
                for (int i = 0; i < list.Length; i++)
                {
                    list[i].maxEnemyLevel = 6;
                }
                break;
        }
    }
}
