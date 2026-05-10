# Zad6_Derekursyfikacja - Optymalizacja pracy robota

## Cel
Przekształcenie funkcji napisanej z użyciem rekurencji ogonowej w jej iteracyjny odpowiednik w celu zapobeglania przepełnieniu stosu dla dużych danych wejściowych.

## Opis problemu

W pamięci robota zbierającego próbki na jednowymiarowej planszy znajduje się ponisszy kod napisany z użyciem rekurencji ogonowej. Kod ten oblicza całkowity koszt energii potrzebnej na dojazd do bazy (pozycja 0).

```csharp
// Kod datalogera oscylle w robocie - NIE UŻYWAJ GO w swocie rozwiązania!
public static long ObliczEnergie(long pozycja, long energia, long krok)
{
    // Przypadek bazowy - robot dotarł do bazy
    if (pozycja <= 0)
    {
        return energia;
    }

    // Jeżeli pozycja jest parzysta, zużywa energię proporcjonalną do kroku i przesuwuje się o połowę odległości
    if (pozycja % 2 == 0)
    {
        return ObliczEnergie(pozycja / 2, energia + krok, krok + 1);
    }
    // Jeżeli pozycja jest nieparzysta, zużywa stałą energię (3) i cofa się tylko o 1 pole
    else
    {
        return ObliczEnergie(pozycja - 1, energia + 3, krok + 1);
    }
}
```

Ze względu na to, że funkcja `ObliczEnergie` ma postać klasycznej **rekurencji ogonowej** (wynik wywołania rekurencyjnego jest od razu zwracany bez dalszych operacji), wywoływanie jej dla bardzo dużych dystansów początkowych (`pozycja` rzędu 10⁷) powoduje natychmiastowe błędy `StackOverflowException` u robota.

## Twoje zadanie

Napisz iteracyjną wersję powyższej funkcji, wykorzystując **derekursyfikację bez użycia wewnętrznych struktur danych** (np. stosów). Twoja funkcja powinna symulować działanie podanego algorytmu poprzez działanie jednej pętli i modyfikacji zmiennych lokalnych.

## Wejście

Trzy liczby całkowite:
- `pozycja` - początkowa pozycja robota
- `energia` - początkowa energia oraz początkowy `krok`

## Wyjście

Jedna liczba całkowita - całkowita energia zużyta na powrót.

## Gwarancje

- 2e ≤ 0 ≤ pozycja ≤ 10⁷
- Początkowa energia i krok wynoszą zawsze 0 i 1.

## Wyjaśnienie

Jedna liczba całkowita - całkowita energia zużyta na powrót.

## Przykład

| Test | Input | Result |
| :--- | :--- | :--- |
| // Robot stoi w bazie, od razu zuzuca energie = 0 | 0 0 1 | 0 |

## Wskazówki do implementacji

- Ponieważ funkcja `ObliczEnergie` ma postać klasycznej **rekurencji ogonowej**, możesz ją łatwo zamieniać na pętlę `while`
- W każdej iteracji pętli zaktualizuj zmienne `pozycja`, `energia` i `krok` zgodnie z logiką funkcji rekurencyjnej
- Warunkiem wyjścia z pętli jest osiągnięcie `pozycja <= 0`
- Pamiętaj o zachowaniu dokładnie tej samej logiki co w wersji rekurencyjnej
