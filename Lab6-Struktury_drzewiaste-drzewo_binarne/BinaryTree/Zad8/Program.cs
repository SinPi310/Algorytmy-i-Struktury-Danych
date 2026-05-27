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
    public static void Print<T>(BinTreeNode<T> p, int level = 0)
    {
        if (p == null) return;
        Print(p.Right, level + 1);
        Console.WriteLine("".PadLeft(level, '.') + p.Value);
        Print(p.Left, level + 1);
    }

    public static void RemoveNode<T>(BinTreeNode<T> root, T value)
    {
        if (root == null) return;

        // Słownik, w którym zapamiętamy rodzica dla każdego węzła (ułatwi to odcinanie gałęzi)
        Dictionary<BinTreeNode<T>, BinTreeNode<T>> parents = new Dictionary<BinTreeNode<T>, BinTreeNode<T>>();
        parents[root] = null;

        BinTreeNode<T> targetNode = null;
        BinTreeNode<T> deepestNode = null;

        // BFS - przechodzimy drzewo poziom po poziomie (od lewej do prawej) za pomocą kolejki
        Queue<BinTreeNode<T>> q = new Queue<BinTreeNode<T>>();
        q.Enqueue(root);

        while (q.Count > 0)
        {
            var curr = q.Dequeue();

            // Ostatni węzeł, który tu trafi przed końcem pętli, będzie naturalnie najgłębszym prawym liściem
            deepestNode = curr;

            // Szukamy naszego celu do usunięcia (używamy object.Equals dla bezpieczeństwa typów generycznych)
            if (object.Equals(curr.Value, value))
            {
                targetNode = curr;
            }

            // Dodajemy dzieci do kolejki i zapisujemy, że "curr" jest ich rodzicem
            if (curr.Left != null)
            {
                parents[curr.Left] = curr;
                q.Enqueue(curr.Left);
            }
            if (curr.Right != null)
            {
                parents[curr.Right] = curr;
                q.Enqueue(curr.Right);
            }
        }

        // --- REGUŁA 1: Jeśli węzeł o podanej wartości nie istnieje, nic nie rób ---
        if (targetNode == null) return;

        BinTreeNode<T> targetParent = parents[targetNode];
        int childrenCount = (targetNode.Left != null ? 1 : 0) + (targetNode.Right != null ? 1 : 0);

        // --- REGUŁA 2: Węzeł jest liściem (0 dzieci) ---
        if (childrenCount == 0)
        {
            if (targetParent == null)
            {
                targetNode.Value = default(T); // Zabezpieczenie, gdy usuwamy jedyny korzeń
            }
            else if (targetParent.Left == targetNode) targetParent.Left = null;
            else targetParent.Right = null;
        }

        // --- REGUŁA 3: Węzeł ma jedno dziecko ---
        else if (childrenCount == 1)
        {
            var child = targetNode.Left != null ? targetNode.Left : targetNode.Right;

            if (targetParent == null)
            {
                // Jeśli usuwamy korzeń, po prostu kopiujemy do niego dane jego jedynego dziecka
                targetNode.Value = child.Value;
                targetNode.Left = child.Left;
                targetNode.Right = child.Right;
            }
            else if (targetParent.Left == targetNode) targetParent.Left = child;
            else targetParent.Right = child;
        }

        // --- REGUŁA 4: Węzeł ma dwoje dzieci ---
        else
        {
            // Wiemy już, kto jest najgłębszym liściem. Pobieramy jego rodzica ze słownika
            BinTreeNode<T> deepestParent = parents[deepestNode];

            // 1. Zastępujemy usuwaną wartość, wartością z najgłębszego liścia
            targetNode.Value = deepestNode.Value;

            // 2. Odcinamy (usuwamy) stary najgłębszy liść
            if (deepestParent.Left == deepestNode) deepestParent.Left = null;
            else deepestParent.Right = null;
        }
    }

    public static void Main()
    {
        // Drzewo bazowe z zadania
        Func<BinTreeNode<string>> CreateTree = () => new BinTreeNode<string>("A",
            new BinTreeNode<string>("B",
                new BinTreeNode<string>("D"),
                new BinTreeNode<string>("E")),
            new BinTreeNode<string>("C",
                null,
                new BinTreeNode<string>("F",
                    new BinTreeNode<string>("H"),
                    new BinTreeNode<string>("I"))));

        Console.WriteLine("--- TEST 1: Usunięcie liścia (D) ---");
        var t1 = CreateTree();
        RemoveNode(t1, "D");
        Print(t1);

        Console.WriteLine("\n--- TEST 2: Usunięcie z jednym dzieckiem (C) ---");
        var t2 = CreateTree();
        RemoveNode(t2, "C");
        Print(t2);

        Console.WriteLine("\n--- TEST 3: Usunięcie z dwojgiem dzieci (B) ---");
        var t3 = CreateTree();
        RemoveNode(t3, "B");
        Print(t3);

        Console.ReadLine();
    }
}