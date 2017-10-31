using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*A singlely-linked stack implementation
 Adapted from Java code written by Scot Morse*/

namespace Calculator
{
    public class LinkedStack : IStackADT
    {
        private Node Top;

        public LinkedStack() => Top = null; //empty stack condition

        public object Push(object newItem)
        {
            if (newItem == null)
            {
                return null;
            }

            Node newNode = new Node(newItem, Top);
            Top = newNode;
            return newItem;
        }

        public object Pop()
        {
            if (IsEmpty())
            {
                return null;
            }

            object topItem = Top.Data;
            Top = Top.Next;
            return topItem;
        }

        public object Peek()
        {
            if (IsEmpty())
            {
                return null;
            }

            return Top.Data;
        }

        public bool IsEmpty()
        {
            return Top == null;
        }

        public void Clear() => Top = null;
    }
}
