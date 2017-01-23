using System.Collections.Generic;
using System.Linq;

namespace Sudoku.Board {
    /// <summary>
    /// Represents a cell with a number in it.
    /// </summary>
    internal class NumberCell : ICell {
        private readonly CellType _cellType;
        private readonly IReadOnlyList<int> _list;

        public NumberCell(CellType cellType, int number) {
            _cellType = cellType;
            _list = new List<int> { number }.AsReadOnly();
        }

        public IReadOnlyList<int> Numbers => _list;

        public bool Solved => true;

        public CellType Type => _cellType;

        public override string ToString() {
            return _list.First().ToString();
        }
    }
}
