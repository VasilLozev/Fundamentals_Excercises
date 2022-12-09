using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftUniLinkedList
{
    public class Node
    {
        public Node(int value)
        {
            Value = value;
        }

        public int Value { get; set; }
        
        public Node Next { get; set; }
        public Node Previous { get; set; }

        public override string ToString()
        {
            return Value.ToString();
        }
    }
}
