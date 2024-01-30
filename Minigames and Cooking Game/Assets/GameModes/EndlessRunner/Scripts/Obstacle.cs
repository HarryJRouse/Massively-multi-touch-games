using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public float timeTilDestruction;

    GameMode gm;

    void Start()
    {
        gm = FindObjectOfType<GameMode>();
        StartCoroutine(DestroyObstacle());
    }

    IEnumerator DestroyObstacle()
    {
        yield return new WaitForSeconds(timeTilDestruction);
        Destroy(gameObject);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("p1"))
        {
            gm.ModeEnded(2);
        }
        if (other.CompareTag("p2"))
        {
            gm.ModeEnded(1);
        }
    }
}
