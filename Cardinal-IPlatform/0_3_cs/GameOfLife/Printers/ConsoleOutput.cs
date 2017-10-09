using System;
using System.Linq;
using GameOfLife.Worlds;

namespace GameOfLife.Printers
{
    public class ConsoleOutput : IOutputWorldState
    {
        public void Output(World world)
        {
            var numberOfCells = world.Rows.First().Cells.Count();

            PrintNumbers(numberOfCells);

            var rowCounter = 0;
            foreach (var row in world.Rows)
            {
                PrintBorder(numberOfCells);

                Console.Write("{0}|", rowCounter);
                foreach (var cell in row.Cells)
                {
                    cell.Print(c => Console.Write(string.Format(" {0} |", c)));
                }

                rowCounter++;
                Console.WriteLine();
            }

            PrintBorder(numberOfCells);

            Console.WriteLine();
        }

        private void PrintBorder(int numberOfCells)
        {
            Console.Write(" |");
            for (int i = 0; i < numberOfCells; i++)
            {
                Console.Write("---|");
            }

            Console.WriteLine();
        }

        private static void PrintNumbers(int numberOfCells)
        {
            Console.Write(" |");

            for (int i = 0; i < numberOfCells; i++)
            {
                Console.Write(" {0} |", i);
            }
            Console.WriteLine();
        }
    }
}