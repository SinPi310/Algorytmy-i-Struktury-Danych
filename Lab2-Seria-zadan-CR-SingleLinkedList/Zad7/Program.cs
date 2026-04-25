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

    public static void RemoveAllDuplicatesFromSortedLinkedList<T>(ref Node<T> head)
        where T : IEquatable<T>, IComparable<T>
    {
        // Krok 1: Pusty pociąg. 
        // Jeśli pociąg nie istnieje lub ma tylko jeden wagon, nie ma czego usuwać.
        if(head == null || head.Next == null)
        {
            return;
        }

        // Krok 2: "Wagon-Widmo" (Dummy Node).
        // Tworzymy sztuczny wagon z domyślnym ładunkiem i wpinamy go tuż przed prawdziwą lokomotywę (head).
        Node<T> widmo = new Node<T>(default(T), head);

        // Krok 3: Przydział konduktorów.
        Node<T> konduktorWidmo = widmo; // Ten konduktor pilnuje ostatniego pewnego, unikalnego wagonu.
        Node<T> konduktorHead = head;   // Ten konduktor idzie przed siebie i przeczesuje pociąg.

        // Krok 4: Spacer po pociągu i szukanie powtórzeń.
        while (konduktorHead != null)
        {
            // Sprawdzamy, czy istnieje następny wagon i czy jego ładunek jest taki sam jak w obecnym.
            if (konduktorHead.Next != null && konduktorHead.Data.Equals(konduktorHead.Next.Data)) 
            {
                // Znaleźliśmy duplikaty! Wewnętrzna pętla pozwala nam minąć wszystkie identyczne wagony w serii.
                while(konduktorHead.Next != null && konduktorHead.Data.Equals(konduktorHead.Next.Data))
                {
                    konduktorHead = konduktorHead.Next;
                }

                // konduktorHead stoi teraz w ostatnim wagonie z serii powtórzeń.
                // konduktorWidmo przepina swój hak ZA ten wagon, fizycznie odcinając całą serię klonów z pociągu!
                konduktorWidmo.Next = konduktorHead.Next;
            }
            else
            {
                // Ładunek jest unikalny. KonduktorWidmo może bezpiecznie przejść do tego wagonu.
                konduktorWidmo = konduktorWidmo.Next;
            }
    
            // konduktorHead zawsze robi krok do przodu, aby badać dalszą część pociągu.
            konduktorHead = konduktorHead.Next;
        }

        // Krok 5: Ustalenie nowej lokomotywy.
        // Nawet jeśli usunęliśmy początkowe wagony, hak widma (widmo.Next) wskaże nam prawidłowy nowy początek pociągu!
        head = widmo.Next;
    }

    static void Main()
    {
        var head = CreateSingleLinkedList<int>(1, 1, 2, 2, 2, 5, 6);
        PrintSingleLinkedList<int>(head);
        RemoveAllDuplicatesFromSortedLinkedList<int>(ref head);
        PrintSingleLinkedList<int>(head);
    }
}