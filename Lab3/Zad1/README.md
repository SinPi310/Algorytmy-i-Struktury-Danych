Kompilator C# 7.1 (mono-Linux)

$$ Gra $$

Danych jest \(n\) osób ustawionych w okręgu i ponumerowanych od \(1\) do \(n\). W każdej rundzie gry odliczamy kolejne osoby w kierunku rosnących numerów (cyklicznie).

    Liczenie zaczyna się od osoby o numerze \(m\).

    Osoba, która zostanie policzona jako \(i\)‑ta, odpada z gry.

    Liczenie w następnej rundzie rozpoczyna się od osoby stojącej bezpośrednio po tej, która odpadła.

    Proces trwa, aż pozostanie jedna osoba.

Twoim zadaniem jest wyznaczyć numer tej osoby.

Wejście

W jedynym wierszu wejścia znajdują się trzy liczby całkowite: n m i spełniające:

    \(1 \le n \le 10^9\)
    \(1 \le m, i \le n\)

Wyjście

Należy wypisać jedną liczbę całkowitą — numer osoby, która pozostanie jako ostatnia.

Przykład

Dla danych na wejściu 4 1 2 wynikiem będzie 1.

    Początkowy okrąg ma postać: 1, 2, 3, 4
    Zaczynamy liczenie od osoby 1
    W każdej rundzie odliczamy kolejne osoby, wliczając osobę startową jak "1", zaś "2-ga" odpada

Kroki:

    Runda 1
        Liczymy od osoby 1:
        osoba 1 → liczymy „1”,
        osoba 2 → liczymy „2” ⇒ osoba 2 odpada.
        Pozostają: 1, 3, 4.

Następna runda zaczyna się od osoby stojącej po 2, czyli od 3.

    Runda 2
        Liczymy od osoby 3:
        osoba 3 → „1”,
        osoba 4 → „2” ⇒ osoba 4 odpada.
        Pozostają: 1, 3.

Następna runda zaczyna się od osoby po 4, czyli wracamy do 1.

    Runda 3
        Liczymy od osoby 1:
        osoba 1 → „1”,
        osoba 3 → „2” ⇒ osoba 3 odpada.

Pozostaje tylko osoba 1.

Zadanie oceniane jest automatycznie — ocena progresywna (na podstawie czasu działania):

    Zadanie poprawnie rozwiązane, wydajność porównywalna z algorytmem brute force: 30% punktów.
    Zadanie poprawnie rozwiązane, wydajność porównywalna z implementacją referencyjną: 80% punktów.
    Zadanie poprawnie rozwiązane, wydajność lepsza niż referencyjna: 90% punktów.
    Zadanie poprawnie rozwiązane, rozwiązanie pomysłowe: 100% punktów.
    Przekroczenie limitu czasu (TLE): 0% punktów.

Testowanie:

    Na początku sprawdzana jest poprawność rozwiązania na kilku prostych przykładach.
    Następnie Twój program testowany jest na jednym dużym zestawie danych. Na tych samych danych mierzony jest czas dla trzech wzorcowych rozwiązań (brute force, lista cykliczna, rozwiązanie super-optymalne). Na tej podstawie ustalana jest ocena punktowa.

Rozwiązanie brute force: implementacja w liście (tablicy)

Sugerowane rozwiązanie referencyjne: dynamiczna lista cykliczna, rozwiązanie przez symulację.

Dane wejściowe 	Wynik

4 1 2
1

5 2 3
5

6 1 2
5

1 1 1
1
