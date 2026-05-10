using System;
using System.Collections.Generic;

public class Program
{

    public static void Main()
    {
        string input = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(input)) return;
        
        if (int.TryParse(input.Trim(), out int idKatalogu))
        {
            Console.WriteLine(ZliczRozmiarIteracyjnie(idKatalogu));
        }
    }
    
    public static long ZliczRozmiarIteracyjnie(int startId)
    {
        if (startId <= 0) return 0;
        
        long calkowityRozmiar = 0;
        
        Stack<int> stos = new Stack<int>();
        
        stos.Push(startId);
        
        while (stos.Count > 0)
        {
            int aktualnyKatalog = stos.Pop();
            
            calkowityRozmiar += aktualnyKatalog % 10;
            
            int idLewy = aktualnyKatalog / 2;
            int idPrawy = aktualnyKatalog / 3;
            
            if (idLewy > 0) 
            {
                stos.Push(idLewy);
            }
            
            if (idPrawy > 0) 
            {
                stos.Push(idPrawy);
            }
        }

        return calkowityRozmiar;
    }
}