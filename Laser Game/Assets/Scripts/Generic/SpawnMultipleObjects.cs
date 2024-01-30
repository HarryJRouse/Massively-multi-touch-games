using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMultipleObjects : MonoBehaviour
{
    public Rect spawnBounds;

    public List<GameObject> objs = new();

    public bool timedSpawn = true;
    public bool randomTime = false;

    public int spawnTime;
    public int spawnTimeMax;

    bool coroutineRunning = false;

    private void Update()
    {
        if (timedSpawn)
        {
            StartCoroutine(SpawnAfterTime(spawnTime));
        }
    }

    IEnumerator SpawnAfterTime(float time)
    {
        if (!coroutineRunning)
        {
            if (randomTime)
            {
                time = Random.Range(spawnTime, spawnTimeMax);
            }
            coroutineRunning = true;
            SpawnObject();
            yield return new WaitForSeconds(time);
            coroutineRunning = false;
        }
    }


    public void SpawnObject()
    {
        Vector2 spawnPos = new Vector2(Random.Range(spawnBounds.xMin, spawnBounds.xMax), Random.Range(spawnBounds.yMin, spawnBounds.yMax));

        while (Physics2D.OverlapCircle(spawnPos, 1))
        {
            spawnPos = new Vector2(Random.Range(spawnBounds.xMin, spawnBounds.xMax), Random.Range(spawnBounds.yMin, spawnBounds.yMax));
        }
        Instantiate(objs[Random.Range(0, objs.Count)], spawnPos, Quaternion.identity);
    }
}
