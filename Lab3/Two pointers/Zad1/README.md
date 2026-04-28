Dana jest tablica liczb całkowitych.
Twoim zadaniem jest znaleźć długość najdłuższego spójnego fragmentu tablicy, który jest ściśle rosnący, tzn. dla każdego kolejnego elementu fragmentu zachodzi:
A[i] < A[i+1]
dla wszystkich kolejnych par w obrębie tego fragmentu.

Wejście:
    - W pierwszym wierszu znajduje się jedna liczba całkowita n - liczba elementów tablicy.
    - W drugim wierszu znajduje się n liczb całkowitych A[1], A[2], ..., A[n].

Wyjście:
    - Wypisz jedną liczbę całkowitą - długość najdłuższego spójnego fragmentu tablicy, który jest ściśle rosnący.

Zadanie oceniane jest automatycznie — ocena progresywna (na podstawie czasu działania):
    1. Zadanie poprawnie rozwiązane, wydajność porównywalna z algorytmem brute force: 30% punktów.
    2. Zadanie poprawnie rozwiązane, wydajność porównywalna z implementacją referencyjną: 80% punktów.
    3. Zadanie poprawnie rozwiązane, wydajność lepsza niż referencyjna: 90% punktów.
    4. Zadanie poprawnie rozwiązane, rozwiązanie pomysłowe: 100% punktów.
    5. Przekroczenie limitu czasu (TLE): 0% punktów.

Testowanie:
    1. Na początku sprawdzana jest poprawność rozwiązania na kilku prostych przykładach.
    2. Następnie Twój program testowany jest na jednym dużym zestawie danych. Na tych samych danych mierzony jest czas dla trzech wzorcowych rozwiązań       (brute force, referencyjne, super optymalizowane). Na tej podstawie ustalana jest ocena punktowa.

For example:
| Input | Result |
|  :--- | :---   |
| 8
  1 2 3 2 3 4 5 1  |  4  |
| 5
  5 4 3 2 1        |  1  |
| 7
  2 2 2 2 2 2 2    |  1  |