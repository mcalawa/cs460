using System;
using System.Collections.Generic;
using System.Text;

namespace Calculator
{
    class LinkedStack : IStackADT
    {
        private Node Top;

        public LinkedStack()
        {
            Top = null;
        }

        public void Clear()
        {
            Top = null;
        }

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

            object TopItem = Top.Data;
            Top = Top.Next;
            return TopItem;
        }

        public object Push(object NewItem)
        {
            if(NewItem == null)
            {
                return null;
            }

            Node NewNode = new Node(NewItem, Top);
            return NewItem;
        }
    }
}
