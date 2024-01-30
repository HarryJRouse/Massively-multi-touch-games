using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WindUp : TouchTracking
{
    public Slider p1Slider;
    public Slider p2Slider;

    GameMode gm;

    private void Awake()
    {
        gm = FindObjectOfType<GameMode>();
        p1Slider.maxValue = gm.scoreLimit;
        p2Slider.maxValue = gm.scoreLimit;
    }

    public override void Start()
    {
        base.Start();
        maxIndexP1 = collidersP1.Count - 1;
        maxIndexP2 = collidersP2.Count - 1;
    }


    public override void DoThing(Touch t)
    {
        Collider col = CheckForCollider(t.position);
        if (CheckScreenSide(t.position) == 1)
        {
            if (collidersP1.IndexOf(col) == nextIndexP1)
            {
                gm.IncrementScore(1);
                p1Slider.value = gm.player1score;
                currentIndexP1 = nextIndexP1;
                if (currentIndexP1 != maxIndexP1)
                {
                    nextIndexP1 = currentIndexP1 + 1;
                }
                else
                {
                    nextIndexP1 = 0;
                }
            }
        }
        else if (CheckScreenSide(t.position) == 2)
        {
            if (collidersP2.IndexOf(col) == nextIndexP2)
            {
                gm.IncrementScore(2);
                p2Slider.value = gm.player2score;
                currentIndexP2 = nextIndexP2;
                if (currentIndexP2 != maxIndexP2)
                {
                    nextIndexP2 = currentIndexP2 + 1;
                }
                else
                {
                    nextIndexP2 = 0;
                }
            }
        }
    }
}
