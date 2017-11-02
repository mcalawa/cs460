/*A simple singly-linked Node class. 
 * Adapted from Java code written by Scot Morse.*/

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
