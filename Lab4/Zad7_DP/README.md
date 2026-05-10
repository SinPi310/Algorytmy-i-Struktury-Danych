# Zad7_DP - Programowanie Dynamiczne - Memoizacja (Liczba bezpiecznych tras)

## Cel
Optymalizacja naiwnego algorytmu rekurencyjnego poprzez zaimplementowanie struktury cache (memoizacji) zapamiętującej stany już obliczonych podproblemów.

## Opis problemu

Dron kurierski musi przemieścić się z lewego górnego rogu siatki (współrzędne **(0, 0)**) do prawego dolnego rogu (**H-1, W-1**). Dron może poruszać się wyjątkowo w dół (zwiększając **i**) lub w prawo (zwiększając **j**). Na siatce znajduje się wiele niebezpiecznych ścieżek, które dron musi omijać.

Otrzymujesz podstawową funkcję rekurencyjną, która zlicza wszystkie unikalne, bezpieczne ścieżki od punktu **(0, 0)** do danego pola **(x, y)**. Funkcja wywołuje samą siebie w celu sprawdzenia tras pochodzących z góry i z lewej strony.

### Kod podstawowy (do optymalizacji):

```csharp
// Wersja rekurencja (bardzo wolna dla dużych planszy) - ZOPTYMALIZUJ JĄ!
public static long PolicTrasy(char[][] siatka, int x, int y)
{
    // Wyjście poza mapę lub trafianie na przeszkodę
    if (x < 0 || y < 0 || siatka[x][y] == '*') return 0;

    // Dotarcie do startu (jest dokładnie i trasa żeby tu pro stać)
    if (x == 0 && y == 0) return 1;

    // Trasy z góry - trasy z lewej
    long trasyGóry = PolicTrasy(siatka, x - 1, y);
    long trasyLewej = PolicTrasy(siatka, x - 1, y);

    return trasyGóry + trasyLewej;
}
```

Ze względu na to, że wiele punktów podródu siatki jest wielokrotnie przeanalizowanych przez różne ścieżki (drzewo wywołań rośnie wniskam - powszychna funkcja jest bezuzdyszna dla map większych niż 20 × 20).

## Twoje zadanie

Zmodyfikuj ten algorytm, dodając do niego mechanizm **memoizacji**. Stwórz i przekaż do funkcji strukturę pamięci podróżnej (np. tablice 2D `long[][]` lub `Dictionary<string, long>`), która będzie zapamiętywać wyniki już obliczonych par **(x, y)**.

Naturalmiastowo zwracaj buforowane wyniki dla raz już obliczonych par **(x, y)**.

## Wejście

W pierwszej linii dwie liczby: wysokość **i** szerokość siatki (1 ≤ H, W ≤ 50).
W kolejnych **H** liniach mapa składająca się ze znaków (wolne pole **i**) (przeszkoda **\***). Pole startowe (0,0) i docelowe (H-1, W-1) są zawsze kropkami.

## Wyjście

Jedna liczba całkowita - łączna liczba unikalnych ścieżek od punktu **(0,0)** do punktu **(H-1, W-1)**. (Wynik mieści się w standardowym 64-bitowym **long**).

## Przykład

| Input | Result |
| :--- | :--- |
| 3 3 | 2 |
| ... | |
| .*. | |
| ... | |

## Wskazówki do implementacji

- W pierwszej linii dwie liczby: wysokość **i** szerokość siatki (1 ≤ H, W ≤ 50).
- W kolejnych **H** liniach mapa składająca się ze znaków (wolne pole **i**) (przeszkoda **\***). Pole startowe (0,0) i docelowe (H-1, W-1) są zawsze kropkami.

Gwarancje:
- Jedna liczba całkowita - łączna liczba unikalnych ścieżek od punktu **(0,0)** do punktu **(H-1, W-1)**. (Wynik mieści się w standardowym 64-bitowym `long`).

## Strategie optymalizacji

1. **Przechowywanie wyników**: Jeżeli już obliczyliśmy wynik dla pary `(x, y)`, nie obliczaj go ponownie - zwróć zapamiętaną wartość
2. **Inicjalizacja cache'a**: Przed wywołaniem głównej funkcji stwórz strukturę do przechowywania wyników (np. `memo[x, y] = -1` oznacza "nie obliczono")
3. **Walidacja cache'a**: Na początku funkcji sprawdź, czy wynik dla `(x, y)` jest już w cache'u
4. **Zapamiętywanie**: Po obliczeniu wyniku zapamiętaj go w cache'u przed zwróceniem

## Oczekiwany rezultat

Po implementacji memoizacji funkcja powinna działać błyskawicznie nawet dla map o rozmiarze 50×50, osiągając liniową złożoność czasową względem liczby pól na siatce.
