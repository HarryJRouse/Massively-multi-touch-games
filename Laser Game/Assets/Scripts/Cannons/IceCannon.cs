using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceCannon : CannonBase
{
    public GameObject projectile;
    public GameObject initialWallSegement;
    public GameObject buildUpParticles;

    public float reloadTime;
    public float projectileSpeed;
    public float switchBackTime;

    GameObject particles;

    void Update()
    {
        if (fireStage == "firing")
        {
            if (particles != null)
            {
                particles.transform.position = firePoints[0].position;
                particles.transform.parent = gameObject.transform;
            }
            StartCoroutine(LaserBuildUp());
        }
    }

    public override void Fire()
    {
        fireStage = "firing";
    }

    IEnumerator LaserBuildUp()
    {
        if (!fireCoroutineRunning)
        {
            fireCoroutineRunning = true;

            fireStage = "warmingUp";

            particles = Instantiate(buildUpParticles, firePoints[0].position, transform.parent.gameObject.transform.rotation);

            yield return new WaitForSeconds(3);

            GameObject proj = Instantiate(projectile, firePoints[0].position, Quaternion.identity);
            proj.GetComponent<Rigidbody2D>().velocity = (endPoints[0].position - firePoints[0].position) / 5 * projectileSpeed;
            Instantiate(initialWallSegement, firePoints[0].position, transform.parent.gameObject.transform.rotation);

            fireStage = "off";
            yield return new WaitForSeconds(reloadTime);
            fireCoroutineRunning = false;
        }
    }
}
