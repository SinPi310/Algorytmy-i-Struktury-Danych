# Zad3_Rekurencja - Wzór iteracyjny na rekurencję

## Cel
Napisz program, który oblicza wartość funkcji F(n,m) zapisując jej definicję w postaci rekurencyjnej, bez używania pętli i bez korzystania z gotowych funkcji bibliotecznych do sumowania lub mnożenia sekwencji.

## Opis problemu
Dana jest funkcja:

$$F(n,m) = \sum_{i=1}^{n} \prod_{j=1}^{m} (i+j)$$

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

## Przykłady

### Przykład 1:
**Wejście:**
```
3 2
```

**Wyjście:**
```
38
```

**Wyjaśnienie:**
```
F(3,2) = (2·3) + (3·4) + (4·5)
       = 6 + 12 + 20
       = 38
```

### Przykład 2:
**Wejście:**
```
4 3
```

**Wyjście:**
```
414
```

**Wyjaśnienie:**
```
F(4,3) = (2·3·4) + (3·4·5) + (4·5·6) + (5·6·7)
       = 24 + 60 + 120 + 210
       = 414
```

For Example: 
| Input | Result |
| :--- | :--- |
| `3 2` | `38` |
| `4 3` | `414` |
| `0 5` | `0` |
| `5 0` | `5` |

## Rozwiązanie
Zaproponowana strategia:
1. Stwórz funkcję rekurencyjną `Sum(i, n, m)` obliczającą sumę dla i-tego elementu
2. Stwórz funkcję rekurencyjną `Product(j, m, i)` obliczającą iloczyn dla danego i
3. Funkcja `Sum` powinna wywoływać `Product` dla każdej wartości i od 1 do n
4. Funkcja `Product` powinna mnożyć wartości od (i+1) do (i+m)
