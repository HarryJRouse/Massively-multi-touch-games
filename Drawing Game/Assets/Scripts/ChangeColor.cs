using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColor : MonoBehaviour
{
    [SerializeField] LineRenderer red;
    [SerializeField] LineRenderer blue;
    [SerializeField] LineRenderer green;
    [SerializeField] LineRenderer darkBlue;
    [SerializeField] LineRenderer yellow;
    [SerializeField] LineRenderer pink;
    [SerializeField] LineRenderer purple;
    [SerializeField] LineRenderer orange;
    [SerializeField] LineRenderer brown;
    [SerializeField] LineRenderer black;

    [SerializeField] TouchScreenDrawing tsd;

    public void Red()
    {
        tsd.trailPrefab = red;
    }

    public void Blue()
    {
        tsd.trailPrefab = blue;
    }

    public void Green()
    {
        tsd.trailPrefab = green;
    }

    public void DarkBlue()
    {
        tsd.trailPrefab = darkBlue;
    }

    public void Yellow()
    {
        tsd.trailPrefab = yellow;
    }

    public void Pink()
    {
        tsd.trailPrefab = pink;
    }

    public void Purple()
    {
        tsd.trailPrefab = purple;
    }

    public void Orange()
    {
        tsd.trailPrefab = orange;
    }

    public void Brown()
    {
        tsd.trailPrefab = brown;
    }

    public void Black()
    {
        tsd.trailPrefab = black;
    }
}
