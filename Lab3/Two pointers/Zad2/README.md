Dla tablicy liczb całkowitych znajdź najmniejszą liczbę elementów, które trzeba usunąć, by reszta była niemalejąca.

Wejście:
    - W pierwszym wierszu znajduje się jedna liczba całkowita n - liczba elementów tablicy.
    - W drugim wierszu znajduje się n liczb całkowitych A[1],A[2],...,A[n].

Wyjście:
    - Wypisz jedną liczbę całkowitą - najmniejszą liczbę elementów, które trzeba usunąć, by reszta ciągu była niemalejąca

Zadanie oceniane jest automatycznie — ocena progresywna (na podstawie czasu działania):
    1. Zadanie poprawnie rozwiązane, wydajność porównywalna z algorytmem brute force: 30% punktów.
    2. Zadanie poprawnie rozwiązane, wydajność porównywalna z implementacją referencyjną: 80% punktów.
    3. Zadanie poprawnie rozwiązane, wydajność lepsza niż referencyjna: 90% punktów.
    4. Zadanie poprawnie rozwiązane, rozwiązanie pomysłowe: 100% punktów.
    5. Przekroczenie limitu czasu (TLE): 0% punktów.

Testowanie:
    1. Na początku sprawdzana jest poprawność rozwiązania na kilku prostych przykładach.
    2. Następnie Twój program testowany jest na jednym dużym zestawie danych. Na tych samych danych mierzony jest czas dla trzech wzorcowych rozwiązań (brute force, referencyjne, super optymalizowane). Na tej podstawie ustalana jest ocena punktowa.

For example:
| Input | Result |
|  :--- | :---   |
| 5
  1 2 2 3 5  |  0  |
| 5
  5 4 3 2 1  |  4  |
| 6
  1 3 2 4 3 5|  2  |