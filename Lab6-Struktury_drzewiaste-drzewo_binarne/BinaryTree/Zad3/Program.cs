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
    // Twoja nowa metoda licząca węzły
    public static int NoOfNodes<T>(BinTreeNode<T> tree)
    {
        // 1. Warunek stopu: jeśli zeszliśmy za głęboko i węzła nie ma, zwracamy 0.
        if (tree == null) 
        {
            return 0;
        }

        // 2. Krok rekurencyjny: Ja (1) + węzły po lewej + węzły po prawej.
        return 1 + NoOfNodes(tree.Left) + NoOfNodes(tree.Right);
    }

    public static void Main()
    {
        // Budujemy lewą stronę drzewa
        var tB = new BinTreeNode<char>('B');
        tB.Left = new BinTreeNode<char>('D');
        tB.Right = new BinTreeNode<char>('E');

        // Budujemy prawą stronę drzewa
        var tC = new BinTreeNode<char>('C',
            new BinTreeNode<char>('F',
                new BinTreeNode<char>('H'),
                new BinTreeNode<char>('I')
            ),
            new BinTreeNode<char>('G')
        );

        // Łączymy w jeden główny korzeń
        var t = new BinTreeNode<char>('A', tB, tC);

        // Wywołujemy funkcję i wypisujemy wynik
        Console.WriteLine("Całkowita liczba węzłów w drzewie to: " + NoOfNodes(t));

        Console.ReadLine();
    }
}