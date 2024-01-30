using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterTime : MonoBehaviour
{
    public float time;

    void Start()
    {
        StartCoroutine(DestroyAfter());
    }

    IEnumerator DestroyAfter()
    {
        yield return new WaitForSeconds(time);
        Destroy(gameObject);
    }
}
