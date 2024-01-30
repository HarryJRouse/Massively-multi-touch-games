using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Projectile : MonoBehaviour
{
    PlayerDeath pd;

    private void Start()
    {
        pd = FindObjectOfType<PlayerDeath>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            if (!collision.collider.gameObject.GetComponent<PlayerMovement>().dashing)
            {
                pd.Dead();
            }
        }
    }
}
