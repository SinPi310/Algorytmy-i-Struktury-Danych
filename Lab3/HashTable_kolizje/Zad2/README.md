HashTable - open addressing

Twoim zadaniem jest implementacja procesu haszowania w tablicy o 101 elementach, zawierającej klucze będące łańcuchami znaków o długości maksymalnie 15 liter (kody ASCII od 'A' do 'z'). Zaimplementuj następujące operacje:

    FIND - znajdź indeks elementu zdefiniowanego przez klucz (ignoruj, jeśli nie ma takiego elementu),
    INSERT - wstaw nowy klucz do tablicy (ignoruj wstawianie klucza, który już istnieje),
    DELETE - usuń klucz z tablicy (bez przesuwania innych elementów), oznaczając pozycję w tablicy jako pustą (ignoruj klucze, które nie istnieją w tablicy).

Podczas wykonywania operacji FIND, INSERT i DELETE wykorzystuj następującą funkcję:

Hash(stringkey):integer

która dla łańcucha znaków key=a1...an zwraca wartość:

Hash(key)=h(key)mod101

gdzie:

    h(key)=19⋅(ASCII(a1)⋅1+...+ASCII(an)⋅n)
    ASCII(c) - umownie funkcja zwracająca kod ASCII znaku c.

Rozstrzygaj kolizje za pomocą metody otwartego adresowania, tj. próbuj wstawić klucz do tablicy na pierwszą wolną pozycję wyznaczoną wzorem:

(Hash(key)+j2+23⋅j)mod101, dla j=1,...,19

gdzie j to liczba prób wstawienia klucza. Po sprawdzeniu co najmniej 20 pozycji w tablicy zakładamy, że operacja wstawienia nie może zostać wykonana - klucz nie zostanie dodany do tablicy, bez informowania o tej sytuacji.
Wejście

    n - liczba operacji INSERT lub DELETE n≤1000 - tylko jedna operacja w linii
    INSERT:key - dodanie klucza do tablicy, lub
    DELETE:key - usunięcie klucza z tablicy

Pomiędzy nazwą operacji a kluczem znajduje się dwukropek, nie ma spacji. Klucz to niepusty łańcuch znaków o długości maksymalnie 15 liter (kody ASCII od 'A' do 'z').

Wyjście
- Liczba kluczy w tablicy (pierwsza linia)
    posortowany rosnąco według indeksów ciąg zapisów Indeks:key

--- 

Zadanie jest modyfikacją zadania z serwisu SPOJ (https://www.spoj.com/problems/HASHIT/)

Na przykład:

| Dane wejściowe | Wynik |
| :---           | :---  |
| 11
INSERT:marsz
INSERT:marsz
INSERT:Dabrowski
INSERT:z
INSERT:ziemii
INSERT:wloskiej
INSERT:do
INSERT:Polski
DELETE:od
DELETE:do
DELETE:wloskiej| 5
34:Dabrowski
46:Polski
63:marsz
76:ziemii
96:z | 