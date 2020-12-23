using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Line : MonoBehaviour
{
    Queue<Projectile> spawnQueue = new Queue<Projectile>();
    bool busy = false;
    public float lineXPosition;

    IEnumerator SpawnDelayCoroutine(float delay)
    {
        busy = true;

        yield return new WaitForSeconds(delay);

        busy = false;
        SpawnNextProjectile();
    }

    void SpawnNextProjectile()
    {
        if (spawnQueue.Count > 0)
            SpawnProjectile(spawnQueue.Dequeue());
    }

    public void SpawnProjectile(Projectile projectile)
    {
        if (busy)
            spawnQueue.Enqueue(projectile);
        else
        {
            Vector3 spawnPosition = new Vector3(lineXPosition, Spawner.spawningYPosition, 0);
            Instantiate(projectile.gameObject, spawnPosition, Quaternion.identity);

            StartCoroutine(SpawnDelayCoroutine(projectile.DelayAfterSpawn));
        }
    }
}
