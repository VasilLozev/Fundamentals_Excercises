using SoftUniLinkedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Linq;

namespace SoftUniLinkedList
{
    public class StartUp
    {
        static void Main(string[] args)
        {

            LinkedList list = new LinkedList();

            list.AddFirst(1);
            list.AddFirst(2);
            list.AddLast(3);
            list.AddFirst(4);

            //  list.RemoveFirst();
            // list.RemoveLast();

            list.ForEach(number =>
            {
                Console.WriteLine($"Each number in list:{number}");
            });
            Console.WriteLine("Reverse");
            list.ForEachReverse(number =>
            {
                Console.WriteLine($"Each number in list:{number}");
            });

            Console.WriteLine(String.Join(',', list.ToArray()));

            /*StackWithLinkedList stack   =  new StackWithLinkedList();

            stack.Add(1);
            stack.Add(2);

            Console.WriteLine(stack.Pop());
            Console.WriteLine(stack.Pop());
            return;

           SoftUniLinkedList LinkedList = new SoftUniLinkedList();

            LinkedList.AddFirst(new Node(1));
            LinkedList.AddFirst(new Node(2));
            LinkedList.AddFirst(new Node(3));
            LinkedList.AddFirst(new Node(4));*/

            /*  while (LinkedList.Count >= 0)
              {
                  Console.WriteLine(LinkedList.RemoveFirst());
              }
  */
            /* int currentNode = softUniLinkedList.RemoveFirst();

             while (currentNode != null)
             {
                 Console.WriteLine(currentNode.value);
                 currentNode = currentNode.Next;
             } */
        }
    }
}
