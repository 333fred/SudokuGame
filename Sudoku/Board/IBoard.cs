using System.Collections.Generic;

namespace Sudoku.Board {
    /// <summary>
    /// Represents a physical sudoku board, and the content of each cell
    /// </summary>
    public interface IBoard : IEnumerable<KeyValuePair<(int row, int column), ICell>> {
        BoardLevel Level { get; }
        ICell this[int row, int column] { get; }
        IList<int> GetPossibilities(int row, int column);
        IBoard SetCell(int row, int column, ICell cell);
        int Rows { get; }
        int Columns { get; }
        bool Solved { get; }
    }

    public enum BoardLevel {
        Easy, Medium, Hard
    }
}
