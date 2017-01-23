using System.Collections.Generic;

namespace Sudoku.Board {
    public enum CellType {
        Empty, Prefilled, Userfilled, HintFilled, Notes
    }

    public interface ICell {
        IReadOnlyList<int> Numbers { get; }
        bool Solved { get; }
        CellType Type { get; }
    }
}
