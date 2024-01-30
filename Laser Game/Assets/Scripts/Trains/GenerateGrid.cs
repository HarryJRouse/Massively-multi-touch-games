using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateGrid : MonoBehaviour
{
    public GameObject tile1;
    public GameObject tile2;

    public int gridWidth;
    public int gridHeight;

    void Start()
    {
        int row = 0;
        bool alternate = true;
        while (row != gridHeight)
        {
            int column = 0;
            while (column != gridWidth)
            {
                if (alternate)
                {
                    Instantiate(tile1, new Vector2(row*1.5f - 25.5f, column* 1.5f - 13.4f), Quaternion.identity);
                    alternate = false;
                }
                else
                {
                    Instantiate(tile2, new Vector2(row* 1.5f - 25.5f, column* 1.5f - 13.4f), Quaternion.identity);
                    alternate = true;
                }
                column++;
            }
            

            row++;
        }    
    }
}
