namespace FizzBuzz
{
    public class CheckDivideResult
    {
        protected bool printActualValue;
        protected IPrinter printer;
        protected string printString;

        public CheckDivideResult(IPrinter print)
        {
            printer = new Printer();
        }
        public void DivideResultValue(int value)
        {
            if (!printActualValue)
                if (value == 1)
                    printer.print(value.ToString());
                else
                    printer.print(", " + value.ToString());
            printActualValue = false;
        }
    }
}
