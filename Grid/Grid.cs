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

    // RETURN COORDINATES OF TILES THAT SURROUND GIVEN TILE
    public int[][] GetNeighboringTiles(int x, int y)
    {
        int[][] packagedCoordinates = new int[][]
        {
            // VECTOR 2, GO CLOCKWISE
            new int[] { x, y + 1 },
            new int[] { x, y - 1 },
            new int[] { x + 1, y },
            new int[] { x - 1, y }
        };

        Debug.Log("Above coordinate is: " + packagedCoordinates[0][0] + ", " + packagedCoordinates[0][1]);
        return packagedCoordinates;
    }


    public IEnumerable<Vector2Int> GetNeighbors(Vector2Int coords)
    {
        yield return coords + new Vector2Int(0, -1);
        yield return coords + new Vector2Int(+1, 0);
        yield return coords + new Vector2Int(0, +1);
        yield return coords + new Vector2Int(-1, 0);
    }

    public bool IsOutOfBounds(Vector2Int tilePosition)
    {
        if (tilePosition.x < 0 || tilePosition.y < 0)
            return true;

        else if (tilePosition.x > width || tilePosition.y > height)
            return true;
        
        else
            return false;
    }
    #endregion
}
