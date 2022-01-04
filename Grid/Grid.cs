using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid
{
    // CLASS INSTANTIATION
    public Grid(int width, int height, float boxSize)
    {
        this.width = width;
        this.height = height;
        this.boxSize = boxSize;

        gridCoordinates = new int[width, height];

        // FULLY CYCLE THROUGH GRID ARRAY
        for (int x = 0; x < gridCoordinates.GetLength(0); x++)
        {
            for (int y = 0; y < gridCoordinates.GetLength(1); y++)
            {
                // DRAW LINES AROUND GRID BOXES
                Debug.DrawLine(GetWorldPosition(x, y), GetWorldPosition(x, y + 1), Color.white, 100f);
                Debug.DrawLine(GetWorldPosition(x, y), GetWorldPosition(x + 1, y), Color.white, 100f);
            }
        }

        Debug.DrawLine(GetWorldPosition(width, 0), GetWorldPosition(width, height), Color.white, 100f);
        Debug.DrawLine(GetWorldPosition(0, height), GetWorldPosition(width, height), Color.white, 100f);
    }

    #region FIELDS
    int width;
    int height;
    float boxSize;

    int[,] gridCoordinates;
    #endregion

    #region METHODS 
    // GETS WORLD POSITION OF GIVEN COORDINATES
    Vector3 GetWorldPosition(int x, int y)
    {
        return new Vector3(x, y) * boxSize;
    }
    #endregion
}