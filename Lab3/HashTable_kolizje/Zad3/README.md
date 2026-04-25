Struktura HashTable - separate chaining

Projektujesz system rejestracji dla operatora telefonii komórkowej. W systemie tym każdy klient musi podać swój numer telefonu, który jest przechowywany w bazie danych operatora. Aby sprawdzić, czy dany numer telefonu jest już zarejestrowany w systemie, operator musi przeszukać bazę danych w celu znalezienia numeru telefonu. Ponieważ baza danych operatora jest bardzo duża, operator chce, aby operacja sprawdzenia, czy dany numer telefonu jest zarejestrowany w systemie, była wykonywana w czasie stałym.

Zadanie polega na zaimplementowaniu w języku C# struktury danych HashTable, która będzie przechowywać numery telefonów (numer telefonu to ciąg cyfr, o długości od trzech do maksymalnie dziewięciu). Struktura ta ma umożliwiać dodawanie nowych numerów telefonów (Add), usuwanie numerów telefonów (Remove) oraz sprawdzanie, czy dany numer telefonu znajduje się w zbiorze (Contains). 

Struktura będzie wykorzystana wyłącznie do bardzo szybkiej weryfikacji rejestracji numeru telefonu w zbiorze. Zaprojektuj ją jako tablicę haszującą o rozmiarze ustalanym podczas jej konstruowania. Jako funkcję haszującą przyjmij funkcję obliczającą sumę cyfr numeru telefonu modulo rozmiar tablicy (Size). Przyjmij, że tablica jest indeksowana od 0. W sytuacji wystąpienia kolizji zastosuj technikę separate chaining.

Szkielet klasy, wraz ze specyfikacją metod, podany jest w polu edycyjnym formularza zgłoszeniowego.

WAŻNE: W implementacji nie możesz użyć struktur: Dictionary oraz SortedDictionary (pojawienie się tych słów w Twoim kodzie przerywa kompilację i zgłasza błąd).

Twój kod (STUDENT_ANSWER) zostanie wstawiony w poniższy szkielet. Całość zostanie skompilowana i uruchomiona.

``` C# 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;

// STUDENT_ANSWER

public class Program
{
  public static void Main(string[] args) 
  {
    // TEST.testcode
  }
}
```

Na przykład:

| Test | Wynik |
| :---           | :---  |
| var hashTable = new HashTable(5);
hashTable.Add("123");
hashTable.Add("456");
hashTable.Add("321");
hashTable.Add("234");
hashTable.Add("123");
hashTable.Add("00569");
Console.WriteLine( string.Join(", ", hashTable.GetPhoneNumbers(0)) );
Console.WriteLine( string.Join(", ", hashTable.GetPhoneNumbers(1)) );
Console.WriteLine( string.Join(", ", hashTable.GetPhoneNumbers(2)) );

int index;
Debug.Assert(hashTable.Contains("123", out index) == true);
Debug.Assert(index == 0);

Console.WriteLine(hashTable.Dump());

hashTable.Remove("123");
Console.WriteLine(hashTable.Dump());

hashTable.Remove("321");
Console.WriteLine(hashTable.Dump());| 00569, 456
123, 321

0: 00569, 456
1: 123, 321
4: 234

0: 00569, 456
1: 321
4: 234

0: 00569, 456
4: 234 | 