using System;
using System.Collections.Generic;
using System.Linq;
using Sudoku.Board;

namespace Sudoku.Solver {
    /// <summary>
    /// Solves a given sudoku board via the backtrack algorithm. Algorithm Psuedocode:
    /// 1. Find the first open cell
    /// 2. Fill in the cell with the first available possibility
    /// 3. Recusively call SolveBoard
    /// 4. If the recursive call returns a valid board, return the board
    /// 5. If the recursive call does not return a valid board, change the spot to the next possibility. Goto 3
    /// 6. If no more possibilities, return null
    ///
    /// This implementation has one change to allow for randomness: We don't use the first available possibility. We use a random
    /// possibility.
    /// </summary>
    internal abstract class AbstractBacktrackSolver : ISolver {

        public IBoard SolveBoard(IBoard toSolve) {
            int row = 0, column = 0;

            // Find the first empty cell
            for (row = 0; row < toSolve.Rows; row++) {
                for (column = 0; column < toSolve.Columns; column++) {
                    if (toSolve[row, column].Type == CellType.Empty) {
                        goto FoundLocation;
                    }
                }
            }

        FoundLocation:
            return SolveRecursive(toSolve, row, column);
        }

        /// <summary>
        /// Does the actual recursive search part of the backtrack algorithm. This is set up by the public <see cref="SolveBoard(IBoard)"/> call.
        /// </summary>
        private IBoard SolveRecursive(IBoard toSolve, int row, int column) {
            // We solve first by column, then by row. If we've reached an invalid row, then we've either solved the puzzle or haven't been able to
            if (row == toSolve.Rows) {
                return toSolve.Solved ? toSolve : null;
            }

            // If we've reached an invalid column, call recursively increasing the row and resetting the column.
            if (column == toSolve.Columns) {
                return SolveRecursive(toSolve, row + 1, 0);
            }

            // Now, get the current cell. If it's not empty, then we've reached a previously solved cell, so we should skip it
            var cell = toSolve[row, column];
            if (cell.Solved) {
                return SolveRecursive(toSolve, row, column + 1);
            }

            // Try every possibility until we find a valid solution. Note that we do this in a random order. This allows us to generate random
            // boards
            var possibilities = GetPossibilities(toSolve, row, column);
            foreach (var p in possibilities) {
                var guess = SudokuFactory.CreateNumber(CellType.Prefilled, p);
                var recursiveSolved = SolveRecursive(toSolve.SetCell(row, column, guess), row, column + 1);
                if (recursiveSolved != null) {
                    return recursiveSolved;
                }
            }

            // If no possibility fit, then we return null
            return null;
        }

        protected abstract IEnumerable<int> GetPossibilities(IBoard toSolve, int row, int column);
    }
}
