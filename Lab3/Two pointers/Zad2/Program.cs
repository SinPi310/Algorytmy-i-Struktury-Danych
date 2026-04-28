// kompilator C# 7.1 (mono-Linux)
using System;

public class Program 
{
    public static void Main() 
    {
        // Przeczytaj dane ze standardowego wejścia,
        // oblicz i wypisz wynik.

        int znak = Console.Read();
        
        while (znak != -1 && znak != '-' && (znak < '0' || znak > '9')) 
        {
            znak = Console.Read();
        }
        
        if (znak == -1) return;
        
        int n = 0;
        while (znak >= '0' && znak <= '9') 
        {
            n = n * 10 + (znak - '0');
            znak = Console.Read();
        }
        
        if (n <= 0) 
        {
            Console.WriteLine(0);
            return;
        }
        
        int[] tails = new int[n];
        int len = 0;
        
        for (int i = 0; i < n; i++) 
        {
            while (znak != -1 && znak != '-' && (znak < '0' || znak > '9')) 
            {
                znak = Console.Read();
            }
            if (znak == -1) break;
            
            bool ujemna = false;
            if (znak == '-') 
            {
                ujemna = true;
                znak = Console.Read();
            }
            
            int x = 0;
            
            while (znak >= '0' && znak <= '9') 
            {
                x = x * 10 + (znak - '0');
                znak = Console.Read();
            }
            
            if (ujemna) x = -x;
            
            int left = 0;
            int right = len;
            
            while (left < right) 
            {
                int mid = left + (right - left) / 2;
                
                if (tails[mid] <= x) 
                {
                    left = mid + 1;
                } 
                else 
                {
                    right = mid;
                }
            }
            
            if (left == len) 
            {
                tails[len] = x;
                len++;
            } 
            else 
            {
                tails[left] = x;
            }
        }
        
        Console.WriteLine(n - len);
    }
}