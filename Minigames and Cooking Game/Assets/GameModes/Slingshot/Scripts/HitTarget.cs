using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitTarget : MonoBehaviour
{
    public string playerObjectTag;

    ProjectileSpawner ps;
    GameMode gm;

    void Start()
    {
        gm = FindObjectOfType<GameMode>();
        ps = FindObjectOfType<ProjectileSpawner>();
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "grabbable1" && collision.collider.CompareTag(playerObjectTag))
        {
            gm.IncrementScore(1);
            Destroy(collision.collider.gameObject);
            ps.SpawnNewProjectile(1);
            Destroy(gameObject);
        }
        if (collision.collider.tag == "grabbable2" && collision.collider.CompareTag(playerObjectTag))
        {
            gm.IncrementScore(2);
            Destroy(collision.collider.gameObject);
            ps.SpawnNewProjectile(2);
            Destroy(gameObject);
        }
    }
}
