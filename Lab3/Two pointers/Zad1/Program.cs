// kompilator C# 7.1 (mono-Linux)
using System;

public class Program 
{
    public static void Main() 
    {
        // Przeczytaj dane ze standardowego wejścia,
        // oblicz i wypisz wynik.
        int n = 0;
        int maxDlugosc = 0;
        int obecnaDlugosc = 0;
        int poprzednia = 0;
        
        int wczytaneLiczby = 0;
        bool czyCzytamyN = true;
        
        int znak;
        
        while ((znak = Console.Read()) != -1)
        {
            
            if (znak != '-' && (znak < '0' || znak > '9'))
            {
                continue;
            }
            
            bool ujemna = false;
            if (znak == '-')
            {
                ujemna = true;
                znak = Console.Read();
            }
            
            int liczba = 0;
            
            while (znak >= '0' && znak <= '9')
            {
                liczba = liczba * 10 + (znak - '0');
                znak = Console.Read();
            }
            
            if (ujemna) 
            {
                liczba = -liczba;
            }
            
            if (czyCzytamyN)
            {
                n = liczba;
                czyCzytamyN = false;
                
                if (n <= 0)
                {
                    Console.WriteLine(0);
                    return;
                }
            }
            else
            {
                wczytaneLiczby++;
                
                if (wczytaneLiczby == 1)
                {
                    poprzednia = liczba;
                    obecnaDlugosc = 1;
                    maxDlugosc = 1;
                }
                else
                {
                    if (liczba > poprzednia)
                    {
                        obecnaDlugosc++;
                        if (obecnaDlugosc > maxDlugosc)
                        {
                            maxDlugosc = obecnaDlugosc;
                        }
                    }
                    else
                    {
                        obecnaDlugosc = 1;
                    }
                    poprzednia = liczba;
                }
                
                if (wczytaneLiczby == n) 
                {
                    break;
                }
            }
        }       
        
        Console.WriteLine(maxDlugosc);
    }
}