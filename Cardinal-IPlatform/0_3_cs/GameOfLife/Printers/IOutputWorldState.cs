using GameOfLife.Worlds;

namespace GameOfLife.Printers
{
    public interface IOutputWorldState
    {
        void Output(World world);
    }
}