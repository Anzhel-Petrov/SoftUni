using System;

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

            customLinkedList.RemoveFirst();

            // Console.WriteLine(customLinkedList.Head.Value);
            // Console.WriteLine(customLinkedList.Tail.Value);
            // Console.WriteLine(customLinkedList.Tail.Previous);
            // Console.WriteLine(customLinkedList.Head.Next);

            Node node = customLinkedList.Head;
            while (node != null)
            {
                Console.WriteLine(node.Value);
                node = node.Next;
            }
        }
    }
}
