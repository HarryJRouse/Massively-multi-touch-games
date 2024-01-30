using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadMove : MonoBehaviour
{
    public float speed;

    private MeshRenderer _renderer;

    void Start()
    {
        _renderer = GetComponent<MeshRenderer>();
    }

    void Update()
    {
        _renderer.material.mainTextureOffset = new Vector2(Time.time * speed, 0f);
    }
}
