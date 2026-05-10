using System;

public class Program
{
    public static void Main()
    {
        string input = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(input)) return;
        
        string[] parts = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        if (parts.Length < 2) return;
        
        int n = int.Parse(parts[0]);
        int m = int.Parse(parts[1]);
        
        Console.WriteLine(MainSum(n, m));
    }

    public static long MainSum(int i, int m)
    {
        if (i <= 0) return 0;

        long currentTerm;
        if (i % 2 != 0)
        {
            currentTerm = InnerProduct(i, m);
        }
        else
        {
            currentTerm = InnerSum(i, m);
        }

        return currentTerm + MainSum(i - 1, m);
    }

    public static long InnerProduct(int i, int j)
    {
        if (j <= 0) return 1;
        return (i + j) * InnerProduct(i, j - 1);
    }

    public static long InnerSum(int i, int j)
    {
        if (j <= 0) return 0;
        return (i * j) + InnerSum(i, j - 1);
    }
}