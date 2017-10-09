using System;

namespace GameOfLife.Worlds.Cells
{
    public interface IWorldCellState
    {
        void PrepareTransition(IWorldCellState transitionTo);
        void Print(Action<string> output);
        void ApplyTransition();
    }
}