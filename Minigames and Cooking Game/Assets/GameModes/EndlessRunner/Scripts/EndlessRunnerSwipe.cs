using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndlessRunnerSwipe : Swipe
{
    public GameObject character1;
    public GameObject character2;

    public override void DoThing(Touch t)
    {
        if (touches[t.fingerId].player == 1)
        {
            endPointP1 = cam1.ScreenToWorldPoint(t.position);
            MoveCharacters(startPointP1, endPointP1, character1);
        }
        else
        {
            endPointP2 = cam2.ScreenToWorldPoint(t.position);
            MoveCharacters(startPointP2, endPointP2, character2);
        }
        touches[t.fingerId].swiped = true;
    }

    void MoveCharacters(Vector3 startPos, Vector3 endPos, GameObject character)
    {
        string direction = CalculateDirection(startPos, endPos);

        switch (direction)
        {
            case "up":
                if (character.transform.position.y < 2)
                {
                    StartCoroutine(AnimateMoveUp(character));
                }
                break;
            case "down":
                if (character.transform.position.y > -2)
                {
                    StartCoroutine(AnimateMoveDown(character));
                }
                break;
        }
    }


    IEnumerator AnimateMoveUp(GameObject character)
    {
        if (character.transform.position.y == 0)
        {
            for (int i = 0; i < 5; i++)
            {
                character.transform.position = new Vector3(character.transform.position.x, character.transform.position.y + 0.4f, character.transform.position.z);
                yield return new WaitForSeconds(0.01f);
            }
            character.transform.position = new Vector3(character.transform.position.x, 2, character.transform.position.z);
        }
        else if (character.transform.position.y <= -2)
        {
            for (int i = 0; i < 5; i++)
            {
                character.transform.position = new Vector3(character.transform.position.x, character.transform.position.y + 0.4f, character.transform.position.z);
                yield return new WaitForSeconds(0.01f);
            }
            character.transform.position = new Vector3(character.transform.position.x, 0, character.transform.position.z);
        }
    }

    IEnumerator AnimateMoveDown(GameObject character)
    {
        if (character.transform.position.y == 0)
        {
            for (int i = 0; i < 5; i++)
            {
                character.transform.position = new Vector3(character.transform.position.x, character.transform.position.y - 0.4f, character.transform.position.z);
                yield return new WaitForSeconds(0.01f);
            }
            character.transform.position = new Vector3(character.transform.position.x, -2, character.transform.position.z);
        }
        else if (character.transform.position.y >= 2)
        {
            for (int i = 0; i < 5; i++)
            {
                character.transform.position = new Vector3(character.transform.position.x, character.transform.position.y - 0.4f, character.transform.position.z);
                yield return new WaitForSeconds(0.01f);
            }
            character.transform.position = new Vector3(character.transform.position.x, 0, character.transform.position.z);
        }
    }
}
