using Sudoku.Board;

namespace Sudoku {
    public interface ISudokuBuilder {
        /// <summary>
        /// The level for the generated board to use
        /// </summary>
        BoardLevel Level { get; }

        /// <summary>
        /// Generates the filled master board, if it does not already exist. All cells are filled in.
        /// </summary>
        /// <returns>The complete master board</returns>
        IBoard GenerateFilledBoard();

        /// <summary>
        /// Generates the board for the player to solve, at level requested, if it has not already been generated.
        /// </summary>
        /// <returns>The board for the player to use</returns>
        IBoard GenerateLevelBoard();
    }
}
