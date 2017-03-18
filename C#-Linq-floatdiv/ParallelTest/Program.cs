using System;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ParallelTest
{
    public class Program
    {
        public static int FindPrimesLinq(int maxnum)
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
                        // if ((int)v % i == 0)
                        if ((int)v - i*(int)((float)v/i) == 0) // faster on ARM Cortex without hw int div
                        {
                            return false;
                        }
                    }

                    return true;
                })
                .Count();

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
            FindPrimesLinq(maxnum);
        }
    }
}
