using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMove : MonoBehaviour
{
    public string characterState = "Moving";
    public float speed;

    void Update()
    {
        CheckForObstacle();
        switch(characterState)
        {
            case "Moving":
                gameObject.transform.position = new Vector2(gameObject.transform.position.x + speed/1000, gameObject.transform.position.y);
                break;
            case "Stationary":
                break;
        }
    }

    void CheckForObstacle()
    {
        RaycastHit2D hit = Physics2D.Raycast(gameObject.transform.position, Vector2.right, 1);
        if (hit.collider != null && hit.collider.gameObject.GetComponent<Obstacle>() != null)
        {
            characterState = "Stationary";
        }
        else
        {
            characterState = "Moving";
        }
    }
}
