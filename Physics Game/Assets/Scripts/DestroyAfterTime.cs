using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterTime : MonoBehaviour
{
    public float time;
    void Start()
    {
        StartCoroutine(DestroyObject());
    }

    IEnumerator DestroyObject()
    {
        yield return new WaitForSeconds(time);

        Destroy(gameObject);
    }
}
