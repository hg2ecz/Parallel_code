using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace ParallelTest
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length < 1)
            {
                Console.WriteLine($"Használat ParallelTest.exe <maxnum>");
                return;
            }

            int maxnum = Int32.Parse(args[0]);

            Console.WriteLine($"Prímszámok keresése {maxnum}-ig...");

            var sw = Stopwatch.StartNew();

            int numberOfPrimes = 0;

            Parallel.For(3, maxnum, n => {
                int sqi = (int) Math.Sqrt(n);

                if ((n & 1) == 0)
                    return;

                for (int i = 3; i <= sqi; i += 2)
                {
                    if (n % i == 0)
                    {
                        return;
                    }
                }

                Interlocked.Increment(ref numberOfPrimes);
            });

            Console.WriteLine($"{numberOfPrimes} darabot találtam {sw.ElapsedMilliseconds} ms alatt.");
        }
    }
}