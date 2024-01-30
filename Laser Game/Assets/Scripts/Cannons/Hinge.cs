using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hinge : MonoBehaviour
{
    public Transform point;
    public int axis = 1;
    public Vector3 worldPoint;

    void Start()
    {
        worldPoint = transform.position;
    }
}
