using System;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Transactions;

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
        Console.Write("head -> ");

        Node<T> current = head;

        while(current != null)
        {
            Console.Write(current.ToString());

            current = current.Next;
        }
        Console.WriteLine("null");
    }

    public static Node<T> CreateSingleLinkedList<T>(params T[] arr)
    {
        if (arr == null || arr.Length == 0)
        {
            return null;
        }

        Node<T> head = new Node<T>(arr[0]);
        Node<T> current = head;

        for (int i = 1; i < arr.Length; i++)
        {
            Node<T> newNode = new Node<T>(arr[i]);
            current.Next = newNode;
            current = newNode;
        }

        return head;
    }

    public static Node<T> ReverseSingleLinkedList<T>(Node<T> head)
    {
        // 1. Inicjalizujemy wskaźniki
        Node<T> previous = null; // Na początku nie ma poprzedniego węzła
        Node<T> current = head;  // Zaczynamy od głowy oryginalnej listy
        Node<T> nextTemp;        // Będzie przechowywać następny węzeł przed zmianą wskaźnika

        // 2. Przechodzimy przez listę, dopóki nie dojdziemy do końca
        while (current != null)
        {
            // 1. Zapisz następny węzeł w oryginalnej liście, zanim zmienimy current.Next
            nextTemp = current.Next; //

            // 2. Odwróć wskaźnik
            current.Next = previous;

            // 3. Przesuń 'previous' na bieżący węzeł (staje się on poprzednikiem dla następnego)
            previous = current; //

            // 4. Przesuń 'current' na następny węzeł (ten, który zapisaliśmy w nextTemp)
            current = nextTemp; //
        }

        return previous; // Po zakończeniu pętli, 'previous' będzie nową głową odwróconej listy
    }

    static void Main()
    {
        var head = CreateSingleLinkedList<int>(new int[] {1, 2, 3, 4} );
        PrintSingleLinkedList<int>(head);
        PrintSingleLinkedList<int>(ReverseSingleLinkedList<int>(head));
    }
}