public class HashTable
{
    // Konstruktor przyjmuje rozmiar tablicy haszującej
    // (liczba nieujemna)
    public HashTable(int size)
    {
        throw new NotImplementedException();
    }

    // Dodaje numer telefonu do tablicy, zwraca `true`, 
    // jeśli numer nie był wcześniej w tablicy i został skutecznie zarejestrowany
    public bool Add(string phoneNumber)
    {
        throw new NotImplementedException();
    }

    // Usuwa numer telefonu z tablicy, zwraca `true`,
    // jeśli numer był wcześniej w tablicy i został skutecznie usunięty
    public bool Remove(string phoneNumber)
    {
        throw new NotImplementedException();
    }

    // Sprawdza, czy numer telefonu znajduje się w tablicy,
    // zwraca `true`, jeśli numer znajduje się w tablicy, 
    //   zaś w zmiennej `index` lokalizację wpisu w tablicy
    // zwraca `false`, jeśli numer nie znajduje się w tablicy, 
    //   zaś w zmiennej `index` zwraca wartość `-1`
    public bool Contains(string phoneNumber, out int index)
    {
        throw new NotImplementedException();
    }

    // Zwraca numery telefonów zapamiętane w tablicy pod danym indeksem w porządku rosnącym (leksykograficznym)
    // Jeśli pod danym indeksem nie ma żadnego numeru telefonu, zwraca pustą kolekcję.
    public IEnumerable<string> GetPhoneNumbers(int index)
    {
        throw new NotImplementedException();
    }

    // Zwraca wykorzystywaną funkcję haszującą
    public Func<string, int> GetHashFunction { get; }

    // Zwraca rozmiar tablicy
    public int Size { get; }

    // Zwraca liczbę zarejestrowanych numerów telefonów
    public int Count { get; }

    // Zwraca współczynnik obciążenia tablicy haszującej
    // z dokładnością do dwóch miejsc po przecinku (metoda `Math.Round`)
    public double LoadFactor { get; }

    // Zwraca reprezentację tablicy haszującej w postaci tekstowej:
    // wypisuje, w porządku rosnącym, w kolejnych wierszach,
    // indeksy tablicy w komórkach których znajdują się wpisy oraz
    // numery telefonów w każdej z komórek (w porządku rosnącym, leksykograficznym)
    // w formacie: "index: phoneNumber1, phoneNumber2, phoneNumber3, ..."
    // Jeśli w danej komórce nie ma żadnego numeru telefonu, nic nie wypisuje
    public string Dump()
    {
        throw new NotImplementedException();
    }
}
