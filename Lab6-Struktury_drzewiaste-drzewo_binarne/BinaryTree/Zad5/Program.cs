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
    // Metoda dostarczona przez prowadzącego do wypisywania drzewa
    public static void Print<T>(BinTreeNode<T> p, int level = 0)
    {
        if (p == null) return;
        Print(p.Right, level + 1);
        Console.WriteLine("".PadLeft(level, '.') + p.Value);
        Print(p.Left, level + 1);
    }

    // Nasza metoda odwracająca drzewo
    public static void DoMirrorOfTree<T>(BinTreeNode<T> tree)
    {
        // 1. Warunek stopu - jeśli dotarliśmy do pustego miejsca, nie ma czego odwracać
        if (tree == null)
        {
            return;
        }

        // 2. Zamiana miejscami (Swap) lewego i prawego dziecka
        BinTreeNode<T> temp = tree.Left; // Odkładamy lewe dziecko "na stół"
        tree.Left = tree.Right;          // Na miejsce lewego wrzucamy prawe
        tree.Right = temp;               // Na miejsce prawego wrzucamy to ze stołu

        // 3. Rozkazujemy nowemu lewemu i nowemu prawemu dziecku zrobić to samo
        DoMirrorOfTree(tree.Left);
        DoMirrorOfTree(tree.Right);
    }

    public static void Main()
    {
        // Tworzenie drzewa z testu
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

        // 1. Wypisanie oryginalnego drzewa
        Print(t);
        
        // Kreski oddzielające (jak w zadaniu)
        Console.WriteLine("--------");
        
        // 2. Lustrzane odbicie
        DoMirrorOfTree(t);
        
        // 3. Wypisanie odwróconego drzewa
        Print(t);

        Console.ReadLine();
    }
}