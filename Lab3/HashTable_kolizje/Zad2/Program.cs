// Napisz program
// kompilator mono/Linux, kompatybilność C# 7.2
using System;

class Program
{
    static void Main()
    {
        string[] table = new string[101];
        int count = 0;
        
        string firstLine = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(firstLine)) return;
        if (!int.TryParse(firstLine.Trim(), out int n)) return;
        
        for (int i = 0; i < n; i++)
        {
            string line = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(line)) continue;
            
            string[] odzielone = line.Split(':');
            if (odzielone.Length < 2) continue;
            
            string metoda = odzielone[0].Trim();
            string wyraz = odzielone[1].Trim();
            
            int hash = 0;
            for (int k = 0; k < wyraz.Length; k++)
            {
                hash += (int)wyraz[k] * (k + 1);
            }
            hash *= 19;
            hash %= 101;
            
            if (metoda == "INSERT")
            {
                bool exists = false;
                for (int j = 0; j < 20; j++)
                {
                    int idx = (hash + j * j + 23 * j) % 101;
                    if (table[idx] == wyraz)
                    {
                        exists = true;
                        break;
                    }
                }
                
                if (!exists)
                {
                    for (int j = 0; j < 20; j++)
                    {
                        int idx = (hash + j * j + 23 * j) % 101;
                        if (table[idx] == null)
                        {
                            table[idx] = wyraz;
                            count++;
                            break;
                        }
                    }
                }
            }
            else if (metoda == "DELETE")
            {
                for (int j = 0; j < 20; j++)
                {
                    int idx = (hash + j * j + 23 * j) % 101;
                    if (table[idx] == wyraz)
                    {
                        table[idx] = null;
                        count--;
                        break;
                    }
                }
            }
        }
        
        Console.WriteLine(count);
        for (int i = 0; i < 101; i++)
        {
            if (table[i] != null)
            {
                Console.WriteLine($"{i}:{table[i]}");
            }
        }
    }
}