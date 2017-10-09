using GameOfLife.Worlds.Loaders;

namespace GameOfLife.Worlds
{
    public class WorldBuilder
    {
        private readonly ILoadWorldConfiguration loader;

        public WorldBuilder(ILoadWorldConfiguration loader)
        {
            this.loader = loader;
        }

        public World Build()
        {
            var world = new World();
            foreach (var row in loader.Read())
            {
                world.AddRow();

                foreach (var cell in row.GetCells())
                {
                    world.AddCell(cell.Alive);
                }
            }

            return world;
        }
    }
}