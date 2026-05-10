using System;
using System.Linq;

public class Program
{
    public static void Main()
    {
        // 1. Wczytanie docelowej liczby maszyn (N)
        string inputN = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(inputN)) return;
        int n = int.Parse(inputN.Trim());

        // 2. Wczytanie dostępnych pojemności serwerów
        string inputCapacities = Console.ReadLine();
        while (string.IsNullOrWhiteSpace(inputCapacities)) 
        {
            inputCapacities = Console.ReadLine(); // pomijamy puste linie
        }
        
        int[] pojemnosci = inputCapacities
            .Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();

        int k = pojemnosci.Length;

        // 3. Tabulacja 2D: dp[i, j]
        // Używamy typu long, ponieważ liczba kombinacji może być bardzo duża
        long[,] dp = new long[k + 1, n + 1];

        // Warunek brzegowy: jest 1 sposób na upakowanie 0 maszyn (pusty zbiór)
        for (int i = 0; i <= k; i++)
        {
            dp[i, 0] = 1;
        }

        // 4. Główne pętle wypełniające tablicę
        for (int i = 1; i <= k; i++) // Dla każdego modelu serwera
        {
            for (int j = 1; j <= n; j++) // Dla każdej pojemności od 1 do N
            {
                // Opcja 1: Liczba sposobów BEZ użycia bieżącego serwera
                dp[i, j] = dp[i - 1, j];

                // Opcja 2: PLUS liczba sposobów Z użyciem bieżącego serwera
                int pojemnoscBiezacego = pojemnosci[i - 1]; // -1 bo indeksujemy tablicę od 0
                
                if (j >= pojemnoscBiezacego)
                {
                    dp[i, j] += dp[i, j - pojemnoscBiezacego];
                }
            }
        }

        // 5. Wynik znajduje się w prawym dolnym rogu naszej macierzy (uwzględnia wszystkie serwery i pełną pojemność N)
        Console.WriteLine(dp[k, n]);
    }
}