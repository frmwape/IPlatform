﻿using Common.Logging;
using GameOfLife.Worlds;
using GameOfLife.Worlds.Cells;
using System.Linq;

namespace GameOfLife.Rules
{
    public class ReproductionPopulationRule : IGameOfLifeRule
    {
        private static readonly ILog log = LogManager.GetLogger<ReproductionPopulationRule>();

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

                if (livingCells == 3 && cell.State.GetType() != baseType)
                {
                    log.InfoFormat("Grow {0}, {1} because have {2} living neighbours and is in {3}",
                        cell.CellNumber,
                        cell.RowNumber,
                        livingCells,
                        cell.State.GetType().ToString().Replace("GameOfLife.Worlds.Cells.", ""));

                    cell.Grow();
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