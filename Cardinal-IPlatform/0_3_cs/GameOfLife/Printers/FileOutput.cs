using GameOfLife.Worlds;
using System;
using System.IO;
using System.Linq;

namespace GameOfLife.Printers
{
    class FileOutput: IOutputWorldState
    {
        private static string outPutFileName = "GameOfLifeResults.txt";
        private static StreamWriter file;

        public FileOutput()
        {
            if (!File.Exists(outPutFileName))
            {
                using (StreamWriter sw = File.CreateText(outPutFileName))
                {
                    sw.WriteLine("Writing results to GameOfLifeResults file on: " + DateTime.Now.ToString("dd MMMM yyyy hh:mm:ss"));
                    sw.WriteLine();
                }
            }
            else
            {
                using (StreamWriter sw = new StreamWriter(outPutFileName, true))
                {
                    sw.WriteLine("Writing results to GameOfLifeResults file on: " + DateTime.Now.ToString("dd MMMM yyyy hh:mm:ss"));
                    sw.WriteLine();
                }
            }

        }

        public void Output(World world)
        {
            var numberOfCells = world.Rows.First().Cells.Count();
            LoadFile();

            PrintBorder(numberOfCells);
            file.Write("|  ");
            PrintNumbers(numberOfCells);

            var rowCounter = 0;
            foreach (var row in world.Rows)
            {
                PrintBorder(numberOfCells);

                file.Write("| {0} |", rowCounter);
                foreach (var cell in row.Cells)
                {
                    cell.Print(c => file.Write(string.Format(" {0} |", c)));
                }

                rowCounter++;
                file.WriteLine();
            }

            PrintBorder(numberOfCells);

            file.WriteLine();
            UnLoadFile();
        }

        private void LoadFile()
        {
            file = new StreamWriter(outPutFileName, true);
        }

        private void UnLoadFile()
        {

            file.Close();
            file.Dispose();
            file = null;
        }

        private void PrintBorder(int numberOfCells)
        {
            file.Write("+");
            for (int i = 0; i < numberOfCells + 1; i++)
            {
                file.Write("---+");
            }

            file.WriteLine();
        }

        private static void PrintNumbers(int numberOfCells)
        {
            file.Write(" |");

            for (int i = 0; i < numberOfCells; i++)
            {
                file.Write(" {0} |", i);
            }
            file.WriteLine();
        }
    }
}

