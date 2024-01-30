using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puck : MonoBehaviour
{
    public HockeyManager hockeyManager;

    Rigidbody2D rb;
    Vector3 defaultScale;
    Transform sprite;

    void Awake()
    {
        hockeyManager = FindObjectOfType<HockeyManager>();
        rb = GetComponent<Rigidbody2D>();
        sprite = transform.Find("PuckSprite");
        defaultScale = sprite.localScale;
    }

    private void FixedUpdate()
    {
        //sprite.localScale = new Vector3(defaultScale.x + rb.velocity.x/30, defaultScale.y + rb.velocity.y/30, defaultScale.z);

        if (rb.velocity.magnitude > 100)
        {
            rb.velocity = new Vector2(rb.velocity.x - 1, rb.velocity.y - 1);
        }

        if (transform.position.x > 15 || transform.position.y > 6 || transform.position.x < -15 || transform.position.y < -6)
        {
            hockeyManager.SpawnNewPuck(1);
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Collider2D>().tag == "Goal1")
        {
            hockeyManager.IncrementScore(2);
            Destroy(gameObject);
        }
        if (collision.GetComponent<Collider2D>().tag == "Goal2")
        {
            hockeyManager.IncrementScore(1);
            Destroy(gameObject);
        }
    }
}
