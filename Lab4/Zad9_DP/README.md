# Zad9_DP - Memoizacja 2D w problemie wariacyjnym (Najtańsza podróż)

## Cel
Stworzenie rekurencyjnego algorytmu rozwiązującego problem optymalizacyjny na siatce dwuwymiarowej i przyspeszenie go za pomocą klasycznej struktury cache (memoizacji 2D).

## Opis problemu

Wcielasz się w rolę projektanta tras dla zautomatyzowanego drona kurierskiego zasilanego drogim paliwem węglowodorowym. Dron porusza się po dwuwymiarowej siatce (macierzy) o rozmiarach **H × W**, gdzie każde pole ma przypisany koszt przelotu (ilość jednostek zużywanego paliwa, np. w strefach wietrznych jest on wysoki).

Zadaniem drona jest przelot z lewego górnego rogu – punktu **(0, 0)** – do prawego dolnego rogu – punktu **(H-1, W-1)**. Dron może się poruszać **wylącznie w prawo i w dół**.

Otrzymałeś zarys zaledwie zaczęty algorytm obliczającego najmniejszy możliwy koszt paliwa dla takiej podróży. Musisz użyć do tego **rekurencji Top-Down**, wspomaganej przez **dwuwymiarową strukturę memoizacji** (tzw. słownik / cache), w celu powtrzemiania powielających się kalkulacji.

### Wzór rekurencyjny:

$$\text{Koszt w }(x, y) = \text{Paliwo w }(x, y) + \min(\text{Koszt w }(x-1,y), \text{Koszt w }(x,y-1))$$

Zauważ, że jeśli wejdziesz w górną lub lewą "ścianę" mapy (x < 0 lub y < 0), Twój rekurencyjny algorytm powinien chronić drona przed tą trasą, zwracając bardzo wysoką liczbę (np. `int.MaxValue`) zamiast zera, jako że wyjście poza układ ma "nieskończony koszt" i nie jest pozydany kierunek wyboru w instrukcji `min()`.

## Wejście:

- Pierwsza linia zawiera dwie liczby całkowite: wysokość **H** i szerokość **W** (1 ≤ H, W ≤ 50).
- Następne **H** linii to mapy kosztów. Każda linia składa się z **W** liczb całkowitych (od 1 do 99), określających lokalne zapotrzebowanie na paliwo.

## Wyjście:

- Dokładnie jedna liczba całkowita – minimalny zsumowany koszt podróży.

## Wskazówki do implementacji:

- Pierwsza linia zawiera dwie liczby całkowite: wysokość **H** i szerokość **W** (1 ≤ H, W ≤ 50).
- Następne **H** linii to mapy kosztów. Każda linia składa się z **W** liczb całkowitych (od 1 do 99), określających lokalne zapotrzebowanie na paliwo.

## Wyjście:

- Dokładnie jedna liczba całkowita – minimalny zsumowany koszt podróży.

## For example:

| Input | Result |
| :--- | :--- |
| 3 3 | 7 |
| 1 3 1 | |
| 1 5 1 | |
| 4 2 1 | |

## Wskazówki do implementacji

1. **Wczytaj macierz kosztów** - przechowuj ją w tablicy 2D
2. **Stwórz cache 2D** - tablica `memo[H][W]` inicjalizowana wartościami `-1` (oznaczająca "nie obliczono")
3. **Implementuj rekurencję Top-Down**:
   - Jeśli punkt jest poza mapą (x < 0 lub y < 0), zwróć `int.MaxValue` lub bardzo wysoką liczbę
   - Jeśli punkt to (0, 0), zwróć koszt tego pola
   - Jeśli wynik jest w cache'u, zwróć go natychmiast
   - W przeciwnym razie oblicz minimum z drogi z góry i z lewej, dodaj koszt bieżącego pola
   - **Zapamiętaj wynik** w cache'u przed zwróceniem
4. **Optymizacja pamięci** - możesz używać tylko jednego wiersza roboczego zamiast całej macierzy

## Oczekiwany rezultat

Po implementacji memoizacji 2D algorytm powinien działać błyskawicznie nawet dla map o rozmiarze 50×50, osiągając złożoność czasową **O(H×W)** i złożoność pamięciową **O(H×W)**.
