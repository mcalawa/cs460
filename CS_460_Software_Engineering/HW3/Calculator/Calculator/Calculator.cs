using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            while (playAgain)
            {
                playAgain = app.DoCalculation();
            }
            Console.WriteLine("Bye");
        }

        private bool DoCalculation()
        {
            Console.WriteLine("Please enter q to quit\n");
            string input = "2 2 +";
            Console.WriteLine("> "); //prompt user

            input = Text.ReadLine();

            // See if the user wishes to quit
            if(input.StartsWith("q") || input.StartsWith("Q"))
            {
                return false;
            }
            //go ahead with calculation
            string output = "4";
            try
            {

            }
            catch( FormatException e )
            {
                e.ToString();
            }

            Console.WriteLine("\n\t>>> " + input + " = " + output);
            return true;
        }

        public string EvaluatePostFixInput(string input)
        {
            if(input == null || input.Equals(""))
            {
                throw new FormatException("Null or the empty string are not valid postfix expressions.");
            }
            // Clear our stack before doing a new calculation
            Stack.Clear();

            string[] s;
            double a;
            double b;
            double c;

            StringReader reader = new StringReader(input);
            s = reader.ReadToEnd().Split(' ');
            int length = s.Length;
            for(int i = 0; i < length; i++)
            {

            }

            return "";
        }
    }
}
