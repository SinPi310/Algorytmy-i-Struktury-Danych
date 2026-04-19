# **Zadanie: Fraktalny podział zasobów (Złoty podział pudełek)**
**Cel:** Zapisz w formie funkcji/procedury rekurencyjnej rozwiązanie problemu zliczania najmniejszych elementów w nieregularnie zagnieżdżonej strukturze.

## **Opis problemu**
Firma logistyczna przechowuje cenne przedmioty w specjalnych matrioszkowych pudełkach. Złota zasada firmy mówi, że każde pudełko o pojemności **N** (gdzie **N > 0**) zawiera dokładnie jedno pudełko o pojemności ⌊**N/2**⌋ oraz dwa pudełka o pojemności ⌊**N/3**⌋. Pudełka o pojemności 0 są puste i nie zawierają już niczego. Twoim zadaniem jest napisanie funkcji rekurencyjnej, która dla podanego rozmiaru głównego pudełka **N** obliczy, ile łącznie pustych pudełek (o pojemności 0) znajduje się w całej zagnieżdżonej strukturze.

## Specyfikacja wejścia/wyjścia:
Dane pobierasz ze `stdin`, wyniki wypisujesz na `stdout`.
 - Wejście: Pojedyncza liczba całkowita **N**(**0 ≤ N ≤ 10^5**), oznaczająca pojemność początkowego pudełka.
 - Wyjście: Liczba całkowita oznaczająca całkowitą liczbę pustych pudełek (o pojemności **0**) wewnątrz struktury.

**For example:**
| **Input** | **Result** |
| :---  | :---   | 
| 1 |  3 | 
| 4 | 11 | 
| 5 | 11 | 
| 6 | 19 | 
