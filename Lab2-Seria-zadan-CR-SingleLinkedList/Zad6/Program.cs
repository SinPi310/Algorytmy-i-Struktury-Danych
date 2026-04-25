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

    public static void RemoveNodeAt<T>(int position, ref Node<T> head)
    {
        // KROK 1: Pusty pociąg.
        // Jeśli pociąg w ogóle nie istnieje (head jest null), 
        // to nie mamy co usuwać. Po prostu wychodzimy z metody.
        if (head == null)
        {
            return; 
        }

        // KROK 2: Usuwanie LOKOMOTYWY (pozycja 0).
        // Co jeśli użytkownik chce usunąć element o indeksie 0?
        // Wtedy po prostu drugiemu wagonowi wręczamy czapkę maszynisty.
        if (position == 0)
        {
            head = head.Next; // Nową głową staje się to, co było za starą głową
            return;           // Kończymy pracę, żeby nie iść dalej!
        }

        // KROK 3: Szukamy wagonu TUŻ PRZED tym, który chcemy wyrzucić.
        // Chcemy usunąć wagon na indeksie 'position'.
        // Konduktor musi się zatrzymać na wagonie o indeksie 'position - 1'.
        Node<T> current = head;
        int currentIndex = 0;

        // Idziemy wzdłuż pociągu pętlą while.
        // Przerywamy, gdy dojdziemy do wagonu (position - 1)
        // LUB gdy nagle skończy się pociąg (bo ktoś podał pozycję np. 100 w pociągu z 5 wagonami).
        while (current != null && currentIndex < position - 1)
        {
            current = current.Next;
            currentIndex++;
        }

        // KROK 4: Zabezpieczenie przed głupimi błędami.
        // Jeśli konduktor wypadł za pociąg (current == null) 
        // ALBO stoi w ostatnim wagonie, a chcieliśmy usunąć ten za nim (current.Next == null),
        // to znaczy, że ktoś podał zły numer (poza zakresem). Wychodzimy.
        if (current == null || current.Next == null)
        {
            return;
        }

        // KROK 5: Magia przepinania haków! 🎩
        // Jesteśmy w wagonie przed usunięciem (current).
        // Wagon do usunięcia to (current.Next).
        // Bierzemy hak z naszego wagonu i każemy mu omijać następny wagon, 
        // czyli celujemy nim DWA wagony do przodu.
    
        current.Next = current.Next.Next;
    }

    static void Main()
    {
        var head = CreateSingleLinkedList<int>(1, 2, 3, 4, 5, 6);
        PrintSingleLinkedList<int>(head);
        RemoveNodeAt<int>(2, ref head);
        PrintSingleLinkedList<int>(head);
    }
}