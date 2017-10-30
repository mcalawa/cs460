using System;
using System.IO;

namespace Calculator
{
    class Calculator
    {
        /*
	     *  Our data structure, used to hold operands for the postfix calculation.
	     */
        private IStackADT Stack = new LinkedStack();

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
