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
    public static void AddAtEndOfSingleLinkedList<T>(T element, ref Node<T> head)
    {
        //TODO
        // 1. Budujemy nowy wagon z naszym ładunkiem
        Node<T> newNode = new Node<T>(element);

        // 2. Sprawdzamy, czy pociąg w ogóle istnieje (czy tory są puste)
        if (head == null)
        {
            // Pociągu nie było, więc nasz nowy wagon staje się lokomotywą (początkiem)
            head = newNode;
        }
        else
        {
            // Pociąg już istnieje, więc musimy doczepić wagon na koniec.
        
            // Wsiadamy do pierwszego wagonu
            Node<T> current = head;

            // Idziemy przed siebie TAK DŁUGO, jak długo istnieje kolejny wagon doczepiony z tyłu
            while (current.Next != null)
            {
                // Przechodzimy do następnego wagonu
                current = current.Next;
            }

            // Pętla się skończyła! Konduktor (current) stoi w ostatnim wagonie.
            // Podpinamy nasz nowy wagon na wolny hak ostatniego wagonu:
            current.Next = newNode;
        }
    }

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
        Node<int> head = 
            new Node<int>(2,
                new Node<int>(5,
                    new Node<int>(1)));
        AddAtEndOfSingleLinkedList<int>( -1, ref head);
        PrintSingleLinkedList<int>(head);
    }
}