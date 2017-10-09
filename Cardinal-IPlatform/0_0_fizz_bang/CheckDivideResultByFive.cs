namespace FizzBuzz
{
    class CheckDivideResultByFive : CheckDivideResultByThree
    {
        public CheckDivideResultByFive(IPrinter print) : base(print) { }
       
        public void DivideResultFive(int value)
        {

            if (value % 5 == 0)
            {
                if (threePrinted)
                    printer.print(" Buzz");
                else
                    printer.print(", Buzz");

                printActualValue = true;
            }

            threePrinted = false;

        }
    }
}
