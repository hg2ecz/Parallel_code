using System;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ParallelTest
{
    public class Program
    {
        private static int FindPrimesNoparallel(int maxnum)
        {
            int numberOfPrimes = 0;

            for (int j = maxnum; j >= 2; j--)
            {
                bool prime = true;
                int sqj = (int)Math.Sqrt(j);

                for (int i = 2; i <= sqj; i++)
                {
                    // if (j % i == 0)
                    if (j - i*(int)((float)j/i) == 0) // faster on ARM Cortex without hw int div
                    {
                        prime = false;
                        break;
                    }
                }
                if (prime) numberOfPrimes++;
            }
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
            Console.WriteLine($"Prímszámok keresése egyetlen szálon {maxnum}-ig...");
            var sw = Stopwatch.StartNew();
            int numberOfPrimes = FindPrimesNoparallel(maxnum);
            Console.WriteLine($"{numberOfPrimes} darabot találtam {sw.ElapsedMilliseconds} ms alatt.");
        }
    }
}
