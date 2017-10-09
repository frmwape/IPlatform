namespace GameOfLife.Worlds.Cells
{
    public class CellStateFactory
    {
        public static IWorldCellState Create(WorldCell worldCell, bool alive)
        {
            if(alive)
                return new AliveState(worldCell);

            return new DeadState(worldCell);
        }
    }
}