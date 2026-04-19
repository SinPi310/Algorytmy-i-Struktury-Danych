using BenchmarkDotNet.Attributes;
    
[MemoryDiagnoser]
public class PythagoreanBenchmarks
{
    // Nasz stały początek zakresu
    public int N = 1;

    // BenchmarkDotNet odpali testy dwukrotnie: raz dla M=100, potem dla M=500
    [Params(100, 500)] 
    public int M;

    [Benchmark]
    public int Silowe()
    {
        int counter = 0;

        for (int a = N; a <= M; a++)
        {
            for (int b = a; b <= M; b++)
            {
                for (int c = b; c <= M; c++)
                {
                    if (Math.Pow(a, 2) + Math.Pow(b, 2) == Math.Pow(c, 2))
                    {
                        counter++;
                    }
                }
            }
        }
        return counter;
    }


    [Benchmark]
    public int Optymalne()
    {
        int counter = 0;

        for (int a = N; a <=M; a++)
        {
            for (int b = a; b <= M; b++)
            {
                long c_square = (long)a * a + (long)b * b;
                long c = (long)Math.Sqrt(c_square);

                if (c * c == c_square && c <= M)
                {
                    counter++;
                }
            }
        }
        return counter;
    }


    [Benchmark]
    public int Fassttt()
    {
        int counter = 0;
        int limitM = (int)Math.Sqrt(M);

        for (int m = 2; m <= limitM; m++)
        {
            for (int n = 1; n < m; n++)
            {
                if ((m - n) % 2 == 1 && Gcd(m, n) == 1)
                {
                    long a_prim = (long)m * m - (long)n * n;
                    long b_prim = 2L * m * n;
                    long c_prim = (long)m * m + (long)n * n;

                    long a_base = Math.Min(a_prim, b_prim);
                    
                    int k = 1;
                    while (k * c_prim <= M)
                    {
                        if (k * a_base >= N)
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

    private int Gcd(int a, int b)
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