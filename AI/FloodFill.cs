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
        grid = new Grid(4, 4, .5f);
    }
	
    void Update()
    {

    }
    #endregion

    #region METHODS 
    Queue<int[]> Fill(int[] start, int[] goal)
    {
        // CONTAINS POSITIONS OF TILES AND THE POSTION THAT CAME BEFORE THEM
        Dictionary<int[], int[]> nextTileToGoal = new Dictionary<int[], int[]>();
        // QUEUE TILES THAT WILL BE CHECKED
        Queue<int[]> frontier = new Queue<int[]>();
        // TILES THAT HAVE BEEN VISITED
        List<int[]> visitedTilePositions = new List<int[]>();

        // ADD GOAL TO CHECKING QUEUE, GOAL WILL BE FIRST TO BE CHECKED
        frontier.Enqueue(goal);

        while(frontier.Count > 0)
        {
            int[] currentPosition = frontier.Dequeue();

            // CHECK CURRENT TILES NEIGHBORING TILES

        }

        return null;
    }
    #endregion
}