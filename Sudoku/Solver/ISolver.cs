using System;
using System.Collections.Generic;
using System.Text;
using Sudoku.Board;

namespace Sudoku.Solver {
    /// <summary>
    /// Represents a strategy for solving a given sudoku board
    /// </summary>
    public interface ISolver {
        /// <summary>
        /// Solves the given sudoku board, if possible.
        /// </summary>
        /// <param name="toSolve">The board to generate a solution for</param>
        /// <returns>The solved board, if it is possible to solve. Null if impossible to solve for.</returns>
        IBoard SolveBoard(IBoard toSolve);
    }
}
