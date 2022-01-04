using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloodFill : MonoBehaviour
{
    #region FIELDS
    Grid grid;
    int[] currentTile = {0, 0};
    int[] endTile = {4, 3};
    #endregion

    #region MONOBEHAVIOUR METHODS 
    void Start()
    {   
        grid = new Grid(10, 10, .5f);

        GetPath(currentTile, endTile);
    }
    #endregion

    #region METHODS 
    Queue<int[]> GetPath(int[] start, int[] goal)
    {
        // CONTAINS POSITIONS OF TILES AND THE POSTION THAT CAME BEFORE THEM
        Dictionary<int[], int[]> nextTileToGoal = new Dictionary<int[], int[]>();

        // QUEUE TILES THAT WILL BE CHECKED
        Queue<int[]> frontier = new Queue<int[]>();

        // TILES THAT HAVE BEEN VISITED
        List<int[]> visitedTilePositions = new List<int[]>();

        frontier.Enqueue(goal);

        // ITERATE WHILE QUEUE HAS MEMBERS
        while (frontier.Count > 0)
        {
            int[] currentPosition = frontier.Dequeue();

            // CHECK CURRENT TILES NEIGHBORING TILES
            foreach (int[] neighbor in grid.GetNeighboringTiles(currentPosition[0], currentPosition[1]))
            {
                bool frontierContainsNeighbor = frontier.Contains(neighbor);
                // CHECK IF CURRENT POSITION HAS BEEN VISITED
                if (!visitedTilePositions.Contains(neighbor) && !frontierContainsNeighbor)
                {
                    frontier.Enqueue(neighbor);
                    nextTileToGoal[neighbor] = currentPosition;
                }
            }
            visitedTilePositions.Add(currentPosition);
        }
        //Queue<int[]> path = new Queue<int[]>();
        //int[] currentTilePosition = start;

        //// ITERATES UNITL CURRENT PATH IS EQUAL TO GOAL
        //while (currentTilePosition != goal)
        //{
        //    currentTilePosition = nextTileToGoal[currentTilePosition];
        //    path.Enqueue(currentTilePosition);
        //}

        return null;
    }

    // GENERATE FLOOD FILL
    // GENERATE PATH BASED ON START
    #endregion
}