using System;
using System.Collections.Generic;
using System.Text;

namespace Calculator
{
    public class LinkedStack : IStackADT
    {
        private Node Top;

        public LinkedStack() => Top = null;

        public void Clear() => Top = null;

        public bool IsEmpty()
        {
            return Top == null;
        }

        public object Peek()
        {
            if(IsEmpty())
            {
                return null;
            }

            return Top.Data;
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

        public object Push(object newItem)
        {
            if(newItem == null)
            {
                return null;
            }

            Node newNode = new Node(newItem, Top);
            return newItem;
        }
    }
}
