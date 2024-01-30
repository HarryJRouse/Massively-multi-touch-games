using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpoonZone : MonoBehaviour
{
    public bool safe = false;
    public int player;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!safe)
        {
            safe = true;
            other.gameObject.tag = "Untagged";
        }
    }

}
