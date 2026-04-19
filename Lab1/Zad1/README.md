Twoim zadaniem jest policzenie liczby unikalnych trójkątów prostokątnych o długościach boków a, b, c, które są dodatnimi liczbami całkowitymi i spełniają warunek N ≤ a, b, c ≤ M dla zadanych liczb N i M (1 ≤ N < M ≤ 10⁵).

Napisz program, który odczyta ze standardowego wejście dwie liczby N oraz M oddzielone pojedynczą spacją i wypisze na standardowe wyjście liczbę unikalnych trójkątów prostokątnych o bokach a, b, c w zakresie od N do M.

Uwaga: Trójkąty są unikalne, jeśli różnią się długościami boków, a nie kolejnością ich podania. Oznacza to, że trójkąt o bokach (3, 4, 5) jest taki sam jak (4, 3, 5) i nie liczymy ich jako różnych.


## Zrobiłem swój Benchmark
```text
BenchmarkDotNet v0.15.8, Windows 11 (10.0.26200.7462/25H2/2025Update/HudsonValley2)
Intel Core i5-9600K CPU 3.70GHz (Coffee Lake), 1 CPU, 6 logical and 6 physical cores
.NET SDK 9.0.307
  [Host]     : .NET 9.0.11 (9.0.11, 9.0.1125.51716), X64 RyuJIT x86-64-v3
  DefaultJob : .NET 9.0.11 (9.0.11, 9.0.1125.51716), X64 RyuJIT x86-64-v3
```
Przy 100 próbkach:

| Method          | Mean             | Error           | StdDev          | Allocated |
|---------------- |-----------------:|----------------:|----------------:|----------:|
| Silowe    O(N3) |   3,208,585.2 ns |    54,130.93 ns |    50,634.10 ns |         - |
| Optymalne O(N2) |      15,674.8 ns |       273.19 ns |       255.54 ns |         - |
| Fassttt pureMath|         195.3 ns |         3.04 ns |         2.84 ns |         - |


Przy 500 próbkach:

| Method          | Mean             | Error           | StdDev          | Allocated |
|---------------- |-----------------:|----------------:|----------------:|----------:|
| Silowe    O(N3) | 383,085,906.7 ns | 5,995,003.49 ns | 5,607,729.98 ns |         - |
| Optymalne O(N2) |     374,418.8 ns |     4,824.90 ns |     4,513.22 ns |         - |
| Fassttt pureMath|       1,196.2 ns |        15.72 ns |        14.71 ns |         - |
