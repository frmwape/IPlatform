using GameOfLife.Worlds.Cells;
using System.Collections.Generic;

namespace GameOfLife.Worlds
{
    public class WorldRow
    {
        private readonly List<WorldCell> _cells = new List<WorldCell>();

        public WorldRow(int rowNumber)
        {
            RowNumber = rowNumber;
        }

        public int RowNumber { get; private set; }

        public IEnumerable<WorldCell> Cells => _cells;
        
        public void AddCell(bool alive) => _cells.Add(new WorldCell(_cells.Count, RowNumber, alive));
        
        public override string ToString() => string.Format("I am row {0}", RowNumber);
        
        public int CellCount => _cells.Count;

        public void ApplyTransitions()
        {
            foreach (var cell in Cells)
                cell.ApplyTransition();
        }
    }
}