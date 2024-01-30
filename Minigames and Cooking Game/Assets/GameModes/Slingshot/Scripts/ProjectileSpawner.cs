using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileSpawner : MonoBehaviour
{
    public GameObject player1Projectile;
    public GameObject player2Projectile;

    public Vector3 SpawnLocation1;
    public Vector3 SpawnLocation2;

    void Start()
    {
        SpawnNewProjectile(1);
        SpawnNewProjectile(2);
    }

    public void SpawnNewProjectile(int player)
    {
        if (player == 1)
        {
            Instantiate(player1Projectile, SpawnLocation1, player1Projectile.transform.rotation);
        }

        if (player == 2)
        {
            Instantiate(player2Projectile, SpawnLocation2, player2Projectile.transform.rotation);
        }
    }
}
