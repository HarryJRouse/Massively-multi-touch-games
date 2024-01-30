using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LaserCannon : CannonBase
{
    List<Vector3> finalFirePoints = new();
    List<Vector3> finalEndPoints = new();

    public LineRenderer laserLine;
    public GameObject buildUpParticles;

    GameObject particles;
    PlayerDeath pd;

    private void Start()
    {
        pd = FindObjectOfType<PlayerDeath>();
    }

    void Update()
    {
        switch(fireStage)
        {
            case "firing":
                ShootLaser();
                break;

            case "warmingUp":
                if (particles != null)
                {
                    particles.transform.position = firePoints[0].position;
                    particles.transform.parent = gameObject.transform;
                }
                break;
            
            default:
                break;
        }
    }

    public override void Fire()
    {
        StartCoroutine(LaserBuildUp());
    }

    IEnumerator LaserBuildUp()
    {
        if (!fireCoroutineRunning)
        {
            fireCoroutineRunning = true;

            fireStage = "warmingUp";

            particles = Instantiate(buildUpParticles, firePoints[0].position, transform.parent.gameObject.transform.rotation);

            yield return new WaitForSeconds(3);

            SetFinalLaserPos();

            fireStage = "firing";

            VisualiseLaser();

            yield return new WaitForSeconds(0.5f);

            laserLine.SetPosition(0, Vector3.zero);
            laserLine.SetPosition(1, Vector3.zero);

            fireStage = "off";

            finalFirePoints.Clear();
            finalEndPoints.Clear();

            fireCoroutineRunning = false;
        }
    }

    void SetFinalLaserPos()
    {
        int i = 0;
        while (i < firePoints.Count)
        {
            finalFirePoints.Add(firePoints[i].position);
            finalEndPoints.Add(endPoints[i].position);
            i++;
        }
    }

    void VisualiseLaser()
    {
        RaycastHit2D ray = Physics2D.Raycast(firePoints[0].position, endPoints[0].position - firePoints[0].position);
        if (ray && !ray.collider.CompareTag("Projectile"))
        {
            laserLine.SetPosition(0, firePoints[0].position);
            laserLine.SetPosition(1, ray.point);
        }
        else
        {
            laserLine.SetPosition(0, firePoints[0].position);
            laserLine.SetPosition(1, endPoints[0].position);
        }
    }
    void ShootLaser()
    {
        Physics2D.queriesHitTriggers = false;

        foreach (Vector3 t in finalFirePoints)
        {
            RaycastHit2D hit = Physics2D.Raycast(t, finalEndPoints[finalFirePoints.IndexOf(t)] - t);
            if (hit && hit.collider.CompareTag("Player"))
            {
                if (!hit.collider.gameObject.GetComponent<PlayerMovement>().dashing)
                {
                    pd.Dead();
                }
            }
        }
    }
}
