namespace CustomDoublyLinkedList;

public class CustomLinkedList
{
    public Node? Head { get; set; }
    public Node? Tail { get; set; }
    public int Count { get; set; }

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
}