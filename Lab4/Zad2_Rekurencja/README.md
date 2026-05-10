# Zad2_Rekurencja - Infekcja cyfrowej siatki z limitem czasowym

## Cel
Zapisz w formie funkcji/procedury rekurencyjnej rozwiązanie problemu modelowania rozrostu na dwuwymiarowej siatce przy uwzględnieniu ograniczonej liczby operacji (kroków rekurencji).

## Opis problemu
W systemie komputerowym reprezentowanym przez dwuwymiarową tablicę znaków o rozmiarach W×H pojawił się wirus. Znak `.` oznacza czysty sektor, znak `#` to zapora ogniowa (firewall), przez którą wirus nie może przeniknąć. Wirus z każdym swoim wywołaniem rozprzestrzenia się o jedno pole w jednym z czterech kierunków (góra, dół, lewo, prawo).

System posiada jednak zabezpieczenie antywirusowe, które przerywa dalsze rozprzestrzenianie się wirusa po wykonaniu dokładnie **K** udanych infekcji sektorów (czyli zamian `.` na `V`). Twoim zadaniem jest napisanie funkcji rekurencyjnej, która zwróci dokładny stan systemu (mapę) w momencie, gdy wirus dokona swojej K-tej infekcji, lub stan ostateczny, jeśli wirus zakazi wszystkie dostępne pola przed osiągnięciem limitu K.

### Uwaga projektowa
Aby wyniki testów były deterministyczne, przyjmij następującą stałą kolejność sprawdzania (i potencjalnego wywoływania rekurencji dla) kierunków:
1. **GÓRA** (Y-1)
2. **DÓŁ** (Y+1)
3. **LEWO** (X-1)
4. **PRAWO** (X+1)

## Przypadek szczególny (Edge Case)
System zrzucający wirusa na siatkę bywa niedokładny. Może się zdarzyć, że podane współrzędne startowe (X,Y) trafią bezpośrednio na zaporę ogniową (`#`). W takiej sytuacji wirus nie jest w stanie się zainicjować i natychmiast obumiera. Limit infekcji K nie zostaje naruszony, a program powinien zwrócić całkowicie niezmienioną mapę pierwotną. Twój algorytm rekurencyjny musi być na to odporny i odpowiednio wcześnie przerwać działanie.

## Specyfikacja wejścia/wyjścia

### Dane wejściowe (stdin):
- Liczby **H** (wysokość) i **W** (szerokość) - gdzie 1≤H,W≤50
- Dwie liczby **X** (kolumna) i **Y** (wiersz) oznaczające punkt startowy wirusa
- Liczba całkowita **K** (0≤K≤2500) oznaczająca dozwoloną liczbę udanych infekcji (w tym startowej)
- Tablica/lista 2D znaków

### Dane wyjściowe (stdout):
Zmodyfikowana tablica 2D w postaci tekstowej (wypisana wiersz po wierszu), obrazująca stan siatki po wykonaniu co najwyżej K infekcji.

## Przykład

| Input | Result |
| :--- | :--- |
| `4 5`<br>`2 2`<br>`4`<br>`.....`<br>`.#.#.`<br>`.#...`<br>`.....` | `.VV..`<br>`.#V#.`<br>`.#V..`<br>`.....` |
| `4 5`<br>`1 1`<br>`3`<br>`.....`<br>`.#.#.`<br>`.#...`<br>`.....` | `.....`<br>`.#.#.`<br>`.#...`<br>`.....` |

### Wyjaśnienie przebiegu (Y=2, X=2, K=4):
1. Wirus zaczyna na (2,2) - **infekuje**. K spada z 4 na 3.
2. Idzie w **GÓRĘ** na (1,2) - **infekuje**. K spada z 3 na 2.
3. Będąc na (1,2) idzie w **GÓRĘ** na (0,2) - **infekuje**. K spada z 2 na 1.
4. Będąc na (0,2):
   - Idzie w **GÓRĘ** - ściana pokoju (return)
   - Idzie w **DÓŁ** na (1,2) - już zainfekowane (return)
   - Idzie w **LEWO** na (0,1) - **infekuje**. K spada do 0.
5. **Limit osiągnięty** - wszystkie kolejne odgałęzienia natychmiast wracają. Algorytm się zatrzymuje, tworząc kształt litery