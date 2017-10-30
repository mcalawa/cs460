using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Globalization;

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

            string[] s; // variables for token read
            double a; // Temporary variable for operand
            double b; // ...for operand
            double c; // ...for answer

            StringReader reader = new StringReader(input);
            s = reader.ReadToEnd().Split(' ');
            int length = s.Length;
            for(int i = 0; i < length; i++)
            {
                if(double.TryParse(s[i], out a))
                {
                    Stack.Push(double.Parse(s[i])); // if it's a number push it on the stack
                }
                else
                {
                    // Must be an operator or some other character or word.
                    if (s[i].Length > 1)
                    {
                        throw new FormatException("Input Error: " + s + " is not an allowed number or operator");
                    }
                    // it may be an operator so pop two values off the stack and perform the indicated operation
                    if(Stack.IsEmpty())
                    {
                        throw new FormatException("Improper input format. Stack became empty when expecting second operand.");
                    }
                    b = ((double)(Stack.Pop()));
                    if (Stack.IsEmpty())
                    {
                        throw new FormatException("Improper input format. Stack became empty when expecting second operand.");
                    }
                    a = ((double)(Stack.Pop()));
                }
            }

            return ((double)(Stack.Pop())).ToString();
        }

        public double DoOperation(double a, double b, string s)
        {
            double c = 0.0;
            if(s.Equals("+"))
            {
                c = a + b;
            }
            else if(s.Equals("-"))
            {
                c = a - b;
            }
            else if(s.Equals("*"))
            {
                c = a * b;
            }
            else if(s.Equals("/"))
            {
                try
                {
                    c = a / b;
                    if(double.IsInfinity(c))
                    {
                        throw new ArithmeticException("Can't divide by zero");
                    }
                }
                catch(ArithmeticException e)
                {
                    throw new FormatException(e.Message);
                }
            }
            else
            {
                throw new FormatException("Improper operator: " + s + ", is not one of +, -, *, or /");
            }

            return c;
        }
    }
}
