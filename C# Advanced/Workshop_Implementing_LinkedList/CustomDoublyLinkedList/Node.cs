namespace CustomDoublyLinkedList;

public class Node
{
    public Node(int value)
    {
        this.Value = value;
    }
    public int Value { get; set; }
    public Node? Next { get; set; }
    public Node? Previous { get; set; }

    public override string ToString()
    {
        return $"{(Previous is not null ? Previous.Value : "Null")} <- {Value} -> {(Next is not null ? Next.Value : "Null")}";
        //return $"{Previous?.Value} <- {Value} -> {Next?.Value}";
    }
}