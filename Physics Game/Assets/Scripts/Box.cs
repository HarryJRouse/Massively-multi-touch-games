using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    [SerializeField] ParticleSystem particles;

    public int colorIndex;

    public PatternManager pm;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("ball"))
        {
            pm.CheckPattern(colorIndex);
            Instantiate(particles, other.gameObject.transform.position, transform.rotation);
            Destroy(other.gameObject);
        }
    }
}
