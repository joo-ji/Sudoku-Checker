using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

class SudokuChecker
{
    public int[,] sudokuPuzzle = new int[10, 10];
	
    public SudokuChecker(string filename)
    {
        StreamReader myReader = new StreamReader(filename);
        for (int row = 0; row < 9; row++)
        {
            string nRow = myReader.ReadLine();
            for (int col = 0; col < 9; col++)
            {
                sudokuPuzzle[row, col] = int.Parse(nRow.Substring(col, 1));
            }
        }
        myReader.Close();
    }

    public void checkRow(int[,] puzzle) // checks all the rows of the Sudoku puzzle
    {
        int prod;
        for (int col = 0; col < 9; col++)
        {
            prod = 1;
            for (int row = 0; row < 9; row++)
            {
                prod *= puzzle[row, col];
            }
            if (prod == 362880)
                puzzle[9, col] = -1; // rows with unique integers are assigned a value of -1
            else
                puzzle[9, col] = -2; // rows that do not have unique integers are assigned a value of -2
        }
    }

    public void checkCol(int[,] puzzle) // checks all the columns of the Sudoku puzzle
    {
        int prod;
        for (int row = 0; row < 9; row++)
        {
            prod = 1;
            for (int col = 0; col < 9; col++)
            {
                prod *= puzzle[row, col];
            }
            if (prod == 362880)
                puzzle[row, 9] = -1; // columns with unique integers are assigned a value of -1
            else
                puzzle[row, 9] = -2; // columes that do no have unique integers are assigned a value of -2
        }
    }

    public bool[] checkBox(int[,] puzzle)
    {
        bool[] checkIndividualBox = new bool[9];
        int row = 0, col = 0, prod;
        int counter = 0;
        while (counter < 9)
        {
            prod = 1;
            for (int i = row; i < 3 + row; i++)
            {
                for (int j = col; j < 3 + col; j++)
                    prod *= puzzle[i, j];
            }
            if (prod == 362880)
                checkIndividualBox[counter] = true;
            else
                checkIndividualBox[counter] = false;
            col = (col += 3) % 9;
            if (col == 0)
                row += 3;
            counter++;
        }
        return checkIndividualBox;
    }

    public void printSudoku(int[,] puzzle, bool[] boxes)
    {
        bool correct = true; // puzzle is correct by default
        
		  Console.WriteLine("-------------------------------------"); // formatting
        for (int row = 0; row < 9; row++)
        {
            Console.Write("|"); // formating
            for (int col = 0; col < 9; col++)
            {
                Console.Write(" {0} |", puzzle[row, col]); // prints Sudoku puzzle
            }
            if (puzzle[row, 9] == -1)
                Console.Write(" O "); // prints "O" to the right of the column if the column contains unique integers [1,9] inclusive
            else
            {
                Console.Write(" X "); // prints "X" to the right of the column if the column does not contain unique integers
                correct = false; // puzzle is incorrect if a column does not contain unique integers
            }
            Console.WriteLine("\n-------------------------------------"); // formating
        }
		 
        for (int col = 0; col < 9; col++)
        {
            if (puzzle[9, col] == -1)
                Console.Write("  O "); // prints "O" to the bottom of the row if the row contains unique integers [1,9] inclusive
            else
            {
                Console.Write("  X "); // prints "X" to the bottom of the row if the row does not contain unique integers
                correct = false; // puzzle is incorrect if a row does not contain unique integers
            }
        }
		 
        Console.WriteLine("\n"); // formating
        for (int i = 0; i < 9; i++)
        {
            if (boxes[i] == false)
                Console.WriteLine("Box {0} is incorrect", i + 1); // prints the incorrect boxes
        }
		 
        if (correct == true)
            Console.WriteLine("The Sudoku puzzle was solved correctly.");
        else
            Console.WriteLine("The Sudoku puzzle was solved incorrectly.");
        Console.ReadLine();
    }
}
