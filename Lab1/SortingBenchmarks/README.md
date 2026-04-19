## Zrobiłem Benchmark
```text
BenchmarkDotNet v0.15.8, Windows 11 (10.0.26200.7462/25H2/2025Update/HudsonValley2)
Intel Core i5-9600K CPU 3.70GHz (Coffee Lake), 1 CPU, 6 logical and 6 physical cores
.NET SDK 9.0.307
  [Host]     : .NET 9.0.11 (9.0.11, 9.0.1125.51716), X64 RyuJIT x86-64-v3
  DefaultJob : .NET 9.0.11 (9.0.11, 9.0.1125.51716), X64 RyuJIT x86-64-v3
```

| Method          | N    | Mean            | Error         | StdDev        | Ratio | RatioSD | Gen0     | Gen1   | Allocated | Alloc Ratio |
|---------------- |----- |----------------:|--------------:|--------------:|------:|--------:|---------:|-------:|----------:|------------:|
| DotNetArraySort | 100  |        532.7 ns |       1.34 ns |       1.12 ns |  1.00 |    0.00 |   0.0896 |      - |     424 B |        1.00 |
| BubbleSort      | 100  |      4,673.2 ns |      28.41 ns |      23.73 ns |  8.77 |    0.05 |   0.0839 |      - |     424 B |        1.00 |
| InsertionSort   | 100  |      1,775.7 ns |      15.83 ns |      14.80 ns |  3.33 |    0.03 |   0.0896 |      - |     424 B |        1.00 |
| MergeSortTest   | 100  |      2,579.1 ns |      17.07 ns |      15.97 ns |  4.84 |    0.03 |   1.7891 |      - |    8424 B |       19.87 |
|                 |      |                 |               |               |       |         |          |        |           |             |
| DotNetArraySort | 1000 |     16,043.2 ns |      94.27 ns |      83.57 ns |  1.00 |    0.01 |   0.8240 |      - |    4024 B |        1.00 |
| BubbleSort      | 1000 |    617,284.2 ns |   5,248.30 ns |   4,909.26 ns | 38.48 |    0.35 |        - |      - |    4024 B |        1.00 |
| InsertionSort   | 1000 |    132,923.4 ns |     399.30 ns |     373.50 ns |  8.29 |    0.05 |   0.7324 |      - |    4024 B |        1.00 |
| MergeSortTest   | 1000 |     52,056.9 ns |     156.84 ns |     122.45 ns |  3.24 |    0.02 |  20.4468 | 0.2441 |   96328 B |       23.94 |
|                 |      |                 |               |               |       |         |          |        |           |             |
| DotNetArraySort | 5000 |    186,586.8 ns |     728.84 ns |     569.03 ns |  1.00 |    0.00 |   4.1504 |      - |   20024 B |        1.00 |
| BubbleSort      | 5000 | 18,559,682.5 ns | 173,313.87 ns | 162,117.90 ns | 99.47 |    0.89 |        - |      - |   20024 B |        1.00 |
| InsertionSort   | 5000 |  3,245,621.7 ns |  18,336.49 ns |  16,254.82 ns | 17.39 |    0.10 |   3.9063 |      - |   20024 B |        1.00 |
| MergeSortTest   | 5000 |    337,812.9 ns |   4,071.03 ns |   3,808.04 ns |  1.81 |    0.02 | 113.7695 | 0.9766 |  536008 B |       26.77 |



# 🏁 Wielki Wyścig Algorytmów Sortowania

Ten projekt to poligon doświadczalny, na którym sprawdzamy, jak w praktyce radzą sobie różne sposoby na układanie liczb w kolejności rosnącej. 

Sprawdzamy tu, czy warto wymyślać koło na nowo, czy lepiej po prostu zaufać temu, co twórcy języka C# dali nam w prezencie.

## 🥷 Nasi zawodnicy

Do wyścigu stanęły cztery algorytmy. Każdy z nich dostał to samo zadanie: posortować totalnie wymieszane tablice o wielkości 100, 1000 i 5000 elementów.

1. **Array.Sort (Wbudowany w C#)** – Prawdziwy szef. Hybrydowy potwór zoptymalizowany przez inżynierów Microsoftu. Nasz punkt odniesienia.
2. **Bubble Sort (Bąbelek)** – Najprostszy z możliwych. Chodzi po tablicy w kółko i zamienia miejscami sąsiadów. Łatwy do napisania, ale czy szybki? Zobaczymy.
3. **Insertion Sort (Przez wstawianie)** – Działa dokładnie tak, jak układanie kart w dłoni podczas gry. 
4. **Merge Sort (Przez scalanie)** – Zaawansowana taktyka "dziel i rządź". Tnie tablicę na malutkie kawałki, a potem sprytnie skleja je w posortowaną całość.

---

## 📊 Wyniki na żywo (Zmierzone przez BenchmarkDotNet)

Oto twarde dane z naszego testu. Zwróć uwagę na kolumnę **Ratio** (mówi, ile razy dany algorytm był wolniejszy od wbudowanego `Array.Sort`) oraz **Allocated** (ile pamięci RAM "zjadł" po drodze).

| Zawodnik | Ile liczb (N) | Czas (Mean) | O ile wolniej? (Ratio) | Zużyty RAM (Allocated) |
| :--- | :---: | ---: | :---: | ---: |
| **Array.Sort (C#)** | 100 | 532 ns | 1.00x | 424 B |
| **Insertion Sort** | 100 | 1,775 ns | 3.33x | 424 B |
| **Merge Sort** | 100 | 2,579 ns | 4.84x | 8,424 B |
| **Bubble Sort** | 100 | 4,673 ns | 8.77x | 424 B |
| | | | | |
| **Array.Sort (C#)** | 1000 | 16,043 ns | 1.00x | 4,024 B |
| **Merge Sort** | 1000 | 52,056 ns | 3.24x | 96,328 B |
| **Insertion Sort** | 1000 | 132,923 ns | 8.29x | 4,024 B |
| **Bubble Sort** | 1000 | 617,284 ns | 38.48x | 4,024 B |
| | | | | |
| **Array.Sort (C#)** | 5000 | 186,586 ns | 1.00x | 20,024 B |
| **Merge Sort** | 5000 | 337,812 ns | 1.81x | 536,008 B |
| **Insertion Sort** | 5000 | 3,245,621 ns | 17.39x | 20,024 B |
| **Bubble Sort** | 5000 | 18,559,682 ns | **99.47x** | 20,024 B |

*(Dla ułatwienia: 1 milisekunda to 1 000 000 ns)*

---

## 💡 Czego mnie to nauczyło? (Wnioski po ludzku)

Z tych na pozór nudnych liczb można wyciągnąć kilka super ciekawych wniosków:

1. **Bąbelek dostaje zadyszki.** Dla 100 elementów był znośny. Ale gdy daliśmy mu 5000 liczb, zwariował. Był prawie **100 razy wolniejszy** od wbudowanej metody! To idealny dowód na to, dlaczego algorytmy o złożoności O(N²) rzadko sprawdzają się w prawdziwym życiu dla dużych danych.
2. **Paradoks małych danych.** Zauważyłeś, że dla 100 elementów proste układanie kart (Insertion Sort) pobiło wielkiego i mądrego Merge Sorta? Zbyt skomplikowane algorytmy mają duży "narzut organizacyjny". Czasami najprostsze rozwiązanie jest najlepsze (ale tylko dla małych tablic!).
3. **Szybkość to nie wszystko (problem Merge Sorta).** Merge sort dla 5000 elementów był całkiem szybki (tylko 1.8x wolniejszy niż wbudowany), ale... spójrzcie na RAM! Zużył ponad pół megabajta pamięci (536 KB), podczas gdy reszta zmieściła się w 20 KB. Dlaczego? Bo Merge Sort ciągle musi tworzyć nowe, tymczasowe tablice w pamięci, żeby przekładać dane. Coś za coś!
4. **Morał z bajki:** Jeśli piszesz prawdziwą aplikację – po prostu użyj `Array.Sort()`. Wymiatacze z Microsoftu odwalili już za nas całą brudną robotę. 😉
