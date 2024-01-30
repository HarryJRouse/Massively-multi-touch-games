using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindNextWayPoint : MonoBehaviour
{
    public List<GameObject> wayPoints = new();

    public string direction = "right";

    int wayPointIndex = 0;
    bool isMoving = false;

    void Update()
    {
        if (wayPointIndex != wayPoints.Count)
        {
            StartCoroutine(MoveToWayPoint(3));
        }
    }

    void CalculateDirection(Vector3 point)
    {
        switch(direction)
        {
            case "right":
                if (point.y < gameObject.transform.position.y)
                {
                    direction = "up";
                }
                else if (point.y > gameObject.transform.position.y)
                {
                    direction = "down";
                }
                else
                {
                    direction = "right";
                }
                break;
            case "left":
                if (point.y < gameObject.transform.position.y)
                {
                    direction = "up";
                }
                else if (point.y > gameObject.transform.position.y)
                {
                    direction = "down";
                }
                else
                {
                    direction = "left";
                }
                break;
            case "up":
                if (point.x < gameObject.transform.position.x)
                {
                    direction = "right";
                }
                else if (point.y > gameObject.transform.position.y)
                {
                    direction = "left";
                }
                else
                {
                    direction = "up";
                }
                break;
            case "down":
                if (point.y < gameObject.transform.position.y)
                {
                    direction = "right";
                }
                else if (point.y > gameObject.transform.position.y)
                {
                    direction = "left";
                }
                else
                {
                    direction = "down";
                }
                break;
        }
    }

    IEnumerator MoveToWayPoint(float speed)
    {
        if (!isMoving)
        {
            isMoving = true;

            float xDistance = wayPoints[wayPointIndex].gameObject.transform.position.x - gameObject.transform.position.x;
            float yDistance = wayPoints[wayPointIndex].gameObject.transform.position.y - gameObject.transform.position.y;

            float distance = Mathf.Sqrt((xDistance * xDistance) + (yDistance * yDistance));
            float duration = distance / 5;

            float timeElapsed = 0;

            Vector3 startPosition = gameObject.transform.position;
            Vector3 positionToMoveTo = wayPoints[wayPointIndex].gameObject.transform.position;

            while (timeElapsed < duration)
            {
                gameObject.transform.position = Vector3.Lerp(startPosition, positionToMoveTo, timeElapsed / duration);
                timeElapsed += Time.deltaTime;
                yield return null;
            }
            CalculateDirection(startPosition);
            gameObject.transform.position = positionToMoveTo;
            wayPointIndex++;
            isMoving = false;
        }
    }

}
