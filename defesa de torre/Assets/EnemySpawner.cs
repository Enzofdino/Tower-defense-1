using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private GameObject[] enemyPrefabs;

    [Header("Attributes")]
    [SerializeField] private int baseEnemies = 8;
    [SerializeField] private float enemiesPerSecond = 0.8f;
    [SerializeField] private float timebetweenWaves = 10f;

    private int currentwave = 1;
    private float timesinceLastSpawn;
    private int enemiesAlive;
    private int enemiesLeftToSpawn;

    private void Start()
    {
        enemiesLeftToSpawn = baseEnemies;
    }

    private void EnemiesPerwave()
    {

    }
}
