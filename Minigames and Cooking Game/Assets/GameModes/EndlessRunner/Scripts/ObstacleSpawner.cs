using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public float speed;

    public List<GameObject> obstacles = new();

    bool canSpawn = true;
    ModeStart ms;

    void Start()
    {
        ms = FindObjectOfType<ModeStart>();  
    }

    void Update()
    {
        if (ms.modeRunning)
        {
            StartCoroutine(SpawnObstacle());
        }
    }

    IEnumerator SpawnObstacle()
    {
        if (canSpawn == true)
        {
            canSpawn = false;

            float waitTime = Random.Range(0.6f, 2f);
            int objectToSpawn = Random.Range(0, obstacles.Count + 3);

            if (objectToSpawn >= obstacles.Count)
            {
                objectToSpawn = Random.Range(0, 3);
            }

            GameObject obstacle = Instantiate(obstacles[objectToSpawn], transform.position, obstacles[objectToSpawn].transform.rotation);
            obstacle.GetComponent<Rigidbody>().velocity = new Vector3(speed, 0, 0);

            yield return new WaitForSeconds(waitTime);
            canSpawn = true;
        }
    }
}
