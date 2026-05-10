using System;

public class Program
{
    public static void Main()
    {
        // 1. Wczytanie wysokości piramidy (N)
        string inputN = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(inputN)) return;
        int n = int.Parse(inputN.Trim());

        // 2. Wczytanie całej piramidy do tablicy postrzępionej (jagged array)
        int[][] piramida = new int[n][];
        for (int i = 0; i < n; i++)
        {
            string line = Console.ReadLine();
            // Zabezpieczenie przed pustymi liniami z wejścia
            while (string.IsNullOrWhiteSpace(line)) line = Console.ReadLine();

            string[] parts = line.Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
            piramida[i] = new int[i + 1];
            
            for (int j = 0; j <= i; j++)
            {
                piramida[i][j] = int.Parse(parts[j]);
            }
        }

        // 3. Tabulacja (Bottom-Up) - jednowymiarowa tablica dp o rozmiarze N
        // O(N) złożoności pamięciowej dla obliczeń, zgodnie z wymaganiami!
        int[] dp = new int[n];

        // Krok A: Inicjalizacja tablicy wynikowej wartościami z samego dna (ostatni rząd)
        for (int i = 0; i < n; i++)
        {
            dp[i] = piramida[n - 1][i];
        }

        // Krok B: Przetwarzanie od przedostatniego rzędu w górę, aż do szczytu
        for (int i = n - 2; i >= 0; i--)
        {
            // Dla każdego korytarza w danym rzędzie
            for (int j = 0; j <= i; j++)
            {
                // Wybieramy bardziej opłacalną drogę z poniższego poziomu (lewo lub prawo)
                int najlepszaDrogaWDol = Math.Max(dp[j], dp[j + 1]);
                
                // Aktualizujemy naszą tablicę pomocniczą
                dp[j] = piramida[i][j] + najlepszaDrogaWDol;
            }
        }

        // 4. Wynik (największa możliwa suma) znajduje się teraz w pierwszej komórce
        Console.WriteLine(dp[0]);
    }
}