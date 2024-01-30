using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceProjectile : MonoBehaviour
{
    public GameObject wallSegment;

    public float wallInterval;

    private void Start()
    {
        StartCoroutine(CollidersOn());
    }

    void Update()
    {
        SpawnWall();
    }

    void SpawnWall()
    {
        Instantiate(wallSegment, transform.position, transform.rotation);
    }

    IEnumerator CollidersOn()
    {
        yield return new WaitForSeconds(0.1f);
        GetComponent<Collider2D>().isTrigger = false;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
}
