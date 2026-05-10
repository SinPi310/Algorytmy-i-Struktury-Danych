using System;

public class Program
{
    public static void Main()
    {
        string input = Console.ReadLine();
        
        if (int.TryParse(input, out int n))
        {
            Console.WriteLine(CountEmptyBoxes(n));
        }
    }

    public static long CountEmptyBoxes(int n)
    {
        if (n == 0)
        {
            return 1;
        }
        
        return CountEmptyBoxes(n / 2) + 2 * CountEmptyBoxes(n / 3);
        
    }
}