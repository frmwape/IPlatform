namespace FizzBuzz
{
    class CheckDivideResultByThree : CheckDivideResult
    {
        protected bool threePrinted = false;
        public CheckDivideResultByThree(IPrinter print) : base(print) { }
        
        public void DivideResultThree(int value)
        {   
            if (value % 3 == 0)
            {
                printer.print(", Fizz");
                threePrinted = true;
                printActualValue = true;
            }
            
        }
    }
}
