using System;

public class Program
{
    public static void Main()
    {
        string input = Console.ReadLine();

        if (string.IsNullOrEmpty(input)) return;

        string[] parameters = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        
        if (parameters.Length < 3) return;

        // Używamy long, ponieważ n może wynosić 10^9
        if (!long.TryParse(parameters[0], out long n) || 
            !long.TryParse(parameters[1], out long m) || 
            !long.TryParse(parameters[2], out long i))
        {
            return;
        }

        // Zastosowanie wzoru na problem Józefa Flawiusza
        // f(n, k) = (f(n-1, k) + k) % n
        // Tutaj 'i' to nasze k.
        
        long zwyciezca = 0; // Dla n = 1
        for (long j = 2; j <= n; j++)
        {
            zwyciezca = (zwyciezca + i) % j;
        }

        // Przesunięcie o startowy punkt m
        // Standardowy wzór zakłada start od 1. osoby. Ty zaczynasz od m.
        long wynik = (zwyciezca + (m - 1)) % n + 1;

        Console.WriteLine(wynik);
    }
}

// // Wejście
// // W jedynym wierszu wejścia znajdują się trzy liczby całkowite: n m i spełniające:
// // 1 ≤ n ≤ 10^9
// // 1 ≤ m,i ≤ n
// Console.Write("Podaj n m i: ");
// string? input = Console.ReadLine();

// if (string.IsNullOrWhiteSpace(input))
// {
//     Console.WriteLine("!!! Podaj wartości !!!");
//     return;
// }

// string[] parameters = input.Split(' ');
// if (parameters.Length < 3
//     || !int.TryParse(parameters[0], out int n)  // Danych jest n osób ustawionych w okręgu i ponumerowanych od 1 do  n
//     || !int.TryParse(parameters[1], out int m)  // Liczenie zaczyna się od osoby o numerze m
//     || !int.TryParse(parameters[2], out int i)) // Osoba, która zostanie policzona jako i-ta, odpada z gry.
// {
//     Console.WriteLine("Wpisz 3 liczby całkowiete odzielone ' '!!! ");
//     return;
// }

// public class Node<T>
// {    
//     public T Data {get; set;}
//     public Node<T> Next {get; set;}
//     public Node(T data, Node<T> next = null) 
//     {
//         Data = data; Next = next;
//     }
//     public override string ToString() => (this==null)? "null" : $"{Data} -> ";
// }

// public static void RemoveNodeAt<T>(int position, ref Node<T> head)
// {

//     if (head == null)
//     {
//         return; 
//     }

//     if (position == 0)
//     {
//         head = head.Next; // Nową głową staje się to, co było za starą głową
//         return;           // Kończymy pracę, żeby nie iść dalej!
//     }

//     Node<T> current = head;
//     int currentIndex = 0;

//     while (current != null && currentIndex < position - 1)
//     {
//         current = current.Next;
//         currentIndex++;
//     }

//     if (current == null || current.Next == null)
//     {
//         return;
//     }
    
//     current.Next = current.Next.Next;
// }



// // Logika gry
// // Brutal force
// // List<int> tabela1n = new List<int>();

// // for(int osoby = 1; osoby <= n; osoby++)
// // {
// //     tabela1n.Add(osoby);
// // }

// // //2. Pętlę while, która będzie się wykonywać, dopóki w liście pozostaje więcej niż jedna osoba.
// // int aktualnyIndex = m - 1;
// // while(tabela1n.Count > 1)
// // {

// //     //Console.WriteLine($"Wybraniec: {tabela1n[aktualnyIndex]}, tabela1n[{aktualnyIndex}]");

// //     //3. W środku pętli: wyliczenie indeksu do usunięcia używając naszego wzoru (aktualnyIndeks + i - 1) % rozmiarListy, a następnie usunięcie tego elementu za pomocą metody .RemoveAt()?
// //     int IndexDoUsuniecia = (aktualnyIndex + (i - 1)) % tabela1n.Count;

// //     // Console.WriteLine($"USUŃ: {tabela1n[IndexDoUsuniecia]}, tabela1n[{IndexDoUsuniecia}]");
// //     // Console.WriteLine("-------------------------------------------------------------------");

// //     tabela1n.RemoveAt(IndexDoUsuniecia);

// //     aktualnyIndex = IndexDoUsuniecia % tabela1n.Count;
// // }


// // Wyjście
// // Należy wypisać jedną liczbę całkowitą — numer osoby, która pozostanie jako ostatnia.