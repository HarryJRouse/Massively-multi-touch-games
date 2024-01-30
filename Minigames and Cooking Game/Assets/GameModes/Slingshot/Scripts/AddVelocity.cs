using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddVelocity : MonoBehaviour
{
    Vector3 initialPos;
    public float offset;
    public float velocityScale;
    public LineRenderer line1;
    public LineRenderer line2;
    public float timeTilDestruction;

    Collider col;
    ProjectileSpawner ps;

    void Start()
    {
        initialPos = gameObject.transform.position;
        col = GetComponent<Collider>();
        ps = FindObjectOfType<ProjectileSpawner>();
        col.isTrigger = true;
    }

    public void FireProjectile()
    {
        StartCoroutine(CollisionWait());
        gameObject.GetComponent<Rigidbody>().velocity = new Vector3(-(transform.position.x - initialPos.x) * velocityScale, -(transform.position.y - initialPos.y) * velocityScale, 0);
        line1.gameObject.SetActive(false);
        line2.gameObject.SetActive(false);
        StartCoroutine(DestroyObstacle());
    }

    void Update()
    {
        line1.SetPosition(0, new Vector3(initialPos.x, initialPos.y + offset, initialPos.z));
        line1.SetPosition(1, gameObject.transform.position);
        line2.SetPosition(0, new Vector3(initialPos.x, initialPos.y - offset, initialPos.z));
        line2.SetPosition(1, gameObject.transform.position);
    }

    IEnumerator DestroyObstacle()
    {
        yield return new WaitForSeconds(timeTilDestruction);
        if (gameObject.tag == "grabbable1")
        {
            ps.SpawnNewProjectile(1);
        }
        if (gameObject.tag == "grabbable2")
        {
            ps.SpawnNewProjectile(2);
        }
        Destroy(gameObject);
    }

    IEnumerator CollisionWait()
    {
        yield return new WaitForSeconds(0.1f);
        col.isTrigger = false;
    }
}
