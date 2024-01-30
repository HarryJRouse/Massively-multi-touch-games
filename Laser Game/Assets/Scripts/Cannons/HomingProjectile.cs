using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HomingProjectile : MonoBehaviour
{
    public float trackingTime;
    public float speed;

    Rigidbody2D rb2d;
    Collider2D col;
    PlayerDeath pd;

    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        col = GetComponent<Collider2D>();
        pd = FindObjectOfType<PlayerDeath>();
        col.isTrigger = true;
        StartCoroutine(MoveToPlayer());
    }


    IEnumerator MoveToPlayer()
    {
        yield return new WaitForSeconds(trackingTime);
        col.isTrigger = false;

        if (GameObject.Find("KeyboardPlayer") != null)
        {
            Vector3 playerPos = GameObject.Find("KeyboardPlayer").transform.position;
            Vector2 direction = playerPos - transform.position;

            Quaternion newRotation = Quaternion.LookRotation(transform.forward, direction);

            transform.rotation = newRotation;
            rb2d.velocity = Vector2.zero;
            rb2d.velocity += new Vector2(direction.x, direction.y).normalized * speed;
        }
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
        else
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (!collision.gameObject.GetComponent<PlayerMovement>().dashing)
            {
                pd.Dead();
            }
        }
    }
}
