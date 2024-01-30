using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public Vector3 maxSize;
    public Vector3 minSize;
    public int player;
    string state = "growing";
    void Update()
    {
        float x = transform.localScale.x;
        float y = transform.localScale.y;
        float z = transform.localScale.z;

        switch(state)
        {
            case "growing":
                transform.localScale = new Vector3(x + 0.05f / 5, y + 0.05f / 5, z + 0.05f / 5);
                break;
            case "shrinking":
                transform.localScale = new Vector3(x - 0.05f / 5, y - 0.05f / 5, z - 0.05f / 5);
                break;
        }

        if (x >= maxSize.x/4)
        {
            state = "shrinking";
        }

        if (x <= minSize.x)
        {
            Destroy(gameObject);
            GameObject.FindObjectOfType<Aimlabs>().SpawnTarget(player);
        }
    }
}
