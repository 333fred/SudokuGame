using System;
using System.Collections.Generic;

namespace Sudoku.Board {
    class EmptyCell : ICell {
        // If we call numbers on an empty cell, it's an implementation bug.
        public IReadOnlyList<int> Numbers => throw new NotImplementedException();

        public bool Solved => false;

        public CellType Type => CellType.Empty;

        public override string ToString() {
            return "∅";
        }
    }
}
