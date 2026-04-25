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

    public static Node<T> CreateSingleLinkedList<T>(params T[] arr) // Oznaczamy typ zwracany jako nullable
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

    public static void MoveLastNodeToFront<T>(ref Node<T> head)
    {
        // 1. Sprawdzamy przypadki brzegowe. 
        // Jeśli pociąg nie istnieje lub ma tylko jeden wagon - nic nie robimy, bo nie ma co zamieniać.
        if (head == null || head.Next == null)
        {
            return; // Słówko return przerywa działanie metody
        }

        // 2. Szukamy ostatniego i przedostatniego wagonu.
        // Potrzebujemy dwóch konduktorów:
        Node<T> secLast = null; // Przedostatni
        Node<T> last = head;    // Ostatni (zaczyna od początku)

        // Idziemy tak długo, aż znajdziemy wagon, który nie ma już nic za sobą.
        while (last.Next != null)
        {
            // Zanim 'last' pójdzie krok do przodu, 'secLast' staje na jego aktualnym miejscu.
            // Dzięki temu 'secLast' zawsze jest o jeden krok z tyłu za 'last'.
            secLast = last;
            last = last.Next;
        }

        // Pętla się skończyła.
        // Mamy teraz zmienną 'last' (ostatni wagon) i 'secLast' (przedostatni wagon).

        // 3. Rozpoczynamy magię przepinania! 🎩

        // A) Odpinamy ostatni wagon od pociągu. Przedostatni staje się oficjalnie nowym końcem pociągu.
        secLast.Next = null;

        // B) Podpinamy całą starą resztę pociągu z tyłu za naszym wyciągniętym wagonem.
        last.Next = head;

        // C) Nasz wyciągnięty wagon staje się nową lokomotywą (head).
        head = last;
    }

    static void Main()
    {
        var head = CreateSingleLinkedList<int>(new int[] {1, 2, 3, 4} );
        PrintSingleLinkedList<int>(head);
        MoveLastNodeToFront<int>(ref head);
        PrintSingleLinkedList<int>(head);
    }
}