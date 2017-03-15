using System;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ParallelTest
{
    class Program
    {
        private static void FindPrimes(int maxnum)
        {
            Console.WriteLine($"Prímszámok keresése Parallel.For-ral {maxnum}-ig...");

            var sw = Stopwatch.StartNew();

            int numberOfPrimes = 0;

            Parallel.For(2, maxnum, n => {
                int sqi = (int)Math.Sqrt(n);

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

        private static void FindPrimesTasks(int maxnum)
        {
            bool isPrime(int j)
            {
                int sqj = (int)Math.Sqrt(j);

                for (int i = 2; i <= sqj; i++)
                {
                    if (j % i == 0)
                    {
                        return false;
                    }
                }

                return true;
            }

            int num = 1;
            int numberOfPrimes = 0;

            Console.WriteLine($"Prímszámok keresése taszkokkal {maxnum}-ig...");

            var sw = Stopwatch.StartNew();

            Task[] tasks = new Task[Environment.ProcessorCount];

            for (int n = 0; n < Environment.ProcessorCount; n++)
            {
                tasks[n] = new Task(() =>
                {
                    var j = Interlocked.Increment(ref num);

                    while (j <= maxnum)
                    {
                        if (isPrime(j))
                            Interlocked.Increment(ref numberOfPrimes);

                        j = Interlocked.Increment(ref num);
                    }
                }, TaskCreationOptions.LongRunning);

                tasks[n].Start();
            }

            Task.WaitAll(tasks);

            Console.WriteLine($"{numberOfPrimes} darabot találtam {sw.ElapsedMilliseconds} ms alatt.");
        }

        private static void FindPrimesLinq(int maxnum)
        {
            Console.WriteLine($"Prímszámok keresése LINQ-val {maxnum}-ig...");

            var sw = Stopwatch.StartNew();

            int numberOfPrimes = Enumerable.Range(2, maxnum)
                .AsParallel()
                .Where(v =>
                {
                    int sqi = (int)Math.Sqrt((int)v);

                    //                if ((n & 1) == 0)     -- don't optimize the searching ...
                    //                    return;           -- we want measure the speed of all iteration

                    for (int i = 2; i <= sqi; i++)
                    {
                        if ((int)v % i == 0)
                        {
                            return false;
                        }
                    }

                    return true;
                })
                .Count();

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

            for (int i = 0; i < 5; i++)
                FindPrimes(maxnum);

            for (int i = 0; i < 5; i++)
                FindPrimesTasks(maxnum);

            for (int i = 0; i < 5; i++)
                FindPrimesLinq(maxnum);
        }
    }
}