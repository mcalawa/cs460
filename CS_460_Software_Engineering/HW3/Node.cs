using System;
using System.Collections.Generic;
using System.Text;

/*A simple singlely-linked Node class. 
 * Adapted from Java code written by Scot Morse.*/

namespace Calculator
{
    public class Node
    {
        private object data; //the payload
        private Node next; //reference to the next Node in the chain

        public Node()
        {
            Data = null;
            Next = null;
        }

        public Node(object data, Node next)
        {
            Data = data;
            Next = next;
        }

        public Node Next { get => next; set => next = value; }
        public object Data { get => data; set => data = value; }
    }
}
