using System.Collections;
using UnityEngine;

public class RecursiveMazeAlgorithm : MazeGenerator //RecursiveMazeAlgorithm inherits from MazeGenerator
{
	//The constructor randomly assigns cells the IsGoal and IsTrap values
	public RecursiveMazeAlgorithm(int rows, int columns, bool easy, bool med, bool hard) : base(rows, columns)
	{
		//Randomly assigns player spawn point in map.
		int playerRow = Random.Range(1, rows);
		int playerColumn = Random.Range(1, columns);
		GetMazeCell(playerRow, playerColumn).IsPlayerSpawn = true;

		//Randomly assign goal in maze.
		int goalRow = Random.Range(1, rows);
		int goalColumn = Random.Range(1, columns);

		if (GetMazeCell(goalRow, goalColumn).IsPlayerSpawn == true)
		{
			while (GetMazeCell(goalRow, goalColumn).IsPlayerSpawn == true)
			{
				goalRow = Random.Range(1, rows);
				goalColumn = Random.Range(1, columns);
			}
		}

		GetMazeCell(goalRow, goalColumn).IsGoal = true;

		//Randomly assigns traps in the maze.
		int trapRow = 0;
		int trapColumn = 0;

		//If difficulty is set to medium & not easy assign 3 traps
		if (med && !easy)
        {
			for(int i = 0; i < 3; i++)
            {
				do
				{
					trapRow = Random.Range(1, rows);
					trapColumn = Random.Range(1, columns);
				} while (GetMazeCell(trapRow, trapColumn).IsPlayerSpawn == true || GetMazeCell(trapRow, trapColumn).IsGoal == true);

				GetMazeCell(trapRow, trapColumn).IsTrap = true;
			}
        }
		//If difficulty is set to hard & not easy assign 5 traps.
		else if (hard && !easy)
		{
			for (int i = 0; i < 5; i++)
			{
				do
				{
					trapRow = Random.Range(1, rows);
					trapColumn = Random.Range(1, columns);
				} while (GetMazeCell(trapRow, trapColumn).IsPlayerSpawn == true || GetMazeCell(trapRow, trapColumn).IsGoal == true);

				GetMazeCell(trapRow, trapColumn).IsTrap = true;
			}
		}


	}

	//Overrides GenerateMaze and begins generating maze from cell [0,0] in MazeCell array
	public override void GenerateMaze()
	{
		VisitCell(0, 0, Direction.Start);
	}

	//VisitCell is a recursive method that 
	private void VisitCell(int row, int column, Direction moveMade)
	{
		Direction[] movesAvailable = new Direction[4];
		int movesAvailableCount = 0;

		do
		{
			movesAvailableCount = 0;

			//check move right

			if (column + 1 < ColumnCount && !GetMazeCell(row, column + 1).IsVisited)
			{
				movesAvailable[movesAvailableCount] = Direction.Right;
				movesAvailableCount++;
			}
			else if (!GetMazeCell(row, column).IsVisited && moveMade != Direction.Left)
			{
				GetMazeCell(row, column).WallRight = true;
			}
			//check move forward

			if (row + 1 < RowCount && !GetMazeCell(row + 1, column).IsVisited)
			{
				movesAvailable[movesAvailableCount] = Direction.Front;
				movesAvailableCount++;
			}
			else if (!GetMazeCell(row, column).IsVisited && moveMade != Direction.Back)
			{
				GetMazeCell(row, column).WallFront = true;
			}
			//check move left

			if (column > 0 && column - 1 >= 0 && !GetMazeCell(row, column - 1).IsVisited)
			{
				movesAvailable[movesAvailableCount] = Direction.Left;
				movesAvailableCount++;
			}
			else if (!GetMazeCell(row, column).IsVisited && moveMade != Direction.Right)
			{
				GetMazeCell(row, column).WallLeft = true;
			}
			//check move backward

			if (row > 0 && row - 1 >= 0 && !GetMazeCell(row - 1, column).IsVisited)
			{
				movesAvailable[movesAvailableCount] = Direction.Back;
				movesAvailableCount++;
			}
			else if (!GetMazeCell(row, column).IsVisited && moveMade != Direction.Front)
			{
				GetMazeCell(row, column).WallBack = true;
			}

			GetMazeCell(row, column).IsVisited = true;

			if (movesAvailableCount > 0)
			{
				switch (movesAvailable[Random.Range(0, movesAvailableCount)])
				{
					case Direction.Start:
						break;
					case Direction.Right:
						VisitCell(row, column + 1, Direction.Right);
						break;
					case Direction.Front:
						VisitCell(row + 1, column, Direction.Front);
						break;
					case Direction.Left:
						VisitCell(row, column - 1, Direction.Left);
						break;
					case Direction.Back:
						VisitCell(row - 1, column, Direction.Back);
						break;
				}
			}

		} while (movesAvailableCount > 0);

	}
}