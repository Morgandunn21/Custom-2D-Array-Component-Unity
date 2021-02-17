using UnityEngine;
using System.Collections;

[System.Serializable]
public class Array2D
{
	[System.Serializable]
	public struct RowData
    {
		public int[] row;
	}

	public RowData[] array2D;

    public Array2D(int initialSize)
    {
        array2D = new RowData[initialSize];
    }

    public int[,] get2dArray()
    {
        int sideLength = array2D.Length;
        int[,] array = new int[sideLength, sideLength];

        for(int row = 0; row < sideLength; row++)
        {
            for(int col = 0; col < sideLength; col++)
            {
                array[col, row] = array2D[row].row[col];
            }
        }

        return array;
    }
}
