using System.Collections.Generic;
using Sudoku.Board;

namespace Sudoku.Solver {
    internal class DeterminsticBacktrackSolver : AbstractBacktrackSolver {
        protected override IEnumerable<int> GetPossibilities(IBoard toSolve, int row, int column) {
            return toSolve.GetPossibilities(row, column);
        }
    }
}
