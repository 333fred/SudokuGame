using System;
using Sudoku.Board;

namespace Sudoku {
    internal class SudokuBuilder : ISudokuBuilder {
        private readonly Random _random = new Random();
        private IBoard _board = null;

        BoardLevel ISudokuBuilder.Level => throw new NotImplementedException();

        public BoardLevel Level { get; set; }

        private IBoard Build() {
            var board = new SudokuBoard(Level);
            var solver = SudokuFactory.CreateSolver(SolverStrategy.Deterministic);

            return solver.SolveBoard(board);
        }

        public IBoard GenerateFilledBoard() {
            if (_board == null) {
                _board = Build();
            }

            return _board;
        }

        public IBoard GenerateLevelBoard() {
            throw new NotImplementedException();
        }
    }
}
