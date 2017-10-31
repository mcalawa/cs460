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

The LinkedStack class implements the interface outlined in the previous step. Similar to the rest of the files thus far, it requires only minor changes, mostly having to do with the inclusion of the namespace and various differences in capitalization. The biggest change is probably the way interfaces are implemented as C# uses the syntax `public class LinkedStack : IStackADT` rather than Java's `public class LinkedStack implements StackADT`. Finally, C# allows for expression body definitions, which are shorthand method definitions for constructors, finalizers, indexers, and get and sets using the `=>` operator. Using this syntax, the Java code

```java
public LinkedStack()
{
    top = null;	// Empty stack condition
}
```
becomes `public LinkedStack() => top = null; //empty stack condition`.

## The Calculator Class

The Calculator class is where the real meat of the changes can be found. Some of these changes are the same type of changes you see in the other files: including the namespace, differences in capitalization, and slight changes in syntax such as loading outside files with `using` rather than `import`, printing output with `Console.WriteLine()` rather than `System.out.println()`, using `bool` rather than `boolean`, and throwing the errors `NullReferenceException` and `FormatException` rather than `IllegalArgumentException`. The programs only become noticably different in the EvaluatePostFixInput method. 