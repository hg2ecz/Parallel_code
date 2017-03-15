using System;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ParallelTest
{
    class Program
    {
        private static void FindPrimesTasks(int maxnum)
        {
            Console.WriteLine($"Prímszámok keresése taszkokkal {maxnum}-ig...");

            var sw = Stopwatch.StartNew();

            int numberOfPrimes = 0;

            for (int n = 2; n < maxnum; n++)
            {
                Task.Factory.StartNew(v =>
                {
                    int sqi = (int)Math.Sqrt((int)v);

                    //                if ((n & 1) == 0)     -- don't optimize the searching ...
                    //                    return;           -- we want measure the speed of all iteration

                    for (int i = 2; i <= sqi; i++)
                    {
                        if ((int)v % i == 0)
                        {
                            return;
                        }
                    }

                    Interlocked.Increment(ref numberOfPrimes);
                }, n);
            }

            Console.WriteLine($"{numberOfPrimes} darabot találtam {sw.ElapsedMilliseconds} ms alatt.");
        }


        static void Main(string[] args)
        {
            if (args.Length < 1)
            {
                Console.WriteLine($"Használat ParallelTest.exe <maxnum>");
                return;
            }

            int maxnum = Int32.Parse(args[0]);
            FindPrimesTasks(maxnum);
        }
    }
}
