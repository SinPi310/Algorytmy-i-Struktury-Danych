# Zad10_DP - Tabulacja 2D (Przydział serwerów do klastrów)

## Cel
Rozwiązanie wariacji problemu kombinatorycznego przy użyciu dwuwymiarowej tabulacji iteracyjnej, bez używania rekurencji.

## Opis problemu

Jako administrator centrum danych musisz rozłokować dokładnie **N** wirtualnych maszyn na dostępnych serwerach fizycznych. Masz do dyspozycji różne modele serwerów, a każdy z nich może pomieścić określoną, stałą liczbę maszyn. Chcesz uniknąć nadmiarowości, czyli:
- Server typ A mieści 1 maszynę
- Server typ B mieści 2 maszyny
- Server typ C mieści 5 maszyn

Chcesz dowiedzieć się, na ile **unikalnych sposobów** możesz zsumować pojemność serwerów, aby pomieścić dokładnie **N** maszyn wirtualnych. (Kolejność dobierania serwerów nie ma znaczenia, np. zestaw [1, 2] to ten sam zestaw co [2, 1]).

## Twoje zadanie

Zbuduj rozwiązanie oparte o **Tabulację 2D**. Stwórz dwuwymiarową tablicę `dp[i, j]`, gdzie:
- **i** to liczba dostępnych w danym kroku modeli serwerów (od 0 do K)
- **j** to liczba maszyn wirtualnych do upakowania (od 0 do N)

Wypełnij tabelę iteracyjnie, operując na poprzedniej linii (poprzedniej relacji przesądzonej):

**Liczba sposobów na upakowanie pojemności** i przy użyciu i pierwszych modeli serwerów wynosi:
1. `dp[i-1, j]` (nie używamy bieżącego serwera w ogóle), PLUS
2. `dp[i, j - pojemność_serwera[i-1]]` (używamy co najmniej jednej sztuki tego serwera).

(Uwaga: w tym zadaniu absolutnie zabronionym jest używanie jakichkolwiek wywoławań rekurencyjnych).

## Wejście:

- Pierwsza linia zawiera jedną liczbę całkowitą **N** (1 ≤ N ≤ 1000) - docelową liczbę maszyn do upakowania.
- Druga linia zawiera listę unikalnych liczb całkowitych oddzielonych spacjami, oznaczających pojemności dostępnych modeli serwerów.

## Wyjście:

- Dokładnie jedna liczba całkowita - liczba unikalnych kombinacji. Gwarantujemy, że dla testów wynik zmieści się w zimiennej 64-bitowej.

## Przykład:

### Dla danych:

```
5
1 2 5
```

### Sposoby to: {1,1,1,1,1}, {1,1,1,2}, {1,2,2}, {5}. Wynik: 4.

## For example:

| Input | Result |
| :--- | :--- |
| 5 | 4 |
| 1 2 5 | |

## Wskazówki do implementacji

1. **Wczytaj dane** - N i listę pojemności serwerów
2. **Zainicjalizuj tablicę** - `dp` o rozmiarze `(K+1) × (N+1)` 
3. **Ustaw przypadek bazowy** - `dp[i][0] = 1` dla wszystkich i (jeden sposób: nie brać żadnego serwera)
4. **Iteruj po modelach serwerów** - dla każdego modelu i (od 1 do K):
   - **Iteruj po pojemnościach** - dla każdej pojemności j (od 1 do N):
     - Jeśli pojemność_serwera[i-1] <= j:
       - `dp[i][j] = dp[i-1][j] + dp[i][j - pojemność_serwera[i-1]]`
     - W przeciwnym razie:
       - `dp[i][j] = dp[i-1][j]`
5. **Zwróć wynik** - `dp[K][N]`

## Optymizacja pamięci

Możesz zoptymalizować pamięć używając tylko dwóch wierszy zamiast całej macierzy (bieżący i poprzedni wiersz), lub nawet jednego wiersza z iteracją od tyłu.

## Oczekiwany rezultat

Po implementacji tabulacji 2D algorytm powinien działać błyskawicznie nawet dla N=1000 i wielu różnych modeli serwerów, osiągając złożoność czasową **O(K×N)** i złożoność pamięciową **O(K×N)** (lub **O(N)** z optymizacją).
