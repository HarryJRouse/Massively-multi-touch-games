using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankProjectile : MonoBehaviour
{
    public ParticleSystem explosion;

    GameMode gm;

    void Start()
    {
        gm = FindObjectOfType<GameMode>();
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.CompareTag("p2"))
        {
            gm.IncrementScore(1);
            Destroy(collision.collider.gameObject);
        }
        if (collision.collider.CompareTag("p1"))
        {
            gm.IncrementScore(2);
            Destroy(collision.collider.gameObject);
        }
        Instantiate(explosion, gameObject.transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
