using System;

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
    // Nasza nowa metoda
    public static int Depth<T>(BinTreeNode<T> tree)
    {
        // 1. Warunek stopu: puste miejsce nie ma głębokości (zgodnie z poleceniem zwraca 0)
        if (tree == null) 
        {
            return 0;
        }

        // 2. Krok rekurencyjny: wybieramy dłuższą gałąź (Max) i dodajemy 1 (siebie)
        return 1 + System.Math.Max(Depth(tree.Left), Depth(tree.Right));
    }

    public static void Main()
    {
        // Budujemy drzewo z testu
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

        // Wywołujemy funkcję
        Console.WriteLine("Głębokość drzewa to: " + Depth(t)); // Powinno wypisać 4

        Console.ReadLine();
    }
}