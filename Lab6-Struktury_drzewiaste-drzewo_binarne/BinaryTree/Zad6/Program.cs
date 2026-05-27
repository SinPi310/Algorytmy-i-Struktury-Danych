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
    // Gotowa metoda od prowadzącego
    public static void TraversePreOrder<T>(BinTreeNode<T> tree, Action<T> action)
    {
        if (tree == null) return;
        action(tree.Value);
        TraversePreOrder(tree.Left, action);
        TraversePreOrder(tree.Right, action);
    }

    // Twoja metoda korzystająca z powyższej
    public static List<T> GetTraversePreorder<T>(BinTreeNode<T> tree)
    {
        // 1. Tworzymy pustą listę, do której będziemy wrzucać wartości
        List<T> resultList = new List<T>();

        // 2. Wywołujemy gotową metodę prowadzącego.
        // Zapis "value => resultList.Add(value)" to nasza instrukcja Action.
        // Mówi ona: "Każdą znalezioną wartość (value) dodaj (Add) do resultList".
        TraversePreOrder(tree, value => resultList.Add(value));

        // 3. Zwracamy uzupełnioną listę
        return resultList;
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

        // Uruchamiamy Twoją funkcję
        var list = GetTraversePreorder(t);
        
        // Wypisujemy wynik łącząc elementy przecinkiem
        Console.WriteLine(string.Join(",", list)); // Wynik: A,B,D,E,C,F,H,I,G

        Console.ReadLine();
    }
}