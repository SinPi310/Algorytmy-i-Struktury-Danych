using System;

public class Node<T>
{    
    public T Data {get; set;}
    public Node<T> Next {get; set;}
    public Node(T data, Node<T> next = null) 
    {
        Data = data; Next = next;
    }
    public override string ToString() => (this==null)? "null" : $"{Data} -> ";
}

class Program
{
    public static void PrintSingleLinkedList<T>( Node<T> head )
    {
        //Tutaj piszemy maszą funkcję wyłącznie
        Console.Write("head -> ");

        Node<T> current = head;

        while(current != null)
        {
            Console.Write(current.ToString());

            current = current.Next;
        }
        Console.WriteLine("null");
    }

    static void Main()
    {
        Node<int> head1 = 
            new Node<int>(2,
                new Node<int>(5,
                    new Node<int>(1)));

        // Test 1
        // PrintSingleLinkedList<int>(head1);

        // Test 2
        // PrintSingleLinkedList<int>(null);

        // Test 3
        PrintSingleLinkedList<char>(new Node<char>('a'));
        
    }
}