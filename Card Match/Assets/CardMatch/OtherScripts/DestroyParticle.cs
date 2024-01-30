using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyParticle : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(DestroyAfterTime());
    }

    IEnumerator DestroyAfterTime()
    {
        yield return new WaitForSeconds(3);
        Destroy(gameObject);
    }
}
