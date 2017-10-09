using System.Linq;
using System.Collections.Generic;

namespace GameOfLife.Worlds.Loaders
{
    public class RowConfiguration
    {
        private readonly List<CellConfiguration> cells = new List<CellConfiguration>();

        public RowConfiguration() { }
        
        public IEnumerable<CellConfiguration> GetCells() => cells;
        
        public void AddCell(CellConfiguration cell) => cells.Add(cell);
       
        public override string ToString() => string.Format("I have {0} living cells", cells.Count(c => c.Alive));
       
    }
}