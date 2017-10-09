using GameOfLife.Worlds;

namespace GameOfLife.Rules
{
    public interface IGameOfLifeRule
    {
        void Apply(World world);
    }
}
