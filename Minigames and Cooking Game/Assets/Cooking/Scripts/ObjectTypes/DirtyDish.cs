using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirtyDish : MonoBehaviour
{
    public int dishState = 0;
    public int dishWash = 50;

    Sink s;

    void Start()
    {
        s = FindObjectOfType<Sink>();    
    }

    public void WashDish()
    {
        dishState++;
        if (dishState >= dishWash)
        {
            s.EmptySink();
        }
    }
}
