using System;
using System.Threading.Channels;

namespace CustomDoublyLinkedList
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Node? listNode1 = new Node(5);
            // Node? listNode2 = new Node(8);
            // listNode1.Next = listNode2;
            // listNode2.Previous = listNode1;
            //
            // Console.WriteLine(listNode1.ToString());
            // Console.WriteLine(listNode2.ToString());

            CustomLinkedList customLinkedList = new();
            
            customLinkedList.AddLast(5);
            customLinkedList.AddLast(6);
            
            customLinkedList.AddFirst(4);
            customLinkedList.AddFirst(3);
            
            customLinkedList.RemoveLast();
            customLinkedList.RemoveFirst();
            customLinkedList.PrintBackward();
            customLinkedList.PrintForward();


            Console.WriteLine($"Length of list is: {customLinkedList.GetLength()}");
            Console.WriteLine($"Length of list is: {customLinkedList.Count}");

            // Console.WriteLine(customLinkedList.Head.Value);
            // Console.WriteLine(customLinkedList.Tail.Value);
            // Console.WriteLine(customLinkedList.Tail.Previous);
            // Console.WriteLine(customLinkedList.Head.Next);

            // Node node = customLinkedList.Head;
            // while (node != null)
            // {
            //     Console.WriteLine(node.Value);
            //     node = node.Next;
            // }
            //
            // Console.WriteLine();
            //
            customLinkedList.ForEach(n => Console.Write(n + " "), true);
            Console.WriteLine();
            Console.WriteLine(string.Join(", ", customLinkedList.ToArray()));
        }
    }
}
