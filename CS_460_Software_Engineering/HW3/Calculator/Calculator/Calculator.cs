using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Globalization;

/*Command line postfix calculator. 
 * Original Java code written by Scot Morse. Adapted to C# by Melissa Calawa.*/

namespace Calculator
{
    class Calculator
    {
        /*
	     *  Our data structure, used to hold operands for the postfix calculation.
	     */
        private IStackADT stack = new LinkedStack();

        /*
         *  Entry point method. Disregards any command line arguments.
	     *
	     *@param  args  The command line arguments
	     */
        static void Main(string[] args)
        {
            // Instantiate a "Main" object so we don't have to make everything static
            Calculator app = new Calculator();
            bool playAgain = true;

            Console.WriteLine("\nPostfix Calculator.Recognizes these operators: + - * / ");
            while (playAgain) //continue running until they decide to quit
            {
                playAgain = app.DoCalculation();
            }
            Console.WriteLine("Bye");
        }

        /*  Get input string from user and perform calculation, returning true when
	     *  finished. If the user wishes to quit this method returns false.
	     *
	     *@return    true if a calculation succeeded, false if the user wishes to quit
	     */
        private bool DoCalculation()
        {
            Console.WriteLine("Please enter q to quit\n");
            string input = "2 2 +";
            Console.Write("> "); //prompt user

            input = Console.ReadLine(); 
            /* There isn't a prebuilt scanner in the main C# library, so instead the program reads directly
             * from the console and puts the user input into a string. A StringReader is later created from
             * the string so that the two are functionly the same.*/

            // See if the user wishes to quit
            if(input.StartsWith("q") || input.StartsWith("Q"))
            {
                return false;
            }
            //go ahead with calculation
            string output = "4";
            try
            {
                output = EvaluatePostFixInput(input); 
                //returns the result of the calculation or throws an error if it doesn't recieve the correct input
            }
            catch( Exception e )
            {
                output = e.Message;
            }

            Console.WriteLine("\n\t>>> " + input + " = " + output);
            return true;
        }

        /*  Evaluate an arithmetic expression written in postfix form.
	     *
	     *@param  input                         Postfix mathematical expression as a String
	     *@return                               Answer as a String
	     *@exception  NullReferenceException    Something went wrong
         *@exception  FormatException           Something went wrong
	     */
        public string EvaluatePostFixInput(string input)
        {
            if(input == null || input.Equals(""))
            {
                throw new NullReferenceException("Null or the empty string are not valid postfix expressions.");
            }
            // Clear our stack before doing a new calculation
            stack.Clear();

            string[] s; // variables for token read
            double a; // Temporary variable for operand
            double b; // ...for operand
            double c; // ...for answer

            StringReader reader = new StringReader(input); //used to read the input in place of a scanner
            s = reader.ReadToEnd().Split(' '); 
            //seperates all the different parts of the string into an array with one word per index
            int length = s.Length; //how many array elements we have
            for(int i = 0; i < length; i++)
            {
                if(double.TryParse(s[i], out a)) //TryParse returns t/f and Parse returns a double or throws an exception
                {
                    stack.Push((object)double.Parse(s[i])); // if it's a number, push it on the stack
                }
                else
                {
                    // Must be an operator or some other character or word.
                    if (s[i].Length > 1)
                    {
                        throw new FormatException("Input Error: " + s + " is not an allowed number or operator");
                    }
                    // it may be an operator so pop two values off the stack and perform the indicated operation
                    if(stack.IsEmpty())
                    {
                        throw new FormatException("Improper input format. Stack became empty when expecting second operand.");
                    }
                    b = ((double)(stack.Pop())); //set to b because order matters if we are doing subtraction or division
                    if (stack.IsEmpty())
                    {
                        throw new FormatException("Improper input format. Stack became empty when expecting second operand.");
                    }
                    a = ((double)(stack.Pop()));
                    // Wrap up all operations in a single method, easy to add other binary operators this way if desired
                    c = DoOperation(a, b, s[i]); //get the result of the operation 
                    // push the answer back on the stack
                    stack.Push((double)c);
                }
            } //end for

            return ((double)(stack.Pop())).ToString();
        }

        /*  Perform arithmetic.  Put it here so as not to clutter up the previous method, which is already pretty ugly.
	     *
	     *@param  a                             First operand
	     *@param  b                             Second operand
	     *@param  s                             operator
	     *@return                               The answer
	     *@exception  FormatException           Something's fishy here
         *@exception  ArithmeticException       Math doesn't work that way; congrats, you broke the universe
	     */
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
                try //have to make sure they aren't trying to divide by zero because that breaks math
                {
                    c = a / b;
                    /* don't have to check for positive or negative infinity because there's a function
                     * that returns true if it's either; neat! */
                    if (double.IsInfinity(c)) 
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
} //end class calculator
