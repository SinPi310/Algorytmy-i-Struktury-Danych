public class HashTable
{
    private readonly List<string>[] _buckets;
    
    // Konstruktor przyjmuje rozmiar tablicy haszującej
    // (liczba nieujemna)
    public HashTable(int size)
    {
        Size = size;
        Count = 0;
        _buckets = new List<string>[size];
        
        for (int i = 0; i < size; i++)
        {
            _buckets[i] = new List<string>();
        }
        
        GetHashFunction = (phoneNumber) =>
        {
            int sum = 0;
            for (int i = 0; i < phoneNumber.Length; i++)
            {
                sum += phoneNumber[i] - '0';
            }
            return sum % Size;
        };
    }

    // Dodaje numer telefonu do tablicy, zwraca `true`, 
    // jeśli numer nie był wcześniej w tablicy i został skutecznie zarejestrowany
    public bool Add(string phoneNumber)
    {
        int index = GetHashFunction(phoneNumber);
        
        if (_buckets[index].Contains(phoneNumber))
        {
            return false;
        }
        
        _buckets[index].Add(phoneNumber);
        Count++;
        return true;
    }

    // Usuwa numer telefonu z tablicy, zwraca `true`,
    // jeśli numer był wcześniej w tablicy i został skutecznie usunięty
    public bool Remove(string phoneNumber)
    {
        int index = GetHashFunction(phoneNumber);
        
        if (_buckets[index].Remove(phoneNumber))
        {
            Count--;
            return true;
        }
        return false;
    }

    // Sprawdza, czy numer telefonu znajduje się w tablicy,
    // zwraca `true`, jeśli numer znajduje się w tablicy, 
    //   zaś w zmiennej `index` lokalizację wpisu w tablicy
    // zwraca `false`, jeśli numer nie znajduje się w tablicy, 
    //   zaś w zmiennej `index` zwraca wartość `-1`
    public bool Contains(string phoneNumber, out int index)
    {
        int hashIndex = GetHashFunction(phoneNumber);
        
        if (_buckets[hashIndex].Contains(phoneNumber))
        {
            index = hashIndex;
            return true;
        }
        
        index = -1;
        return false;
    }

    // Zwraca numery telefonów zapamiętane w tablicy pod danym indeksem w porządku rosnącym (leksykograficznym)
    // Jeśli pod danym indeksem nie ma żadnego numeru telefonu, zwraca pustą kolekcję.
    public IEnumerable<string> GetPhoneNumbers(int index)
    {
        if (index < 0 || index >= Size)
        {
            return Enumerable.Empty<string>();
        }
        
        return _buckets[index].OrderBy(x => x);
    }

    // Zwraca wykorzystywaną funkcję haszującą
    public Func<string, int> GetHashFunction { get; }

    // Zwraca rozmiar tablicy
    public int Size { get; }

    // Zwraca liczbę zarejestrowanych numerów telefonów
    public int Count { get; private set; }

    // Zwraca współczynnik obciążenia tablicy haszującej
    // z dokładnością do dwóch miejsc po przecinku (metoda `Math.Round`)
    public double LoadFactor
    { 
        get 
        {
            if (Size == 0) return 0;
            return Math.Round((double)Count / Size, 2);
        }
    }

    // Zwraca reprezentację tablicy haszującej w postaci tekstowej:
    // wypisuje, w porządku rosnącym, w kolejnych wierszach,
    // indeksy tablicy w komórkach których znajdują się wpisy oraz
    // numery telefonów w każdej z komórek (w porządku rosnącym, leksykograficznym)
    // w formacie: "index: phoneNumber1, phoneNumber2, phoneNumber3, ..."
    // Jeśli w danej komórce nie ma żadnego numeru telefonu, nic nie wypisuje
    public string Dump()
    {
        string result = "";
        
        for (int i = 0; i < Size; i++)
        {
            if (_buckets[i].Count > 0)
            {
                var sortedNumbers = _buckets[i].OrderBy(x => x);
                result += $"{i}: {string.Join(", ", sortedNumbers)}\n";
            }
        }
        
        return result;
    }
}