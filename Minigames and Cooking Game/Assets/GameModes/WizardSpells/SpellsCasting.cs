using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellsCasting : TouchTracking
{
    public List<GameObject> spellShapes = new();
    public Vector3 p1SpawnPoint;
    public Vector3 p2SpawnPoint;

    int p1Shape = 0;
    int p2Shape = 0;

    GameObject p1ShapeObj;
    GameObject p2ShapeObj;

    bool p1CorrectStart = false;
    bool p2CorrectStart = false;

    GameMode gm;

    public override void Start()
    {
        base.Start();
        gm = FindObjectOfType<GameMode>();
        UpdateSpell(1);
        UpdateSpell(2);
    }

    void UpdateSpell(int player)
    {
        if (player == 1)
        {
            if (p1ShapeObj != null)
            {
                Destroy(p1ShapeObj);
            }
            collidersP1.Clear();
            p1ShapeObj = Instantiate(spellShapes[p1Shape], p1SpawnPoint, Quaternion.Euler(0,0,-90));
            foreach (Collider col in p1ShapeObj.GetComponentsInChildren<Collider>())
            {
                collidersP1.Add(col);
            }
            currentIndexP1 = 0;
            nextIndexP1 = 1;
            maxIndexP1 = collidersP1.Count - 1;
            p1CorrectStart = false;
        }
        if (player == 2)
        {
            if (p2ShapeObj != null)
            {
                Destroy(p2ShapeObj);
            }
            collidersP2.Clear();
            p2ShapeObj = Instantiate(spellShapes[p2Shape], p2SpawnPoint, Quaternion.Euler(0, 0, 90));
            foreach (Collider col in p2ShapeObj.GetComponentsInChildren<Collider>())
            {
                collidersP2.Add(col);
            }
            currentIndexP2 = 0;
            nextIndexP2 = 1;
            maxIndexP2 = collidersP2.Count - 1;
            p2CorrectStart = false;
        }
    }

    public override void Began(Touch t)
    {
        touches.Add(new TouchLocation(t.fingerId));
        Collider col = CheckForCollider(t.position);
        if (col != null)
        {
            if (CheckScreenSide(t.position) == 1)
            {
                currentIndexP1 = collidersP1.IndexOf(col);
                if (currentIndexP1 == 0)
                {
                    p1CorrectStart = true;
                    collidersP1[nextIndexP1].gameObject.GetComponent<MeshRenderer>().enabled = true;
                }    
            }
            else if (CheckScreenSide(t.position) == 2)
            {
                currentIndexP2 = collidersP2.IndexOf(col);
                if (currentIndexP2 == 0)
                {
                    p2CorrectStart = true;
                    collidersP2[nextIndexP2].gameObject.GetComponent<MeshRenderer>().enabled = true;
                }
            }
        }
    }

    public override void Ended(Touch t)
    {
        if (CheckScreenSide(t.position) == 1)
        {
            currentIndexP1 = 0;
            nextIndexP1 = 1;
            p1CorrectStart = false;
            foreach (Collider col in collidersP1)
            {
                if (collidersP1.IndexOf(col) != 0)
                {
                    col.gameObject.GetComponent<MeshRenderer>().enabled = false;
                }
            }
        }
        else if (CheckScreenSide(t.position) == 2)
        {
            currentIndexP2 = 0;
            nextIndexP2 = 1;
            p2CorrectStart = false;
            foreach (Collider col in collidersP2)
            {
                if (collidersP2.IndexOf(col) != 0)
                {
                    col.gameObject.GetComponent<MeshRenderer>().enabled = false;
                }
            }
        }
    }

    public override void DoThing(Touch t)
    {
        Collider col = CheckForCollider(t.position);
        if (CheckScreenSide(t.position) == 1)
        {
            if (collidersP1.IndexOf(col) == nextIndexP1 && p1CorrectStart == true)
            {
                currentIndexP1 = nextIndexP1;
                if (currentIndexP1 != maxIndexP1)
                {
                    nextIndexP1 = currentIndexP1 + 1;
                    collidersP1[nextIndexP1].gameObject.GetComponent<MeshRenderer>().enabled = true;
                }
                else
                {
                    gm.IncrementScore(1);
                    if (p1Shape < spellShapes.Count - 1)
                    {
                        p1Shape++;
                        UpdateSpell(1);
                    }
                }
            }
        }
        else if (CheckScreenSide(t.position) == 2)
        {
            if (collidersP2.IndexOf(col) == nextIndexP2 && p2CorrectStart == true)
            {
                currentIndexP2 = nextIndexP2;
                if (currentIndexP2 != maxIndexP2)
                { 
                    nextIndexP2 = currentIndexP2 + 1;
                    collidersP2[nextIndexP2].gameObject.GetComponent<MeshRenderer>().enabled = true;
                }
                else
                {
                    gm.IncrementScore(2);
                    if (p2Shape < spellShapes.Count - 1)
                    {
                        p2Shape++;
                        UpdateSpell(2);
                    }
                }
            }
        }
    }
}
