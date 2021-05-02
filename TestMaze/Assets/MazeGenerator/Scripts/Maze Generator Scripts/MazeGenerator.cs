using UnityEngine;
using System.Collections;

public abstract class MazeGenerator
{

	//Used to obtain the Row and Column from the private variables 

	public int RowCount { get { return mMazeRows; } }
	public int ColumnCount { get { return mMazeColumns; } }

	private int mMazeRows;
	private int mMazeColumns;
	private MazeCell[,] mMaze;

	//A constructor that makes the rows and columns non-zero
	//and instantiates a new MazeCell at that specific rank and range

	public MazeGenerator(int rows, int columns)
	{
		//Makes the rows and columns positive integers be returning absloute values.
		mMazeRows = Mathf.Abs(rows);
		mMazeColumns = Mathf.Abs(columns);

		//If the rows or columns are 0, they are changed to 1 as a minimum.
		if (mMazeRows == 0)
		{
			mMazeRows = 1;
		}
		if (mMazeColumns == 0)
		{
			mMazeColumns = 1;
		}

		//mMaze is assigned a 2d MazeCell with of size rows * columns.
		mMaze = new MazeCell[rows, columns];

		//Create new maze cell for every element in mMaze.
		for (int row = 0; row < rows; row++)
		{
			for (int column = 0; column < columns; column++)
			{
				mMaze[row, column] = new MazeCell();
			}
		}
	}


	//called by the algorithim class to start the algorithm

	public abstract void GenerateMaze();

	//getter for MazeCell inside mMaze array.
	public MazeCell GetMazeCell(int row, int column)
	{
		if (row >= 0 && column >= 0 && row < mMazeRows && column < mMazeColumns)
		{
			return mMaze[row, column];
		}
		else
		{
			Debug.Log(row + " " + column);
			throw new System.ArgumentOutOfRangeException();
		}
	}
}