using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{
    [SerializeField] Projectile projectilePrefab;

    //params
    [Header("Time delay in seconds")]
    [Range(0.0f, 30.0f)]
    [SerializeField] float minSpawnDelay = 0f, maxSpawnDelay = 1f, initialSpawnDelay = 1f;

    [Header("Probability in the range from 0 to 1")]
    [Range(0.0f, 1.0f)]
    [SerializeField] float doubleSpawnChance = 0.0f;

    [Header("How many objects should be spawned at a time")]
    [Range(0, 10)]
    [SerializeField] int objectsPerSpawn = 1;

    Coroutine spawnCoroutine;

    public void StartSpawning()
    {
        spawnCoroutine = StartCoroutine(SpawnCoroutine(initialSpawnDelay));
    }

    public void StopSpawning()
    {
        StopCoroutine(spawnCoroutine);
    }

    IEnumerator SpawnCoroutine(float spawnDelay)
    {
        yield return new WaitForSeconds(spawnDelay);    //waiting

        SpawnProjectile();
        spawnCoroutine = StartCoroutine(SpawnCoroutine(Random.Range(minSpawnDelay, maxSpawnDelay))); //restart spawning coroutine
    }

    void SpawnProjectile()
    {
        int lineNumber = Random.Range(0, Spawner.numberOfLines);
        Spawner.SpawnObject(projectilePrefab, lineNumber, objectsPerSpawn);  //spawning first rocket

        if (Random.value <= doubleSpawnChance)  //rolling if second rocket should spawn
            Spawner.SpawnObject(projectilePrefab, Spawner.GetRandomNeighbouringLine(lineNumber), objectsPerSpawn);   //spawning on a random neighbouring line
    }

    void TestSpawnOnAllLines()
    {
        for (int i = 0; i < Spawner.numberOfLines; i++)
            Spawner.SpawnObject(projectilePrefab, i, objectsPerSpawn);
    }
}
