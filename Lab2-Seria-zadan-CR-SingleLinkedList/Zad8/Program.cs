using System;
using System.Linq.Expressions;
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

        Node<T> konduktorHead = head;

        while(konduktorHead != null)
        {
            Console.Write(konduktorHead.ToString());

            konduktorHead = konduktorHead.Next;
        }
        Console.WriteLine("null");
    }

    public static Node<T> CreateSingleLinkedList<T>(params T[] arr) // Oznaczamy typ zwracany jako nullable
    {
        if (arr == null || arr.Length == 0)
        {
            return null;
        }

        Node<T> head = new Node<T>(arr[0]);
        Node<T> konduktorHead = head;

        for (int i = 1; i < arr.Length; i++)
        {
            Node<T> newNode = new Node<T>(arr[i]);
            konduktorHead.Next = newNode;
            konduktorHead = newNode;
        }

        return head;
    }

 public static void DistinctElementsInLinkedList<T>(ref Node<T> head)
    where T : IEquatable<T>, IComparable<T>
{
    // 1. Pusty pociąg lub tylko jeden wagon = brak duplikatów
    if (head == null || head.Next == null)
    {
        return;
    }

    // 2. Główny Konduktor wchodzi do pierwszej lokomotywy
    Node<T> current = head;

    // 3. Główny Konduktor idzie przez każdy wagon po kolei
    while (current != null)
    {
        // 4. Za każdym razem wysyła Pomocnika. 
        // Pomocnik startuje dokładnie z tego samego wagonu, w którym stoi Główny Konduktor.
        Node<T> runner = current;

        // 5. Pomocnik biegnie sprawdzić całą resztę pociągu
        while (runner.Next != null)
        {
            // Pomocnik sprawdza, czy ładunek z przodu jest TAKI SAM jak ładunek Głównego Konduktora
            if (runner.Next.Data.Equals(current.Data))
            {
                // Znalazł klona! Przepina hak, żeby ominąć sklonowany wagon.
                runner.Next = runner.Next.Next;
            }
            else
            {
                // Wagon z przodu jest inny. Pomocnik przechodzi do niego i szuka dalej.
                runner = runner.Next;
            }
        }

        // 6. Pomocnik sprawdził pociąg do samego końca. 
        // Główny Konduktor robi krok do przodu i zabawa zaczyna się od nowa.
        current = current.Next;
    }
}

    static void Main()
    {
        var head = CreateSingleLinkedList<int>(1, 1, 2, 2, 2, 5, 6);
        PrintSingleLinkedList<int>(head);
        DistinctElementsInLinkedList<int>(ref head);
        PrintSingleLinkedList<int>(head);    
    }
}