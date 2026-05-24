var tree = CreateTreeOfChars();
Print(tree);

static void Print<T>(BinTreeNode<T> p, int level = 0)
{
    if (p == null) return;
    Print(p.Right, level + 1);
    Console.WriteLine("".PadLeft(level, '.') + p.Value);
    Print(p.Left, level + 1);
}

static BinTreeNode<char> CreateTreeOfChars()
{
    BinTreeNode<char> root = new BinTreeNode<char>(
        'A',
        
        new BinTreeNode<char>(
            'B',
            new BinTreeNode<char>('D'),
            new BinTreeNode<char>('E')
        ),
        
        new BinTreeNode<char>(
            'C',
            
            new BinTreeNode<char>(
                'F',
                new BinTreeNode<char>('H'),
                new BinTreeNode<char>('I')
            ),
            
            new BinTreeNode<char>('G')
        )
    );

    return root;
}

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