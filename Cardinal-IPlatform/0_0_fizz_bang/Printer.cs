using System;

namespace FizzBuzz
{
    class Printer : IPrinter
    {
        public void print(string value) => Console.Write(value);
        
    }
}
