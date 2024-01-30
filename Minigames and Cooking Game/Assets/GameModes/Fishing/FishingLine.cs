using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishingLine : MonoBehaviour
{
    public LineRenderer line;
    public Transform sharkHeadPosition;
    public Vector3 initialPosition;
    public Vector3 finalPosition;
    public GameObject shark;

    GameMode gm;

    void Start()
    {
        gm = FindObjectOfType<GameMode>();
    }

    // Update is called once per frame
    void Update()
    {
        line.SetPosition(1, sharkHeadPosition.position);
        shark.transform.position = new Vector3(initialPosition.x - gm.player1score, initialPosition.y, initialPosition.z);
    }

}
