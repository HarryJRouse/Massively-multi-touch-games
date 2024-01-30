using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPowerUps : MonoBehaviour
{
    public GameObject lockedOverlay;
    public GameObject slowedOverlay;
    public Color fastColor;


    PlayerMovement pm;
    RotateAround ra;

    float originalSpeed;
    float originalDash;

    Color originalColour;

    bool coroutineRunning = false;

    private void Start()
    {
        ra = FindObjectOfType<RotateAround>();
        pm = FindObjectOfType<PlayerMovement>();
        originalSpeed = pm.speed;
        originalDash = pm.dashSpeed;

        originalColour = pm.normalColour;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("PowerUp"))
        {
            switch(collision.gameObject.GetComponent<PowerUp>().powerUpType)
            {
                case "fireball":
                    Destroy(collision.gameObject);
                    StartCoroutine(PlayerSpeedUp());
                    break;
                case "homing":
                    StartCoroutine(LockCannons());
                    Destroy(collision.gameObject);
                    break;
                case "ice":
                    StartCoroutine(SlowCannons());
                    Destroy(collision.gameObject);
                    break;
            }
        }
    }

    IEnumerator PlayerSpeedUp()
    {
        if (!coroutineRunning)
        {
            coroutineRunning = true;
            float originalSpeed = pm.speed;
            float originalDash = pm.dashSpeed;

            Color originalColour = pm.normalColour;

            pm.playerSprite.color = fastColor;
            pm.normalColour = fastColor;

            pm.speed += 5;
            pm.dashSpeed += 5;

            yield return new WaitForSeconds(5);
            
            pm.speed = originalSpeed;
            pm.dashSpeed = originalDash;

            pm.playerSprite.color = originalColour;
            pm.normalColour = originalColour;

            coroutineRunning = false;
        }
    }

    IEnumerator LockCannons()
    {
        if (!coroutineRunning)
        {
            coroutineRunning = true;
            
            lockedOverlay.SetActive(true);

            float originalRotateFactor = ra.rotateFactor;

            ra.rotateFactor = 0;

            yield return new WaitForSeconds(3);

            ra.rotateFactor = originalRotateFactor;
            lockedOverlay.SetActive(false);

            coroutineRunning = false;
        }
    }

    IEnumerator SlowCannons()
    {
        if (!coroutineRunning)
        {
            coroutineRunning = true;

            slowedOverlay.SetActive(true);

            float originalRotateFactor = ra.rotateFactor;

            ra.rotateFactor -= 25;

            yield return new WaitForSeconds(5);

            ra.rotateFactor = originalRotateFactor;
            slowedOverlay.SetActive(false);

            coroutineRunning = false;
        }
    }
}
