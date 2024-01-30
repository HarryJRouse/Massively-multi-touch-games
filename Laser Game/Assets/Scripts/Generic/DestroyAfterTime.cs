using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterTime : MonoBehaviour
{
    public float time;

    private void Start()
    {
        StartCoroutine(DestroyAfter(time));
    }

    IEnumerator DestroyAfter(float time)
    {
        yield return new WaitForSeconds(time);
        Destroy(gameObject);
    }
}
