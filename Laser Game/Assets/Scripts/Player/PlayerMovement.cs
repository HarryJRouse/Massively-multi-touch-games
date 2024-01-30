using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public float dashSpeed;
    public float dashCooldown;

    public bool dashing = false;

    public string playerSide = "left";
    
    public SpriteRenderer playerSprite;

    public GameObject dashClone;

    public Color normalColour;
    public Color noDashColour;
    public Color dashingColor;

    float dashTime = 0;
    bool canDash = true;
    bool coroutineRunning = false;

    void Start()
    {
        playerSide = FindObjectOfType<PlayerSettings>().playerSide;
    }

    void Update()
    {
        Vector3 movement;
        switch (playerSide)
        {
            case "left":
                movement = new Vector3(Input.GetAxisRaw("Vertical"), -Input.GetAxisRaw("Horizontal"), 0);
                break;

            case "right":
                movement = new Vector3(-Input.GetAxisRaw("Vertical"), Input.GetAxisRaw("Horizontal"), 0);
                break;

            case "up":
                movement = new Vector3(-Input.GetAxisRaw("Horizontal"), -Input.GetAxisRaw("Vertical"), 0);
                break;

            case "down":
                movement = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), 0);
                break;

            default:
                movement = new Vector3(Input.GetAxisRaw("Vertical"), -Input.GetAxisRaw("Horizontal"), 0);
                break;
        }

        if (Input.GetButtonDown("Jump") && canDash)
        {
            StartCoroutine(Dash());
        }

        string obstacle = CheckForCollison(movement);
        if (obstacle != "none")
        {
            if (obstacle == "x")
            {
                movement = new Vector3(0, movement.y, 0);
            }
            else if (obstacle == "y")
            {
                movement = new Vector3(movement.x, 0, 0);
            }
            if (obstacle == "xy")
            {
                movement = Vector3.zero;
            }
        }
        transform.Translate(movement * Time.deltaTime * speed);

        if (dashing)
        {
            Instantiate(dashClone, transform.position, transform.rotation);
        }

        if (!canDash)
        {
            if (dashTime < dashCooldown)
            {
                playerSprite.color = noDashColour;
                dashTime += Time.deltaTime;
            }
            else
            {
                playerSprite.color = normalColour;
                canDash = true;
                dashTime = 0;
            }
        }
    }


    IEnumerator Dash()
    {
        if (!coroutineRunning)
        {
            coroutineRunning = true;
            dashing = true;
            gameObject.GetComponent<Collider2D>().isTrigger = true;

            float prevSpeed = speed;
            speed = dashSpeed;

            gameObject.GetComponent<SpriteRenderer>().color = dashingColor;

            yield return new WaitForSeconds(0.1f);

            speed = prevSpeed;
            gameObject.GetComponent<SpriteRenderer>().color = normalColour;

            dashing = false;
            gameObject.GetComponent<Collider2D>().isTrigger = false;
            canDash = false;
            coroutineRunning = false;
        }
    }

    string CheckForCollison(Vector3 movement)
    {
        Physics2D.queriesHitTriggers = false;
        RaycastHit2D hit = Physics2D.Raycast(transform.position + Vector3.Normalize(movement) / 4, movement, 0.1f);

        if (hit && hit.collider.CompareTag("obstacle"))
        {
            Vector3 secondCast = new Vector3(movement.x, 0, 0);
            RaycastHit2D hit2 = Physics2D.Raycast(transform.position + Vector3.Normalize(secondCast) / 3, secondCast, 0.1f);
            if (hit2 && (hit2.collider.CompareTag("obstacle") || hit2.collider.CompareTag("PowerUp")))
            {
                Vector3 thirdCast = new Vector3(0, movement.y, 0);
                RaycastHit2D hit3 = Physics2D.Raycast(transform.position + Vector3.Normalize(thirdCast) / 3, thirdCast, 0.1f);
                if (hit3 && (hit3.collider.CompareTag("obstacle") || hit3.collider.CompareTag("PowerUp")))
                {
                    return "xy";
                }
                return "x";
            }
            Vector3 thirdCast2 = new Vector3(0, movement.y, 0);
            RaycastHit2D hit32 = Physics2D.Raycast(transform.position + Vector3.Normalize(thirdCast2) / 3, thirdCast2, 0.1f);
            if (hit32 && (hit32.collider.CompareTag("obstacle") || hit32.collider.CompareTag("PowerUp")))
            {
                return "y";
            }
        }
        return "none";
    }
}
