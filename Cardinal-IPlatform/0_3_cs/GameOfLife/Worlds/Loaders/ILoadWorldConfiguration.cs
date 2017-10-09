using System.Collections.Generic;

namespace GameOfLife.Worlds.Loaders
{
    public interface ILoadWorldConfiguration
    {
        IEnumerable<RowConfiguration> Read();
    }
}