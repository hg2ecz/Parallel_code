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

            Parallel.For(2, maxnum, n => {
                int sqi = (int) Math.Sqrt(n);

//                if ((n & 1) == 0)     -- don't optimize the searching ...
//                    return;           -- we want measure the speed of all iteration

                for (int i = 2; i <= sqi; i++)
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