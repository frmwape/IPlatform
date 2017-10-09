using System;

namespace FizzBuzz
{
    class Program
    {
        static void Main(string[] args)
        {
            int i = 0;

            CheckDivideResultByFive PrintResults = new CheckDivideResultByFive(new Printer());
            
            while (i < 100)
            {
                PrintResults.DivideResultThree(i + 1);
                PrintResults.DivideResultFive(i + 1);
                PrintResults.DivideResultValue(i + 1);
                i++;
            }

            Console.ReadKey();
        }
    }
}
