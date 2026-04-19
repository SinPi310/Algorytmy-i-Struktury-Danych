using BenchmarkDotNet.Attributes;

[MemoryDiagnoser]
public class MyBenchmarks
{
    // Parametry wejściowe do testów (zmieniane automatycznie przez BenchmarkDotNet)
    [Params(100, 1_000, 5_000)]
    public int N { get; set; }

    [Params(100, 1_000, 5_000)]
    public int M { get; set; }

    [GlobalSetup]
    public void Setup()
    {
        // Możesz przygotować dane tu, jeśli potrzebujesz.
    }

    // ---- wariant 1: proste sprawdzanie wszystkich par (bruteforce) ----
    [Benchmark(Baseline = true)]
    public int BruteForce()
    {
        int counter = 0;

        for (int a = N; a <= M; a++)
        {
            for (int b = a; b <= M; b++)
            {
                long cSq = (long)a * a + (long)b * b;
                long c = (long)Math.Sqrt(cSq);

                if (c * c == cSq && c <= M)
                {
                    counter++;
                }
            }
        }

        return counter;
    }

    // ---- wariant 2: generowanie trójek pitagorejskich wzorem Euklidesa ----
    [Benchmark]
    public int EuclidFormula()
    {
        int counter = 0;

        int limitM = (int)Math.Sqrt(M);

        for (int m = 2; m <= limitM; m++)
        {
            for (int n = 1; n < m; n++)
            {
                if ((m - n) % 2 == 1 && Gcd(m, n) == 1)
                {
                    long aPrim = (long)m * m - (long)n * n;
                    long bPrim = 2L * m * n;
                    long cPrim = (long)m * m + (long)n * n;

                    long aBase = Math.Min(aPrim, bPrim);

                    int k = 1;
                    while (k * cPrim <= M)
                    {
                        if (k * aBase >= N)
                        {
                            counter++;
                        }
                        k++;
                    }
                }
            }
        }

        return counter;
    }

    [GlobalCleanup]
    public void Cleanup()
    {
        // Czyszczenie (nie jest konieczne w tym przykładzie)
    }

    private static int Gcd(int a, int b)
    {
        while (b != 0)
        {
            int temp = b;
            b = a % b;
            a = temp;
        }
        return a;
    }
}