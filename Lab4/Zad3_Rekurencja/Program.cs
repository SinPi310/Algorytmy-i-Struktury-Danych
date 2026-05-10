using System;

public class Program
{
    public static void Main()
    {
        string input = Console.ReadLine();
        if (string.IsNullOrEmpty(input)) return;
        
        string[] parts = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        if (parts.Length < 2) return;

        int n = int.Parse(parts[0]);
        int m = int.Parse(parts[1]);

        Console.WriteLine(Sum(n, m));
    }

    public static long Sum(int i, int m)
    {
        if (i <= 0) return 0;
        
        return Product(i, m) + Sum(i - 1, m);
    }
    
    public static long Product(int i, int j)
    {
        if (j <= 0) return 1;
        
        return (i + j) * Product(i, j - 1);
    }
}
