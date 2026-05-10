using System;

public class Program
{
    public static void Main()
    {
        // 1. Wczytanie wymiarów siatki
        string input = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(input)) return;
        
        string[] hw = input.Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
        int h = int.Parse(hw[0]);
        int w = int.Parse(hw[1]);

        // 2. Wczytanie mapy kosztów do tablicy postrzępionej
        int[][] grid = new int[h][];
        for (int i = 0; i < h; i++)
        {
            string line = Console.ReadLine();
            while (string.IsNullOrWhiteSpace(line)) line = Console.ReadLine(); // Omijanie pustych linii

            string[] parts = line.Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
            grid[i] = new int[w];
            for (int j = 0; j < w; j++)
            {
                grid[i][j] = int.Parse(parts[j]);
            }
        }

        // 3. Inicjalizacja struktury cache (memoizacja 2D)
        // Używamy int? (nullable int), żeby móc łatwo sprawdzić, czy pole było już obliczane
        int?[,] cache = new int?[h, w];

        // 4. Uruchomienie algorytmu od prawego dolnego rogu
        int minKoszt = ObliczKoszt(w - 1, h - 1, grid, cache);
        
        Console.WriteLine(minKoszt);
    }

    // Rekurencyjna funkcja Top-Down z Memoizacją
    public static int ObliczKoszt(int x, int y, int[][] grid, int?[,] cache)
    {
        // KROK 1: Wyjście poza mapę (zwracamy "nieskończoność", żeby zablokować tę ścieżkę)
        if (x < 0 || y < 0) 
        {
            return int.MaxValue;
        }

        // KROK 2: Baza rekurencji - dron jest na starcie. Zwracamy po prostu koszt startowy.
        if (x == 0 && y == 0) 
        {
            return grid[0][0];
        }

        // KROK 3: Memoizacja - jeśli wynik był już policzony, zwracamy go z pamięci
        if (cache[y, x].HasValue) 
        {
            return cache[y, x].Value;
        }

        // KROK 4: Klasyczna rekurencja - sprawdzamy koszt dojścia do poprzedniego pola z lewej i z góry
        int kosztZLewej = ObliczKoszt(x - 1, y, grid, cache);
        int kosztZGory = ObliczKoszt(x, y - 1, grid, cache);

        // KROK 5: Zapisujemy do cache nasz wynik: koszt obecnego pola + mniejszy z poprzednich kosztów
        cache[y, x] = grid[y][x] + Math.Min(kosztZLewej, kosztZGory);

        // Zwracamy wyliczony wynik
        return cache[y, x].Value;
    }
}