# Zad8_DP - Programowanie Dynamiczne - Tabulacja (Ekstrakcja Minerałów)

## Cel
Zastąpienie kosztownej procedury zstępującej (Top-Down) metodą tabulacyjną (Bottom-Up) i optymalizacja zajętości pamięci RAM.

## Opis problemu

Wirtualny górnik znajduje się na szczycie wielkiej, piramidальnej formacji minerałów. W każdym ruchu w dół może poruszyć się tylko do wyróżniacza lewego lub prawego w następnym poziomie. Twoim celem to napisać algorytm określający maksymalną sumę wartości minerałów, jaką może zebrać od szczytu aż do samej podstawy (dna) piramidy.

### Przykład piramidy:

```
      7
    3   8
   8   1   0
  2   7   4   4
```

Zaczynaając od **7**, górnik ma do wyboru pójść na lewo do **3** albo na prawo do **8**. Gdy zejdzie np. do **3**, w następnym poziomie bedzie musiał znów wybrać znów wybierać lewo() lub prawo(). Najlepsza ścieżka dla podanej wyżej piramidy jest: **7 → 3 → 8 → 7**, co daje w sumie wynik 25.

## Specyfikacja

Jeżeli piszałyś ten algorytm standardową metodą top-down (rekurencja z memoizacją), musiałbyś analizować liczne odgałęzienia, gubiąc wydajność na dużych głębokościach.

## Twoje zadanie

Napisz funkcję korzystającą z techniki **tabulacji** (programowanie dynamiczne w wersji bottom-up). Algorytm powinien zacząć analizę od **ostatniego (najmniejszego) rzędu** do dołu (od szczytu góry - poprzedniego rzędu piramidy, wyliczając do pojedynczej liczby całkowitej będącej maksymalną sumą.

Taka implementacja unieznaczalnie Cię w pełni od zapytań systemowych, stosów oraz funkcji wywołyań.

Taka implementacja uniemożliwia Ci w pełni od zapytań systemowych, stosów oraz funkcji wywołań.

## Wejście:

- Pierwsza linia zawiera liczbę **N** (1 ≤ N ≤ 1000) oznaczającą wysokość piramidy.
- Kolejne **N** linii to poszczególne poziomy piramidy. Linia o numerze **i** zawiera dokładnie **i** liczb całkowitych reprezentujących wartości złóż w komorach (wartość z zakresu 0 – 90).

## Wyjście:

- Dokładnie jedna liczba całkowita – największa możliwa do wydobycia suma minerałów od szczytu do samej podstawy.

Podpowiedź: Ostatnia warstwa na samym początku staje się nasza tablica "wynikowa" dn. Potem pętla analizuje rząd wyżej, nadpisując wartości w oparciu o poprzednie (już policzone, z rzędu pod nią).

Ponieważ nadpisujemy tę samą tablicę, złożoność pamięciowa to **O(N)** (zamiast O(N²) z tworzenia rekurencji).

## For example:

| Input | Result |
| :--- | :--- |
| 4 | 25 |
| 7 | |
| 3 8 | |
| 8 1 0 | |
| 2 7 4 4 | |

## Wskazówki do implementacji

1. **Wczytaj piramidę** - przechowuj ją w tablicy 2D lub liście list
2. **Zacznij od spodu** - ostatni rząd piramidy jest punktem wyjścia
3. **Iteruj w górę** - idź rząd po rzędzie w kierunku szczytu
4. **Dla każdego pola** - oblicz maksymalną sumę będącą:
   - wartością bieżącego pola
   - plus maksimum z dwóch pól poniżej
5. **Optimizacja pamięci** - możesz nadpisywać wiersze w miejscu, używając tylko jednego wiersza roboczego

## Oczekiwany rezultat

Po implementacji tabulacji algorytm powinien działać błyskawicznie nawet dla piramid o wysokości 1000, osiągając złożoność czasową **O(N²)** i złożoność pamięciową **O(N)**.
