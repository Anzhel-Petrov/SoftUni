namespace CustomDoublyLinkedList;

public class CustomLinkedList
{
    public CustomLinkedList()
    {
        Head = null;
        Tail = null;
        Count = 0;
    }
    public Node? Head { get; set; }
    public Node? Tail { get; set; }
    public int Count { get; private set; }

    public void AddLast(int value)
    {
        Node newNode = new Node(value);
        
        if (Tail is null)
        {
            Head = newNode;
            Tail = newNode;
        }
        else
        {
            Tail.Next = newNode;
            newNode.Previous = Tail;
            Tail = newNode;
        }
        
        Count++;
    }
    
    public void AddFirst(int value)
    {

        Node newNode = new Node(value);
        
        if (Head is null)
        {
            Head = newNode;
            Tail = newNode;
        }
        else
        {
            Head.Previous = newNode;
            newNode.Next = Head;
            Head = newNode;
        }
        
        Count++;
    }
    
    public Node RemoveLast()
    {
        if (Tail == null)
        {
            return null;
        }
        
        Node oldTail = Tail;
        
        if (Tail.Previous == null)
        {
            Head = null;
            Tail = null;
            Count = 0;
            return oldTail;
        }
        
        Tail = Tail.Previous;
        Tail.Next = null;
        oldTail.Previous = null;
        Count--;

        return oldTail;
    }

    public Node RemoveFirst()
    {
        if (Head == null)
        {
            return null;
        }
    
        Node oldHead = Head;

        if (Head.Next == null) 
        {
            Head = null;
            Tail = null;
            Count = 0; 
            return oldHead;
        }
        
        Head = Head.Next;
        Head.Previous = null;
        oldHead.Next = null;
        Count--; 
    
        return oldHead;
    }

    public int GetLength()
    {
        int count = 0;
        for (Node cur = Head; cur != null; cur = cur.Next)
        {
            count++;
        }

        return count;
    }

    public void ForEach(Action<int> action, bool isReversed = false)
    {
        Node? node = isReversed ? Tail : Head;
        
        while (node != null)
        {
            action(node.Value);
            node = isReversed ? node.Previous : node.Next;
        }
    }

    public int[] ToArray()
    {
        int[] array = new int[Count];
        int index = 0;
        
        ForEach(
            n => array[index++] = n
            );
        
        return array;
    }
    
    public void PrintForward()
    {
        var current = Head;
        while (current != null)
        {
            Console.Write(current.Value + " ");
            current = current.Next;
        }
        Console.WriteLine();
    }
    
    public void PrintBackward()
    {
        var current = Tail;
        while (current != null)
        {
            Console.Write(current.Value + " ");
            current = current.Previous;
        }
        Console.WriteLine();
    }
}