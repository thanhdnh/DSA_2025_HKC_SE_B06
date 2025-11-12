public class Node
{
    public object data;//hoặc element
    public Node link;

    public Node()
    {
        data = link = null;
    }
    public Node(object data1)
    {
        data = data1;
        link = null;
    }
}
public class SinglyLinkedList
{
    public Node header;

    public SinglyLinkedList()
    {
        header = new Node("Header");
    }
    public Node FindNode(object finddata)
    {
        Node current = header;
        while (current.data != finddata)
            current = current.link;
        return current;
    }
    public void Insert(object newdata, object afterdata)
    {
        Node current = FindNode(afterdata);
        Node newnode = new Node(newdata);
        newnode.link = current.link;
        current.link = newnode;
    }
    public void AddAfter(object newdata, object afterdata)
    {
        Insert(newdata, afterdata);
    }
    public void AddBefore(object newdata, object afterdata)
    {
        object prevdata = FindPrevNode(afterdata).data;
        Insert(newdata, prevdata);
    }
    public void AddFirst(object newdata)
    {
        Insert(newdata, "Header");
    }
    public void AddLast(object newdata)
    {
        Node current = header;
        while (current.link != null)
            current = current.link;
        Insert(newdata, current.data);
    }
    public Node FindPrevNode(object finddata)
    {
        Node current = header;
        while (current.link.data != finddata)
            current = current.link;
        return current;
    }
    public void Remove(object deldata)
    {
        Node current = FindPrevNode(deldata);
        current.link = current.link.link;
    }
    public void Print()
    {
        Node current = header;
        while (current != null)
        {
            System.Console.WriteLine(current.data);
            current = current.link;
        }
    }
    public int Sum()
    {
        if (header.link == null) return 0;
        Node current = header.link;
        int S = 0;
        while (current != null)
        {
            S = S + int.Parse(current.data.ToString());
            current = current.link;
        }
        return S;
    }
    public int Count()
    {
        if (header.link == null) return 0;
        Node current = header.link;
        int count = 0;
        while (current != null)
        {
            count++;
            current = current.link;
        }
        return count;
    }
}
public class Program
{
    public static void Main(string[] args)
    {
        SinglyLinkedList sll = new SinglyLinkedList();
        sll.Insert("18", "Header");
        sll.Insert("15", "18");
        sll.Insert("21", "15");
        sll.Print();
        //sll.Remove("15");
        Console.WriteLine("---");
        sll.AddBefore("99", "15");
        Console.WriteLine("---");
        sll.Print();
        sll.AddFirst("100");
        Console.WriteLine("---");
        sll.Print();
        sll.AddLast("33");
        Console.WriteLine("---");
        sll.Print();
        //Console.WriteLine($"Tổng các node: {sll.Sum()}");
        //Console.WriteLine($"Số node: {sll.Count()}");
    }
}