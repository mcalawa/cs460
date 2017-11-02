---
title: CS 460 Homework 3
layout: hw3
---
## About Homework 3

[Here](/www.wou.edu/~morses/classes/cs46x/assignments/HW3.html) is the assignment page for homework 3. The code for homework 3 can be found [here](https://github.com/mcalawa/senior_project/tree/master/CS_460_Software_Engineering/HW3). The goal of homework 3 was to learn C#. To facilitate that goal, we were provided with Java files for a command line postfix calculator program and asked to rewrite the program in C#. We were specifically told to write the code as we went rather than pasting the Java code and fixing the errors until it worked in C#.

## The Original Program

The Java files we were given were written by our instructor, Scot Morse. The program consists of 4 Java files: a node class called Node.java, an interface that defines the methods of a stack called StackADT.java, a StackADT-interface-implementing class called LinkedStack.java, and a class to receive the input and perform calculations and error checks called Calculator.java. After creating the initial project in Visual Studio, I decided to start bycoding the Node class since it is used by all the other classes in the program (and I've already written about a million Node classes and Node structs across a few languages, so I wasn't terribly worried about adding another language to the list.)

When you run the program, it will prompt you to enter what you want calculated. Any calculation you want to do must be written on one line, but multiple operations can be performed. A calculation must start with two numbers and an operator, but after that, there are multiple combinations of numbers and operators that are valid. The below image gives at least one example of each operator, plus two more complicated equations to calculate the 6th number in the Fibbonaci sequence and the number of days in a year:

![The original Java program making calculations](/images/java_equations.png)

In addition, the program will give you error messages should you input the wrong thing and will print a farewell when you quit the program:

![The original Java program printing error messages and being closed](/images/java_exceptions.png)

## The Node Class

The Node class is a very simple singly-linked node, so the translating it was incredibly simple. The original Java code is as follows:

```java
public class Node
{
	public Object data;	// The payload
	public Node next;	// Reference to the next Node in the chain
	
	public Node()
	{
		data = null;
		next = null;
	}
	
	public Node(Object data, Node next)
	{
		this.data = data;
		this.next = next;
	}
}
```

Most of the code stays the same when written in C#. The biggest difference is probably that the class gets wrapped in the Calculator namespace in order to connect it to the other files in the program. Additionally, while `Object` is a built-in class in C#, it can be written with a lowercase letter like a built-in type. This is also true of the `String` class. Other capitalization standards differ in C# as well. While parameters, local variables, and private members are still written as lowercase, public members are capitalized. Therefore, while the parameters data and next can stay the same in the constructor, the instances where they are public members needed to be changed. The final version of the code in C# looks like:

```cs
namespace Calculator
{
    public class Node
    {
        public object Data;
        public Node Next;

        public Node() { Data = null; Next = null; }
        public Node(object data, Node next) { Data = data; Next = next; }
    }
}
```

## The StackADT Interface

I rewrote the interface next because it needs to exist in order to be used by the LinkedStack class. The original Java file is not much more complicated than the Node class. It's a `public interface` with the methods `public Object push(Object newItem);` to push an item onto the stack, `public Object pop();` to pop an item off of the stack, `public Object peek();` to check what's on the stack without removing it, `public boolean isEmpty();`, and `public void clear();` to empty out the stack. Other than adding the namespace, the changes are relatively minor: `Object` is changed to `object`, the `public` is removed from method signatures and the method names are capitalized, and the interface's name is changed to IStackADT, since C# naming conventions require interfaces to begin with an I.

## The LinkedStack Class

The LinkedStack class implements the interface outlined in the previous step. Similar to the rest of the files thus far, it requires only minor changes, mostly having to do with the inclusion of the namespace and various differences in capitalization. The biggest change is probably the way interfaces are implemented as C# uses the syntax `public class LinkedStack : IStackADT` rather than Java's `public class LinkedStack implements StackADT`. Luckily, C# has garbage collection (this was a big relief for me since I have a background in C++ and manual deallocation makes everything more complicated), so even the Clear() method can stay the same aside from a limited amount of formatting. Finally, C# allows for expression body definitions, which are shorthand method definitions for constructors, finalizers, indexers, and get and sets using the `=>` operator. Using this syntax, the Java code

```java
public LinkedStack()
{
    top = null;	// Empty stack condition
}
```
becomes `public LinkedStack() => top = null; //empty stack condition`.

## The Calculator Class

The Calculator class is where the real meat of the changes can be found. Some of these changes are the same type of changes you see in the other files: including the namespace, differences in capitalization, and slight changes in syntax such as loading outside files with `using` rather than `import`, printing output with `Console.WriteLine()` rather than `System.out.println()`, using `bool` rather than `boolean`, and throwing the errors `NullReferenceException` and `FormatException` rather than `IllegalArgumentException`. 

The most notable difference between the Java and C# versions is the way the user input is handled. The Java version of the Calculator class gets and reads user input with a global Scanner variable that has `System.in` as its source. This variable is named scin. This proved to be the most difficult aspect of the program to write in C#, as I learned that C# doesn't have a Scanner class already built in. 

```java
System.out.println("Please enter q to quit\n");
String input = "2 2 +";
System.out.print("> ");			// prompt user
	
input = scin.nextLine();
```
The above code from the doCalculation method in the Java version of the Calculator class illustrates how the program receives its input from the user. The data from the Scanner is used to populate a String. This is the only place scin is used in the program. Every other method that uses the data from scin gets it by passing the String input as a parameter. In fact, the evaluatePostFixInput method actually creates a new local Scanner with the input String it was passed as its source. Clearly, there was no good reason why you needed a global variable to store your input or why that input had to be received by a Scanner. Instead, the input is assigned to a string that is a local variable in the DoCalculation method like so:
```cs
Console.WriteLine("Please enter q to quit\n");
string input = "2 2 +";
Console.Write("> "); //prompt user

input = Console.ReadLine(); 
```

In both versions, the string input is then passed to another method, where it is first error checked to make sure the string isn't empty or null. If neither of those are true, the Java code continues to check the input with the following code:
```java
Scanner st = new Scanner( input );
while( st.hasNext() )
{
    if( st.hasNextDouble() )
    {
        stack.push( new Double( st.nextDouble() ) );	// if it's a number push it on the stack
    }
    else
    {
        // Must be an operator or some other character or word.
        s = st.next();
        if( s.length() > 1 )
            throw new IllegalArgumentException("Input Error: " + s + " is not an allowed number or operator");
        // it may be an operator so pop two values off the stack and perform the indicated operation
        if( stack.isEmpty() )
            throw new IllegalArgumentException( "Improper input format. Stack became empty when expecting second operand." );
        b = ( (Double)( stack.pop() ) ).doubleValue();
        if( stack.isEmpty() )
            throw new IllegalArgumentException( "Improper input format. Stack became empty when expecting first operand." );
        a = ( (Double)( stack.pop() ) ).doubleValue();
        // Wrap up all operations in a single method, easy to add other binary operators this way if desired
        c = doOperation( a, b, s );
        // push the answer back on the stack
        stack.push( new Double( c ) );
    }
}// End while
```
As you can see, the Java code uses a Scanner with the input String as its source to traverse through the content of the string, seperating it into different parts and examining each part in turn. While C# doesn't have a Scanner class built in, it has several classes that have some similar functions. They are in System.IO and include TextReader, StreamReader, and StringReader. I used the StringReader class for obvious reasons. There are some major differences between Java's Scanner class and C#'s StringReader that change the way you use them. For example, StringReader doesn't have a hasNext, hasNextDouble, or even a next method. StringReader can read one character at a time, a certain number of characters that you specify, the whole line, or until the end of the string. Obviously none of these work perfectly for what we are trying to do since you could have numbers that are multiple digits and there's no way of knowing the number of characters a user is going to enter head of time. The fact that's no method to tell you when a string is finished and no way to tell the type of data a character is when reading makes things more complicated. Luckily, I was able to figure out some workarounds to use in my C# code.

```cs
StringReader reader = new StringReader(input); //used to read the input in place of a scanner
s = reader.ReadToEnd().Split(new [] { ' ', '\t'}, StringSplitOptions.RemoveEmptyEntries); 
//seperates all the different parts of the string into an array with one word per index
int length = s.Length; //how many array elements we have
for(int i = 0; i < length; i++)
{
    if(double.TryParse(s[i], out a)) //TryParse returns t/f and Parse returns a double or throws an exception
    {
        stack.Push(double.Parse(s[i])); // if it's a number, push it on the stack
    }
    else
    {
        // Must be an operator or some other character or word.
        if (s[i].Length > 1)
        {
            throw new FormatException("Input Error: " + s[i] + " is not an allowed number or operator");
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
```
After making a StringReader for the input string we are working with, I tell the reader to read from it until the end of the string and then split it into seperate parts by spaces or tab. I also used a split option that removes all the whitespace entries, which means it still works properly should someone seperate things by multiple spaces. In this case, s is a string array rather than a single string like it was in the Java code. Since we are working with something that has a set size, it makes more sense to use a for loop rather than a while loop. The next challenge is to figure out how to tell whether or not each piece of the input is a double. C# has two methods that are perfect for the job: TryParse and Parse. These are both made to be used with doubles and the difference between them is how they handle something that isn't a double. Parse throws an exception if you pass it something that it can't parse. This is not desirable behavior in this case since there are parts of the input that aren't doubles which are valid. This is where the method TryParse comes in. TryParse returns a bool that will be true if what you passed it can be parsed to a double and will be false otherwise. Therefore, anything that returns true is safe to use parse on, giving us a perfect if condition that works just as well as Java's hasNextDouble.

From there, the rest of the code is pretty much the same other than the minor changes already mentioned other than the fact that I decided to streamline the `if( c == Double.NEGATIVE_INFINITY || c == Double.POSITIVE_INFINITY )` from the original code into `if (double.IsInfinity(c))` since C# already has a method that will return true if either of those or conditions from the Java are true. Neat!

## The Final Product

Here are some screenshots of the final C# program running. I used the same inputs as I did for the original Java program and the output is identical in each case:

![The C# program making calculations](/images/csharp_equations.png)
Here's the C# program calculating inputs...

![The C# program printing error messages and being closed](/images/csharp_exceptions.png)
...and the C# program printing error messages and being closed.