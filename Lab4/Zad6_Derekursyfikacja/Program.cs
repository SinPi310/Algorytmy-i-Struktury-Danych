using System;

public class Program
{
    public static void Main()
    {
        // Wczytanie danych ze stdin (pozycja, energia, krok)
        string input = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(input)) return;

        string[] parts = input.Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
        if (parts.Length < 3) return;

        long pozycja = long.Parse(parts[0]);
        long energia = long.Parse(parts[1]);
        long krok = long.Parse(parts[2]);

        // Derekursyfikacja - zamiana rekurencji ogonowej na pętlę while
        while (pozycja > 0)
        {
            if (pozycja % 2 == 0)
            {
                // Aktualizujemy wartości dla przypadku parzystego
                energia += krok;
                pozycja /= 2;
            }
            else
            {
                // Aktualizujemy wartości dla przypadku nieparzystego
                energia += 3;
                pozycja -= 1;
            }
            
            // Krok zawsze rośnie o 1 na koniec każdej "iteracji" rekurencji
            krok++;
        }

        // Wypisanie wyniku na stdout
        Console.WriteLine(energia);
    }
}