using System;

// 1. Klasa węzła drzewa (Moodle ma to ukryte, my musimy to zdefiniować)
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
    // 2. Twoja nowa metoda do wypisywania drzewa (Pre-order)
    public static void PrintTree<T>(BinTreeNode<T> p, int level = 0)
    {
        if (p == null) return;

        Console.WriteLine("".PadLeft(level, '.') + p.Value);
        PrintTree(p.Left, level + 1);
        PrintTree(p.Right, level + 1);
    }

    // 3. Punkt startowy programu
    public static void Main()
    {
        Console.WriteLine("--- Struktura Drzewa ---");

        // Budujemy drzewo z tabelki testowej krok po kroku
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

        // Łączymy wszystko pod głównym korzeniem 'A'
        var t = new BinTreeNode<char>('A', tB, tC);

        // Wywołujemy naszą metodę
        PrintTree(t);

        // Zatrzymujemy konsolę, żeby zobaczyć wynik
        Console.ReadLine();
    }
}