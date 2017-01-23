using Sudoku.Board;
using Sudoku.Solver;

namespace Sudoku {
    /// <summary>
    /// Creates instances of sudoku types
    /// </summary>
    public static class SudokuFactory
    {
        /// <summary>
        /// Creates a SudokuBuilder for the given difficulty level
        /// </summary>
        public static ISudokuBuilder CreateBuilder(BoardLevel level) => new SudokuBuilder { Level = level };

        /// <summary>
        /// Creates a new empty cell
        /// </summary>
        public static ICell CreateEmpty() => new EmptyCell();

        /// <summary>
        /// Creates a cell for a concrete number with the given creation type
        /// </summary>
        public static ICell CreateNumber(CellType type, int number) => new NumberCell(type, number);

        /// <summary>
        /// Creates a sudoku solver of the default strategy
        /// </summary>
        public static ISolver CreateSolver(SolverStrategy strategy = SolverStrategy.Deterministic) {
            switch (strategy) {
                case SolverStrategy.Random:
                    return new RandomBacktrackSolver();
                case SolverStrategy.Deterministic:
                default:
                    return new DeterminsticBacktrackSolver();
            }
        }
    }

    /// <summary>
    /// The type of solving strategy to use
    /// </summary>
    public enum SolverStrategy {
        Random, Deterministic
    }
}
