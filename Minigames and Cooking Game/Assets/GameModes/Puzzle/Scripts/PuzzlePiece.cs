using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzlePiece : MonoBehaviour
{
    public List<Transform> rayPoints = new();
    public List<Transform> targetPoints = new();
    public float targetPointRange;
    public Transform designatedArea;

    void Update()
    {
        bool isCorrect = false;

        for (int i=0; i<rayPoints.Count; i++)
        {
            if (rayPoints[i].position.x > targetPoints[i].position.x - targetPointRange/10 && rayPoints[i].position.x < targetPoints[i].position.x + targetPointRange/10
                && rayPoints[i].position.y > targetPoints[i].position.y - targetPointRange/10 && rayPoints[i].position.y < targetPoints[i].position.y + targetPointRange/10)
            {
                isCorrect = true;
            }
        }

        if (isCorrect)
        {
            this.gameObject.tag = "Untagged";
            gameObject.transform.position = designatedArea.position;
            gameObject.transform.rotation = designatedArea.rotation;
            gameObject.transform.localScale = designatedArea.localScale;
        }
    }
}
