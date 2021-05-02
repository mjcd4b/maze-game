using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeSpawner : MonoBehaviour
{
	public enum MazeGenerationAlgorithm
	{
		PureRecursive
	}

	public MazeGenerationAlgorithm Algorithm = MazeGenerationAlgorithm.PureRecursive;
	
	//boolean variables to hold difficulty
	public bool DifficultyEasy = false;
	public bool DifficultyMedium = false;
	public bool DifficultyHard = false;

	//Game objects spawned in the maze
	public GameObject Floor = null;
	public GameObject Wall = null;
	public GameObject Pillar = null;
	public GameObject Player = null;
	public GameObject GoalPrefab = null;
	public GameObject GoalTrigger = null;
	public GameObject TrapPrefab = null;
	public GameObject TrapTrigger = null;
	
	//# of Rows and collumns
	public int Rows = 0;
	public int Columns = 0;

	//Wideth and height of cells.
	public float CellWidth = 4;
	public float CellHeight = 4;

	//MazeGenerator Object
	private MazeGenerator mMazeGenerator = null;

	// Start is called before the first frame update
	void Start()
	{

		//xMid yMid used to calculate center of maze where player spawns.
		float xMid;
		float zMid;

		//If / Else If statments that determine size of maze based on selected difficulty
		if (DifficultyEasy)
		{
			Rows = 5;
			Columns = 5;
			xMid = 8;
			zMid = 8;
		}
		else if (DifficultyMedium)
		{
			Rows = 10;
			Columns = 10;
			xMid = 16;
			zMid = 16;
		}
		else if (DifficultyHard)
		{
			Rows = 15;
			Columns = 15;
			xMid = 28;
			zMid = 28;
		}
		else
		{
			Rows = 5;
			Columns = 5;
			xMid = 8;
			zMid = 8;
		}

		//switch used to create new maze
		switch (Algorithm)
		{
			case MazeGenerationAlgorithm.PureRecursive:
				mMazeGenerator = new RecursiveMazeAlgorithm(Rows, Columns, DifficultyEasy, DifficultyMedium, DifficultyHard);
				break;
		}

		//Call Generate Maze
		mMazeGenerator.GenerateMaze();

		//Create player object in center of maze.
		GameObject player;
		player = Instantiate(Player, new Vector3(xMid, 1, zMid), Quaternion.Euler(0, 0, 0)) as GameObject;
		player.transform.parent = transform;

		//Nexted for loops to go through each cell of maze and create objects.
		for (int row = 0; row < Rows; row++)
		{
			for (int column = 0; column < Columns; column++)
			{
				//Gets info for cell at row x column and assigns it to cell.
				float x = column * (CellWidth);
				float z = row * (CellHeight);
				MazeCell cell = mMazeGenerator.GetMazeCell(row, column);
				
				//tmp is used as a temporary object to create game objects for each loop.
				GameObject tmp;

				//If the cell is not the goal and is not the trap, spawn floor.
				if (!cell.IsGoal && !cell.IsTrap)
				{
					tmp = Instantiate(Floor, new Vector3(x, 0, z), Quaternion.Euler(0, 0, 0)) as GameObject;
					tmp.transform.parent = transform;
				}

				//These if statements spawn walls based on where the cell tells them to.
				if (cell.WallRight)
				{
					tmp = Instantiate(Wall, new Vector3(x + CellWidth / 2, 0, z) + Wall.transform.position, Quaternion.Euler(0, 90, 0)) as GameObject;// right
					tmp.transform.parent = transform;
				}
				if (cell.WallFront)
				{
					tmp = Instantiate(Wall, new Vector3(x, 0, z + CellHeight / 2) + Wall.transform.position, Quaternion.Euler(0, 0, 0)) as GameObject;// front
					tmp.transform.parent = transform;
				}
				if (cell.WallLeft)
				{
					tmp = Instantiate(Wall, new Vector3(x - CellWidth / 2, 0, z) + Wall.transform.position, Quaternion.Euler(0, 270, 0)) as GameObject;// left
					tmp.transform.parent = transform;
				}
				if (cell.WallBack)
				{
					tmp = Instantiate(Wall, new Vector3(x, 0, z - CellHeight / 2) + Wall.transform.position, Quaternion.Euler(0, 180, 0)) as GameObject;// back
					tmp.transform.parent = transform;
				}

				//Spawns the goal and trigger
				if (cell.IsGoal && GoalPrefab != null)
				{
					tmp = Instantiate(GoalPrefab, new Vector3(x, 0, z), Quaternion.Euler(0, 0, 0)) as GameObject;
					tmp.transform.parent = transform;
					tmp = Instantiate(GoalTrigger, new Vector3(x, 0, z), Quaternion.Euler(0, 0, 0)) as GameObject;
					tmp.transform.parent = transform;

				}

				//Spawns traps.
				if (cell.IsTrap && TrapPrefab != null)
				{
					tmp = Instantiate(TrapPrefab, new Vector3(x, 0, z), Quaternion.Euler(0, 0, 0)) as GameObject;
					tmp.transform.parent = transform;
					tmp = Instantiate(TrapTrigger, new Vector3(x, (float)0.3, z), Quaternion.Euler(0, 0, 0)) as GameObject;
					tmp.transform.parent = transform;
				}
			}
		}

		//Spawns pillars on corners of the cells.
		if (Pillar != null)
		{
			for (int row = 0; row < Rows + 1; row++)
			{
				for (int column = 0; column < Columns + 1; column++)
				{
					float x = column * (CellWidth);
					float z = row * (CellHeight);
					GameObject tmp = Instantiate(Pillar, new Vector3(x - CellWidth / 2, 2, z - CellHeight / 2), Pillar.transform.rotation) as GameObject;
					tmp.transform.parent = transform;
				}
			}
		}
	}
}