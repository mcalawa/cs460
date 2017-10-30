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
        private TextReader Text = Console.In;

        static void Main(string[] args)
        {
            Calculator app = new Calculator();
            bool playAgain = true;

            Console.WriteLine("\nPostfix Calculator.Recognizes these operators: +-* / ");
            while(playAgain)
            {
                playAgain = app.DoCalculation();
            }
            Console.WriteLine("Bye");
        }

        private bool DoCalculation()
        {
            Console.WriteLine("Please enter q to quit\n");
            string input = "2 2 +";
            Console.WriteLine("> ");

            input = Text.ReadLine();

            return true;
        }
    }
}
