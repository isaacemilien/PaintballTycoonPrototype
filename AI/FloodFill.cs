using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloodFill : MonoBehaviour
{
    #region FIELDS
    Grid grid;
    Vector2Int goalTile = new Vector2Int(2, 2);
    #endregion

    #region MONOBEHAVIOUR METHODS 
    void Start()
    {   
        grid = new Grid(4, 4, .5f);
        GenerateFill(goalTile);
    }
    #endregion

    #region METHODS 

    // Breadth first search
    void GenerateFill(Vector2Int seed)
    {
        Queue<Vector2Int> searchCollection = new Queue<Vector2Int>();
        List<Vector2Int> viewedCollection = new List<Vector2Int>();

        searchCollection.Enqueue(seed);
        while (searchCollection.Count > 0)
        {
            Vector2Int currentTile = searchCollection.Dequeue();
            viewedCollection.Add(currentTile);

            foreach (Vector2Int neighbor in grid.GetNeighbors(currentTile))
            {
                if (!viewedCollection.Contains(neighbor) && !grid.IsOutOfBounds(neighbor))
                {
                    searchCollection.Enqueue(neighbor);
                    viewedCollection.Add(neighbor);
                }
            }
        }
    }

    // GENERATE PATH BASED ON START
    #endregion
}