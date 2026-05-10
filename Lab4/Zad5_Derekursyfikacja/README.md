# Zad5_Derekursyfikacja - Skaner struktury systemu plików

## Cel
Przekształcenie funkcji realizującej nieliniową rekurencję nieogonową do postaci iteracyjnej przy jawnym użyciu struktury danych Stosu (Stack<T>).

## Opis problemu

Otrzymałeś kod systemu operacyjnego odpowiedzialny za zliczanie rozmiaru wszystkich plików w uszkodzonych sektorach głęboko zagnieżdżonego systemu katalogów (reprezentowanego przez wirtualne ID wpisów). Ze względu na to, że zagnieżdżenie katalogów przekracza kilkaset tysięcy poziomów, standardowy algorytm powoduje przepełnienie stosu wywołań.

### Kod aktualnie używany (NIE używaj go w rozwiązaniu!):

```csharp
public static long ZliczRozmiar(int idKatalogu)
{
    // Warunek stopu (Katalog nie istnieje / jest pułapką)
    if (idKatalogu <= 0) return 0;

    // Pobieramy rozmiar plików w bieżącym katalogu 
    // (w tym zadaniu symulujemy to jako: idKatalogu % 10)
    long rozmiarBiezacy = idKatalogu % 10;

    // REKURENCJA NIEOGONOWA:
    // Musimy wywołać funkcję dwukrotnie dla podkatalogów (lewego i prawego)
    // a potem, PO POWROCIE z tych funkcji, dokończyć operację dodawania.
    int idLewy = idKatalogu / 2;
    int idPrawy = idKatalogu / 3;

    long rozmiarLewy = ZliczRozmiar(idLewy);
    long rozmiarPrawy = ZliczRozmiar(idPrawy);

    return rozmiarBiezacy + rozmiarLewy + rozmiarPrawy;
}
```

### Uwaga projektowa

W powyższej funkcji wynik wywołania rekurencyjnego nie jest od razu zwracany – program musi "pamiętać", żeby zsumować oba wyniki po ich obliczeniu. To uniemożliwia użycie prostej pętli i przypisań.

## Specyfikacja wejścia/wyjścia

### Dane wejściowe (stdin):
- Jedna liczba całkowita **idKatalogu** (0 ≤ idKatalogu ≤ 10⁷)

### Dane wyjściowe (stdout):
- Jedna liczba całkowita — całkowity rozmiar zliczonych plików

### For Example
| Input	| Result|
| :--- | :--- |
|0 | 0 | 


## Wymagania implementacyjne

- ✅ Rozwiązanie **musi być iteracyjne** (bez rekurencji)
- ✅ **Obowiązkowe użycie jawnej struktury Stack<T>** (ze zmiennych, nie ze stosu wywołań)
- ✅ Obliczenie musi być **identyczne** z wersją rekurencyjną
- ✅ Rozwiązanie musi radzić sobie z dużymi wartościami idKatalogu bez przepełnienia stosu

## Podpowiedź algorytmiczna

Rozwiązanie polega na:
1. Zainicjowaniu **własnego stosu** (na stercie w pamięci RAM) zawierającego węzły do przetworzenia
2. Zdjęciu głównego problemu ze stosu systemowego i zrzuceniu go na nasz stos
3. Gdy węzeł zostanie pobrany ze stosu:
   - Obliczenie jego własnej "wartości" (rozmiar = idKatalogu % 10)
   - Dorzucenie jego dzieci (lewego i prawego podkataloga) na stos
4. Iteracja kończy się, gdy stos jest pusty

## Przykład

Dla **idKatalogu = 12**:

```
idKatalogu = 12 → rozmiar = 12 % 10 = 2
  ├─ idLewy = 12 / 2 = 6 → rozmiar = 6 % 10 = 6
  │   ├─ idLewy = 6 / 2 = 3 → rozmiar = 3 % 10 = 3
  │   │   ├─ idLewy = 3 / 2 = 1 → rozmiar = 1 % 10 = 1
  │   │   │   ├─ idLewy = 0 (stop)
  │   │   │   └─ idPrawy = 0 (stop)
  │   │   └─ idPrawy = 3 / 3 = 1 → rozmiar = 1 (już liczony)
  │   └─ idPrawy = 6 / 3 = 2 → rozmiar = 2 % 10 = 2
  │       ├─ idLewy = 1 → rozmiar = 1 (już liczony)
  │       └─ idPrawy = 0 (stop)
  └─ idPrawy = 12 / 3 = 4 → rozmiar = 4 % 10 = 4
      ├─ idLewy = 4 / 2 = 2 → rozmiar = 2 (już liczony)
      └─ idPrawy = 4 / 3 = 1 → rozmiar = 1 (już liczony)

Suma: 2 + 6 + 3 + 1 + 1 + 2 + 2 + 1 + 4 + 2 + 1 = 25
```

## Wskazówki do implementacji

- Użyj `Stack<int>` do przechowywania ID katalogów do przetworzenia
- Pamiętaj, że każdy katalog może być odwiedzony wielokrotnie (ostatecznie dodajemy jego rozmiar)
- Możesz użyć słownika (`Dictionary<int, long>`) do zapamiętania już obliczonych rozmiarów (opcjonalnie dla optymalizacji)
- Upewnij się, że algorytm obsługuje przypadek granicznego (idKatalogu = 0)
