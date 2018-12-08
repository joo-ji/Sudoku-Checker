using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SudokuCheckerTest
{
    class SudokuCheckerTest
    {
        public static void Main(string[] args)
        {
			   filename = "sudoku_input.txt";
            SudokuChecker puzzle = new sudokuChecker(filename);

            puzzle.checkRow(puzzle.sudokuPuzzle);
            puzzle.checkCol(puzzle.sudokuPuzzle);

            bool[] checkBoxes = puzzle.checkBox(puzzle.sudokuPuzzle);

            puzzle.printSudoku(puzzle.sudokuPuzzle, checkBoxes);
        }
    }
}
