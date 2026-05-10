# Zad4_Rekurencja - Wzór iteracyjny na rekurencję

## Cel
Napisz program, który oblicza wartość funkcji F(n,m) zapisując jej definicję w postaci rekurencyjnej, bez używania pętli i bez korzystania z gotowych funkcji bibliotecznych do sumowania lub mnożenia sekwencji.

## Opis problemu
Dana jest funkcja:

$$F(n,m) = \sum_{i=1}^{n} \begin{cases} \prod_{j=1}^{m} (i+j) & \text{dla } i \text{ nieparzystych} \\ \sum_{j=1}^{m} (i \cdot j) & \text{dla } i \text{ parzystych} \end{cases}$$

Program powinien wczytać dwie liczby całkowite n i m, a następnie wypisać jedną liczbę: wartość funkcji F(n,m). W rozwiązaniu możesz użyć jednej funkcji rekurencyjnej lub dwóch współpracujących funkcji rekurencyjnych.

## Specyfikacja wejścia/wyjścia

### Dane wejściowe (stdin):
- Dwie liczby całkowite **n** i **m**

### Dane wyjściowe (stdout):
- Jedna liczba całkowita — wartość funkcji F(n,m)

### Ograniczenia:
- 0 ≤ n ≤ 12
- 0 ≤ m ≤ 10

## Wymagania implementacyjne
- ✅ Rozwiązanie **musi być rekurencyjne**
- ❌ Zabrania się używania pętli (`for`, `while`, `do`)
- ❌ Zabrania się korzystania z gotowych funkcji bibliotecznych do sumowania lub mnożenia sekwencji
- ✅ Dopuszczalne są funkcje pomocnicze

## Przykład

### Dla n = 3, m = 2:

**Krok i=1 (nieparzyste):**
```
∏(j=1 do 2) (1+j) = (1+1) · (1+2) = 2 · 3 = 6
```

**Krok i=2 (parzyste):**
```
∑(j=1 do 2) (2·j) = (2·1) + (2·2) = 2 + 4 = 6
```

**Krok i=3 (nieparzyste):**
```
∏(j=1 do 2) (3+j) = (3+1) · (3+2) = 4 · 5 = 20
```

**Suma całkowita:**
```
6 + 6 + 20 = 32
```
For Example
| Input | Result |
| :--- | :--- |
| `3 2` | `32` |
| `4 3` | `180` |
| `0 5` | `0` |
| `5 0` | `3` |

## Rozwiązanie
Zaproponowana strategia:
1. Stwórz funkcję rekurencyjną `Sum(i, n, m)` obliczającą sumę dla i-tego elementu
2. Stwórz funkcję pomocniczą `Product(j, m, i)` obliczającą iloczyn dla danego i (liczby nieparzyste)
3. Stwórz funkcję pomocniczą `SumProduct(j, m, i)` obliczającą sumę iloczynów dla danego i (liczby parzyste)
4. Funkcja `Sum` powinna:
   - Sprawdzić parzystość i
   - Dla liczb nieparzystych wywoływać `Product`
   - Dla liczb parzystych wywoływać `SumProduct`
   - Rekurencyjnie wywoływać się dla następnego i
