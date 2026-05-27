using System;
using System.Collections.Generic;

public class BinTreeNode<T>
{
    public T Value { get; set; }
    public BinTreeNode<T> Left { get; set; }
    public BinTreeNode<T> Right { get; set; }

    public BinTreeNode(T value, BinTreeNode<T> left = null, BinTreeNode<T> right = null)
    {
        Value = value;
        Left = left;
        Right = right;
    }
}

public class Program
{
    // Metoda dostarczona przez prowadzącego (do podglądu struktury)
    public static void Print<T>(BinTreeNode<T> p, int level = 0)
    {
        if (p == null) return;
        Print(p.Right, level + 1);
        Console.WriteLine("".PadLeft(level, '.') + p.Value);
        Print(p.Left, level + 1);
    }

    // Nasza nowa metoda iteratora
    public static IEnumerable<T> InOrder<T>(BinTreeNode<T> head)
    {
        // 1. Warunek stopu. W iteratorach zamiast "return null" używamy "yield break", 
        // co oznacza "zakończ generowanie strumienia".
        if (head == null)
        {
            yield break;
        }

        // 2. LEWO: Wyciągamy i przekazujemy dalej wszystkie wartości z lewego poddrzewa
        foreach (var item in InOrder(head.Left))
        {
            yield return item;
        }

        // 3. KORZEŃ: Zwracamy wartość aktualnego węzła
        yield return head.Value;

        // 4. PRAWO: Wyciągamy i przekazujemy dalej wszystkie wartości z prawego poddrzewa
        foreach (var item in InOrder(head.Right))
        {
            yield return item;
        }
    }

    public static void Main()
    {
        Console.WriteLine("--- TEST 1: Drzewo matematyczne ---");
        var exprTree = new BinTreeNode<char>('+',
            new BinTreeNode<char>('/',
                new BinTreeNode<char>('1'),
                new BinTreeNode<char>('3')),
            new BinTreeNode<char>('/',
                new BinTreeNode<char>('*',
                    new BinTreeNode<char>('7'),
                    new BinTreeNode<char>('6')),
                new BinTreeNode<char>('4')));
        
        Print(exprTree);
        // Odczytywanie całego strumienia naraz używając string.Join
        Console.WriteLine(string.Join(" ", InOrder(exprTree))); 
        

        Console.WriteLine("\n--- TEST 2: Drzewo literowe ---");
        var tB = new BinTreeNode<char>('B');
        tB.Left = new BinTreeNode<char>('D');
        tB.Right = new BinTreeNode<char>('E');

        var tC = new BinTreeNode<char>('C',
            new BinTreeNode<char>('F',
                new BinTreeNode<char>('H'),
                new BinTreeNode<char>('I')
            ),
            new BinTreeNode<char>('G')
        );

        var t = new BinTreeNode<char>('A', tB, tC);
        
        // Odczytywanie strumienia po jednym elemencie przy użyciu pętli foreach
        foreach (var item in InOrder(t))
        {
            Console.Write(item);
        }
        Console.WriteLine(); // Wypisze: DBEAHFICG

        Console.ReadLine();
    }
}