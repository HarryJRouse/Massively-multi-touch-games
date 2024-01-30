using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Handle : MonoBehaviour
{
    public Vector2 velocity;
    public Vector2 current;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Puck")
        {
            Rigidbody2D rb2d = collision.collider.GetComponent<Rigidbody2D>();
            Vector2 direction = collision.collider.transform.position - new Vector3(current.x, current.y, collision.collider.transform.position.z);
            rb2d.velocity = direction * velocity.magnitude;
        }
    }
}
