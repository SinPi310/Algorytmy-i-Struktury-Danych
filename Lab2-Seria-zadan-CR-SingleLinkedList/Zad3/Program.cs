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
        
        // 1. Sprawdzamy, czy tablica jest pusta lub null
        if (arr == null || arr.Length == 0)
        {
            return null;
        }

        // 2. Tworzymy pierwszy węzeł, który będzie głową listy
        Node<T> head = new Node<T>(arr[0]);
        Node<T> current = head; // current będzie wskazywać na ostatni węzeł w budowanej liście

        // 3. Iterujemy przez resztę elementów tablicy
        for (int i = 1; i < arr.Length; i++)
        {
            // Tworzymy nowy węzeł
            Node<T> newNode = new Node<T>(arr[i]);
            // Dołączamy nowy węzeł do końca listy
            current.Next = newNode;
            // Przesuwamy current na nowo dodany węzeł
            current = newNode;
        }
        return head; // Zwracamy głowę nowo utworzonej listy
    }

    static void Main()
    {
        var head = CreateSingleLinkedList<int>(new int[] {1, 2, 3, 4} );
        PrintSingleLinkedList<int>(head);
    }
}