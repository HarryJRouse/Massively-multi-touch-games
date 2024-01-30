using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    public GameObject spawnArea;
    public int amountOfEachObject;
    public List<GameObject> objectsToSpawn;


    void Start()
    {
        foreach(GameObject obj in objectsToSpawn)
        {
            for(int i=0; i<amountOfEachObject;i++)
            {
                Bounds spawnBounds = spawnArea.GetComponent<Collider>().bounds;
                float spawnPointx = Random.Range(spawnBounds.min.x, spawnBounds.max.x);
                float spawnPointy = Random.Range(spawnBounds.min.y, spawnBounds.max.y);
                Instantiate(obj, new Vector3(spawnPointx, spawnPointy, 0), obj.transform.rotation);
            }
        }
    }
}
