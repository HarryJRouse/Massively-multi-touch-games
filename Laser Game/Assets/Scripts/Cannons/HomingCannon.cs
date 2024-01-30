using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingCannon : CannonBase
{
    public GameObject projectile;

    public float reloadTime;
    public float projectileSpeed;
    public float switchBackTime;

    void Update()
    {
        if (fireStage == "firing")
        {
            StartCoroutine(FireProjectiles(reloadTime));
        }
    }

    public override void Fire()
    {
        fireStage = "firing";
    }

    IEnumerator FireProjectiles(float interval)
    {
        if (!fireCoroutineRunning)
        {
            fireCoroutineRunning = true;

            GameObject proj = Instantiate(projectile, firePoints[0].position, transform.parent.gameObject.transform.rotation);
            proj.GetComponent<Rigidbody2D>().velocity = (endPoints[0].position - firePoints[0].position) / 5 * projectileSpeed;

            yield return new WaitForSeconds(interval);

            fireStage = "off";
            fireCoroutineRunning = false;
        }
    }

}
