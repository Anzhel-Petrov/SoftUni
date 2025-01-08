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

    public Node RemoveFirst()
    {
        Node oldHead = Head; 
        Head = Head.Next;
        Head.Previous = null;
        oldHead.Next = null;
        Count--;
        
        return oldHead;
    }

    public void RemoveLast()
    {
        Node oldTail = Tail;
        Tail = Tail.Previous;
        Tail.Next = null;
        oldTail.Previous = null;
    }
}