using System.Collections.Generic;
using System.Linq;
using GameOfLife.Printers;
using GameOfLife.Rules;
using GameOfLife.Worlds.Cells;
using Common.Logging;

namespace GameOfLife.Worlds
{
    public class World
    {
        private static readonly ILog log = LogManager.GetLogger<World>();

        private readonly List<WorldRow> _rows = new List<WorldRow>();

        public void AddRow() => _rows.Add(new WorldRow(_rows.Count));
        
        public void AddCell(bool alive) => _rows.Last().AddCell(alive);
        
        public IEnumerable<WorldRow> Rows => _rows;
        
        public IEnumerable<WorldCell> GetNeighbors(int rowNumber, int cellNumber)
        {
            var result = new List<WorldCell>();
            int y = -1;
            while (y < 2)
            {
                if ((rowNumber + y < 0) || (rowNumber + y > _rows.Count - 1))
                {
                    y++;
                }
                else
                { 
                    int x = -1;

                    while (x < 2)
                    {
                        if ((cellNumber + x < 0) || (cellNumber + x > _rows[rowNumber + y].CellCount - 1))
                        {
                            x++;
                        }
                        else
                        {
                            result.Add(_rows[rowNumber + y].Cells.ElementAt(cellNumber + x));
                            x++;
                        }
                        
                    }
                    y++;
                }
                

            }
            result.Remove(_rows[rowNumber].Cells.ElementAt(cellNumber));
            return result;
           
        }

        public void Run(List<IGameOfLifeRule> rules)
        {
            foreach (var rule in rules)
                rule.Apply(this);

            foreach (var row in _rows)
                row.ApplyTransitions();
        }

        public void Print(List<IOutputWorldState> outputGenerators)
        {
            foreach (var output in outputGenerators)
                output.Output(this);

        }

    }
}
