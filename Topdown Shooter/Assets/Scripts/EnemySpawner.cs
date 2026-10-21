using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] List<Transform> enemySpawnPositions;
    [SerializeField] float spawnDelay;

    private void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    IEnumerator SpawnEnemy()
    {
        yield return new WaitForSeconds(spawnDelay);

        Instantiate(enemyPrefab, enemySpawnPositions[Random.Range(0, enemySpawnPositions.Count)].position, Quaternion.identity);
        StartCoroutine(SpawnEnemy());
    }
}
