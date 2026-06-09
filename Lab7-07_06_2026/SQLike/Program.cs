using System;
using System.Net;

public static class StringExtensions
{
    public static bool SQLike(this string text, string pattern)
    {
        if (pattern.Length == 0)
        {
            return text.Length == 0;
        }
        
        if (pattern[0] == '%')
        {
            bool sciezka1 = text.SQLike(pattern.Substring(1));

            bool sciezka2 = false;
            if(text.Length > 0)
            {
                sciezka2 = text.Substring(1).SQLike(pattern);
            }
            return sciezka1 || sciezka2;
        }
        else if (pattern[0] == '_')
        {
            //Dokładnie jeden dowolny znak "zwykły"
            if(text.Length > 0)
            {
                return text.Substring(1).SQLike(pattern.Substring(1));
            }
            else
            {
                return false;
            }

        }
        else
        {
            if(text.Length > 0 && text[0] == pattern[0])
            {
                //text[0] == pattern[0] TRUE
                return text.Substring(1).SQLike(pattern.Substring(1));
            }
            else
            {
                return false;
            }
        }
    }
}

public class Program
{
    public static void Main()
    {
        Console.WriteLine("--- Nasze testy (zwykłe litery i znak _) ---");
        Test(true, "A_am", "Adam");
        Test(false, "A_am", "Ad");
        Test(true, "Agnies_ka", "Agnieszka");

        Console.WriteLine("\n--- Testy z zadania (wymagają znaku %) ---");
        Test(false, "A%a", "Adam");
        Test(true, "A%a", "Agnieszka");
        Test(false, "A%a", "agnieszka");
        Test(true, "%_a", "Agnieszka");
        Test(false, "%_a", "a");
        Test(true, "%", "alab");
    }

    // Metoda pomocnicza wyświetlająca wyniki
    static void Test(bool expected, string pattern, string text)
    {
        bool actual = text.SQLike(pattern);
        string status = (actual == expected) ? "ZALICZONY" : "BLĄD";
        Console.WriteLine($"[{status}] Oczekiwano: {expected,-5} | Wynik: {actual,-5} | Wzorzec: {pattern,-5} | Tekst: {text}");
    }
}