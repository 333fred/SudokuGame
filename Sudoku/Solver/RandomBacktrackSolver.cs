using System;
using System.Collections.Generic;
using System.Linq;
using Sudoku.Board;

namespace Sudoku.Solver {
    internal class RandomBacktrackSolver : AbstractBacktrackSolver {
        private readonly Random _random = new Random();

        protected override IEnumerable<int> GetPossibilities(IBoard toSolve, int row, int column) =>
            toSolve.GetPossibilities(row, column).OrderBy(k => _random.Next());
    }
}
