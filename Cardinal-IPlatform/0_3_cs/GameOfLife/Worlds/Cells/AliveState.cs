using System;

namespace GameOfLife.Worlds.Cells
{
    public class AliveState : IWorldCellState
    {
        private readonly WorldCell cell;
        private IWorldCellState nextState;

        public AliveState(WorldCell cell)
        {
            this.cell = cell;
        }

        public override string ToString() => string.Format("Alive with next state {0}", nextState == null ? "NULL" : nextState.ToString());

        public void Print(Action<string> output) => output("@");
        

        public void PrepareTransition(IWorldCellState transitionTo)
        {
            nextState = transitionTo;
        }

        public void ApplyTransition()
        {
            if (nextState == null)
                return;

            cell.State = nextState;
        }
    }
}