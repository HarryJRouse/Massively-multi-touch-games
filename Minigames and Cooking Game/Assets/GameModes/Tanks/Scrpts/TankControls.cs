using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankControls : MonoBehaviour
{
    public GameObject projectile;
    public Transform firePoint;

    public float zSpeed;
    public float xSpeed;
    public float unitsToMoveBy;

    bool isMoving = false;

    public void TurnLeft()
    {
        gameObject.transform.Rotate(Vector3.up, 90);
    }

    public void TurnRight()
    {
        gameObject.transform.Rotate(Vector3.down, 90);
    }

    public void MoveForward()
    {
        StartCoroutine(Move(0.5f));
    }

    public void Fire()
    {
        GameObject obj = Instantiate(projectile, firePoint.transform.position, projectile.transform.rotation);
        if (transform.forward == new Vector3(1, 0, 0))
        {
            obj.GetComponent<Rigidbody>().velocity = new Vector3(0, xSpeed, -zSpeed);
        }
        else if (transform.forward == new Vector3(-1, 0, 0))
        {
            obj.GetComponent<Rigidbody>().velocity = new Vector3(0, -xSpeed, -zSpeed);
        }
        else if (transform.forward == new Vector3(0, 1, 0))
        {
            obj.GetComponent<Rigidbody>().velocity = new Vector3(-xSpeed, 0, -zSpeed);
        }
        else if (transform.forward == new Vector3(0, -1, 0))
        {
            obj.GetComponent<Rigidbody>().velocity = new Vector3(xSpeed, 0, -zSpeed);
        }
    }

    bool CheckForMovement()
    {
        if (gameObject.transform.right == new Vector3(-1, 0, 0))
        {
            if (gameObject.transform.position.x <= -10)
            {
                return false;
            }
        }
        else if (gameObject.transform.right == new Vector3(0, -1, 0))
        {
            if (gameObject.transform.position.y <= -10)
            {
                return false;
            }
        }
        else if (gameObject.transform.right == new Vector3(1, 0, 0))
        {
            if (gameObject.transform.position.x >= 10)
            {
                return false;
            }
        }
        else if (gameObject.transform.right == new Vector3(0, 1, 0))
        {
            if (gameObject.transform.position.y >= 10)
            {
                return false;
            }
        }
        return true;
    }

    IEnumerator Move(float duration)
    {
        if (isMoving == false)
        {
            if (CheckForMovement())
            {
                isMoving = true;
                float timeElapsed = 0;

                Vector3 startPosition = gameObject.transform.position;
                Vector3 positionToMoveTo = gameObject.transform.position + gameObject.transform.right * unitsToMoveBy;
                positionToMoveTo = new Vector3(Mathf.Round(positionToMoveTo.x), Mathf.Round(positionToMoveTo.y), Mathf.Round(positionToMoveTo.z));

                while (timeElapsed < duration)
                {
                    gameObject.transform.position = Vector3.Lerp(startPosition, positionToMoveTo, timeElapsed / duration);
                    timeElapsed += Time.deltaTime;
                    yield return null;
                }
                gameObject.transform.position = positionToMoveTo;
                isMoving = false;
            }
        }
    }
}
