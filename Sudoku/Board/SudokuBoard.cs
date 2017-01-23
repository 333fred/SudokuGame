using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sudoku.Board {
    internal class SudokuBoard : IBoard {
        private static readonly int[] RowNumbers = new[] { 0, 1, 2, 3, 4, 5, 6, 7, 8 };
        private static readonly int[] ColumnNumbers = new[] { 0, 1, 2, 3, 4, 5, 6, 7, 8 };

        private readonly IDictionary<(int row, int column), ICell> _store = new Dictionary<(int, int), ICell>();

        public SudokuBoard(BoardLevel level) {
            Level = level;

            foreach (var row in RowNumbers) {
                foreach (var column in ColumnNumbers) {
                    _store[(row, column)] = SudokuFactory.CreateEmpty();
                }
            }
        }

        private SudokuBoard(SudokuBoard copy) {
            _store = new Dictionary<(int, int), ICell>(copy._store);
            Level = copy.Level;
        }

        public BoardLevel Level { get; private set; }

        public int Rows => 9;

        public int Columns => 9;

        public bool Solved => _store.All(kvp => kvp.Value.Solved);

        public ICell this[int row, int column] {
            get => _store[(row, column)];
            private set => _store[(row, column)] = value;
        }

        public IList<int> GetPossibilities(int row, int column) {
            var cells = new List<ICell>();
            cells.AddRange(_store.GetColumn(column));
            cells.AddRange(_store.GetRow(row));
            cells.AddRange(_store.GetGroup(row, column));
            var existing = cells.Where(c => c.Type == CellType.HintFilled || c.Type == CellType.Prefilled || c.Type == CellType.Userfilled)
                .Select(c => c.Numbers.First())
                .ToList();

            var possibilities = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            return possibilities.Where(p => !existing.Contains(p)).ToList();
        }

        public override string ToString() {
            var builder = new StringBuilder();
            for (int row = 0; row < Rows; row++) {
                for (int column = 0; column < Rows; column++) {
                    builder.Append(_store[(row, column)].ToString());
                    if ((column + 1) % 3 == 0 && (column + 1) != Columns)
                        builder.Append("|");
                    else
                        builder.Append(" ");
                }
                if ((row + 1) % 3 == 0 && (row + 1) != Rows) {
                    builder.AppendLine();
                    builder.Append("------------------");
                }
                builder.AppendLine();
            }

            return builder.ToString();
        }

        public IBoard SetCell(int row, int column, ICell cell) {
            var copy = new SudokuBoard(this) {
                [row, column] = cell
            };
            return copy;
        }

        public IEnumerator<KeyValuePair<(int row, int column), ICell>> GetEnumerator() {
            return _store.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator() {
            return _store.GetEnumerator();
        }
    }

    internal static class SudokuListExtensions {
        public static IList<ICell> GetColumn(this IDictionary<(int row, int column), ICell> dict, int column) {
            var cells = new List<ICell>();
            for (int r = 0; r < 9; r++) {
                cells.Add(dict[(r, column)]);
            }
            return cells;
        }

        public static IList<ICell> GetRow(this IDictionary<(int row, int column), ICell> dict, int row) {
            var cells = new List<ICell>();
            for (int c = 0; c < 9; c++) {
                cells.Add(dict[(row, c)]);
            }
            return cells;
        }

        public static IList<ICell> GetGroup(this IDictionary<(int row, int column), ICell> dict, int row, int column) {
            // Get the lower and upper bounds of the groups row and column
            var lowerRow = row - (row % 3);
            var upperRow = lowerRow + 3;
            var lowerColumn = column - (column % 3);
            var upperColumn = lowerColumn + 3;
            var cells = new List<ICell>();

            for (var r = lowerRow; r < upperRow; r++) {
                for (var c = lowerColumn; c < upperColumn; c++) {
                    cells.Add(dict[(r, c)]);
                }
            }

            return cells;
        }
    }
}
