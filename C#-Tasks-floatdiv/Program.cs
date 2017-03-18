using System;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ParallelTest
{
    public class Program
    {
        private static bool isPrime(int j)
        {
            int sqj = (int)Math.Sqrt(j);

            for (int i = 2; i <= sqj; i++)
            {
                // if (j % i == 0)
                if (j - i*(int)((float)j/i) == 0) // faster on ARM Cortex without hw int div
                {
                    return false;
                }
            }

            return true;
        }

        public static int FindPrimesTasks(int maxnum)
        {

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

            return numberOfPrimes;
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
