using System;
using System.Collections.Generic;

namespace GameOfLife.Worlds.Loaders
{
    public class RandomConfigurationLoader : ILoadWorldConfiguration
    {
        private readonly IList<RowConfiguration> configuration = new List<RowConfiguration>();

        public RandomConfigurationLoader()
        {
            var random = new Random(DateTime.Now.Millisecond);

            for (int r = 0; r < 5; r++)
            {
                var row = new RowConfiguration();

                for (int c = 0; c < 5; c++)
                {
                    var alive = random.Next(25) % 3 == 0;
                    row.AddCell(new CellConfiguration(alive));
                }

                configuration.Add(row);
            }
        }

        public IEnumerable<RowConfiguration> Read() => configuration;
       
    }
}