using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DualPuzzlePiece : MonoBehaviour
{
    public List<Transform> rayPoints = new();
    public float targetPointRange;
    public Transform designatedArea;
    public Collider combinedPieceCollider;
    public bool pieceHeld = false;
    public GameObject combinedPiece;

    List<Transform> targetPoints;

    public DualPuzzlePiece partnerPiece;

    void Start()
    {
        targetPoints = partnerPiece.rayPoints;   
    }

    void Update()
    {
        for (int i = 0; i < rayPoints.Count; i++)
        {
            if (rayPoints[i].position.x > targetPoints[i].position.x - targetPointRange / 10 && rayPoints[i].position.x < targetPoints[i].position.x + targetPointRange / 10
                && rayPoints[i].position.y > targetPoints[i].position.y - targetPointRange / 10 && rayPoints[i].position.y < targetPoints[i].position.y + targetPointRange / 10
                && pieceHeld && partnerPiece.pieceHeld)
            {
                JoinPiece();
                partnerPiece.JoinPiece();
            }
        }
    }

    public void JoinPiece()
    {
        this.gameObject.tag = "Untagged";
        gameObject.transform.position = designatedArea.position;
        combinedPiece.SetActive(true);
        combinedPiece.transform.position = designatedArea.transform.position;
        combinedPiece.transform.rotation = designatedArea.transform.rotation;
        this.gameObject.transform.parent = combinedPiece.transform;
        partnerPiece.gameObject.transform.parent = combinedPiece.transform;
    }
}
