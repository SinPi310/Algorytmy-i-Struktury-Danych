using System;

public class Program
{
    public static void Main()
    {
        // 1. Wczytanie wymiarów siatki (odporne na nadmiarowe spacje z Linuxa/Mono)
        string input = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(input)) return;
        
        string[] hw = input.Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
        int h = int.Parse(hw[0]);
        int w = int.Parse(hw[1]);

        // 2. Wczytanie siatki z mapą
        char[][] siatka = new char[h][];
        for (int i = 0; i < h; i++)
        {
            // Używamy TrimEnd(), aby uciąć ukryte spacje, które potrafią psuć tablice znaków
            siatka[i] = Console.ReadLine().TrimEnd().ToCharArray();
        }

        // 3. Utworzenie struktury pamięci podręcznej (Cache)
        // Rozmiar to H na W. Domyślnie wszystkie elementy to null.
        long?[,] cache = new long?[h, w];

        // 4. Odpalamy obliczenia dla celu (prawy dolny róg mapy)
        long wynik = PoliczTrasy(siatka, w - 1, h - 1, cache);
        
        Console.WriteLine(wynik);
    }

    // Zoptymalizowana funkcja rekurencyjna (z memoizacją)
    public static long PoliczTrasy(char[][] siatka, int x, int y, long?[,] cache)
    {
        // KROK 1: Wyjście poza mapę lub trafienie na przeszkodę (zwracamy 0 tras)
        if (x < 0 || y < 0 || siatka[y][x] == '#') return 0;

        // KROK 2: Dotarcie do startu (zwracamy 1, bo znaleźliśmy pełną trasę)
        if (x == 0 && y == 0) return 1;

        // KROK 3 (NOWY): Sprawdzenie pamięci (CACHE)
        // Jeśli pole ma już policzoną wartość (nie jest nullem), od razu ją zwracamy!
        if (cache[y, x].HasValue) 
        {
            return cache[y, x].Value;
        }

        // KROK 4: Klasyczna rekurencja – liczymy trasy, jeśli nie ma ich w cache'u
        long trasyZGory = PoliczTrasy(siatka, x, y - 1, cache);
        long trasyZLewej = PoliczTrasy(siatka, x - 1, y, cache);

        // KROK 5 (NOWY): Zapisanie wyniku w pamięci (Zanim go zwrócimy)
        cache[y, x] = trasyZGory + trasyZLewej;
        
        return cache[y, x].Value;
    }
}