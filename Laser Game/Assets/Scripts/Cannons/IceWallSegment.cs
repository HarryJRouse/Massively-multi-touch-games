using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceWallSegment : MonoBehaviour
{
    public GameObject col;

    private void Start()
    {
        StartCoroutine(CollisionOn());
    }

    IEnumerator CollisionOn()
    {
        yield return new WaitForSeconds(0.1f);
        col.SetActive(true);
    }
}
