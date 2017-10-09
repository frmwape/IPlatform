using Common.Logging;
using GameOfLife.Worlds;
using GameOfLife.Worlds.Cells;
using System.Linq;

namespace GameOfLife.Rules
{
    public class OverPopulationRule : IGameOfLifeRule
    {
        private static readonly ILog log = LogManager.GetLogger<OverPopulationRule>();

        public void Apply(World world)
        {
            foreach (var row in world.Rows)
                ApplyRule(world, row);

        }

        private void ApplyRule(World world, WorldRow row)
        {
            var baseType = typeof(AliveState);
            foreach (var cell in row.Cells)
            {
                var neighbours = world.GetNeighbors(row.RowNumber, cell.CellNumber);
                var livingCells = neighbours.Count(n => n.State.GetType() == baseType);

                if (livingCells > 3 && cell.State.GetType() == baseType)
                {
                    log.InfoFormat("Killing {0}, {1} because more than 3 neighbours, got {2} neighbours and is in {3}",
                        cell.CellNumber,
                        cell.RowNumber,
                        livingCells,
                        cell.State.GetType().ToString().Replace("GameOfLife.Worlds.Cells.", ""));

                    cell.Die();
                }
                else
                {
                    log.DebugFormat("Ignoring {0}, {1} has {2} neighbours and is in {3}", cell.CellNumber, cell.RowNumber, livingCells, 
                        cell.State.GetType().ToString().Replace("GameOfLife.Worlds.Cells.", ""));
                }

            }
        }

    }
}