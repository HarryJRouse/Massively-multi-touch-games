using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CannonBase : MonoBehaviour
{
    public List<Transform> firePoints = new();
    public List<Transform> endPoints = new();

    public bool fireCoroutineRunning = false;

    public string fireStage = "off";

    public abstract void Fire();
}
