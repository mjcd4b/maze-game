using System.Collections;
using UnityEngine;

//The enumerator Direction helps determine which direction to go next
//after current cell is visited
public enum Direction
{
    Start,
    Right,
    Front,
    Left,
    Back,
};

//MazeCell stores info regarding what should be generated on the current cell
public class MazeCell 
{
    public bool IsVisited = false;
    public bool WallRight = false;
    public bool WallFront = false;
    public bool WallLeft = false;
    public bool WallBack = false;
    public bool IsGoal = false;
    public bool IsTrap = false;
}
