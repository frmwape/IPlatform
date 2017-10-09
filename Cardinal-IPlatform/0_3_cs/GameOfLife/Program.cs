using System;
using System.Collections.Generic;
using GameOfLife.Printers;
using GameOfLife.Rules;
using GameOfLife.Worlds;
using GameOfLife.Worlds.Loaders;

namespace GameOfLife
{
    class Program
    {
        static void Main(string[] args)
        {
            var builder = new WorldBuilder(new RandomConfigurationLoader());

            var world = builder.Build();
            var outputGenerators = new List<IOutputWorldState>()
                {
                    new ConsoleOutput()
                };

            var outputFile = new List<IOutputWorldState>()
                {
                    new FileOutput()
                };

            Console.WriteLine("The world has been built and ready to start");
            Console.WriteLine("Press any key to run the next iteration in the simulation");
            Console.WriteLine("Press q to stop the simulation");
            Console.WriteLine("Note: simulation info will also be outputted to file GameOfLifeResults.txt under the assembly folder");
            world.Print(outputGenerators);
            world.Print(outputFile);

            var key = Console.ReadKey();

            while (key.KeyChar != 'q')
            {              
                world.Run(new List<IGameOfLifeRule>()
                {
                    new UnderPopulationRule(),
                    new OverPopulationRule(),
                    new ReproductionPopulationRule(),
                    new ZombiePopulationRule()


                });
                                
                world.Print(outputGenerators);
                world.Print(outputFile);

                key = Console.ReadKey();
            }


        }
    }
}
