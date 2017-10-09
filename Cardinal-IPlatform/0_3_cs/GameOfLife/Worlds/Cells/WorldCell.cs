using System;

namespace GameOfLife.Worlds.Cells
{
    public class WorldCell
    {
        public WorldCell(int cellNumber, int rowNumber, bool alive)
        {
            CellNumber = cellNumber;
            RowNumber = rowNumber;
            State = CellStateFactory.Create(this, alive);
        }

        public int CellNumber { get; private set; }
        public int RowNumber { get; private set; }

        public IWorldCellState State { get; set; }

        public override string ToString() => string.Format("I am cell {0} in row {1} and my state is {2}", CellNumber, RowNumber, State);
       
        public void Die() => State.PrepareTransition(new DeadState(this));
        
        public void Grow() => State.PrepareTransition(new AliveState(this));
        
        public void Zombify() => State.PrepareTransition(new ZombieState(this));

        public void Print(Action<string> output) => State.Print(output);
        
        public void ApplyTransition() => State.ApplyTransition();
       
    }
}