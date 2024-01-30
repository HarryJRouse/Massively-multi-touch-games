using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NegativeGravity : MonoBehaviour
{
    public Vector3 gravity;
    Rigidbody _rb;

    void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        _rb.useGravity = false;
        gravity = Physics.gravity;
        ReverseGravity();
    }

    void FixedUpdate()
    {
        _rb.AddForce(gravity, ForceMode.Acceleration);
    }

    void ReverseGravity() => gravity *= -1;
}
