using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BoiledProblems;
using Boilerplate;

namespace BoiledDebugger
{
    class Program
    {
        static void Main(string[] args)
        {
            long n = 33333332;

            //var factors = BoilSequences.PrimeFactorizationWheelFactorization(n);

            //for (int i = 0; i < factors.Count; i++)
            //{
            //    Console.Write("{0} ", factors[i]);
            //}

            Console.WriteLine("HB: {0}ms", Benchmark(() =>
            {
                for (int i = 0; i < n; i++)
                {
                    BoilMathFunctions.IsPrimeHybrid(i);
                }
            }, 1, false));
            
            Console.ReadLine();
        }

        static double Benchmark(Action action, int iterations = 1, bool warmup = false)
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();

            if (warmup)
            {
                action();
            }

            var startTime = DateTime.UtcNow;
            for (int i = 0; i < iterations; i++)
            {
                action();
            }
            var endTime = DateTime.UtcNow;

            var totalTime = endTime - startTime;

            return Math.Round(totalTime.TotalMilliseconds / iterations);
        }
    }
}
