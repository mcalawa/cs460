using System;
using System.Collections.Generic;
using System.Text;

/*A simple singlely-linked Node class. 
 * Adapted from Java code written by Scot Morse.*/

namespace Calculator
{
    public class Node
    {
        public object Data; //the payload
        public Node Next; //reference to the next Node in the chain

        public Node()
        {
            Data = null;
            Next = null;
        }

        public Node(object Data, Node Next)
        {
            this.Data = Data;
            this.Next = Next;
        }
    }
}
