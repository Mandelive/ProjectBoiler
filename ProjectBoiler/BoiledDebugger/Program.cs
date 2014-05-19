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
            long n = 100000;

            //Console.WriteLine("FactorialCustom2: {0}ms", Benchmark(() =>
            //{
            //    for (long i = n - 30; i <= n; i++)
            //    {
            //        Console.WriteLine("{0}!: {1}", i, BoilMathFunctions.FactorialCustom3(i) == BoilMathFunctions.FactorialCustom4(i));
            //    }
            //}, 1, false));

            Console.WriteLine("FactorialCustom3: {0}ms", Benchmark(() =>
            {
                for (long i = n; i <= n; i++)
                {
                    BoilMathFunctions.FactorialCustom3(i);
                }
            }, 1, false));

            Console.WriteLine("FactorialCustom4: {0}ms", Benchmark(() =>
            {
                for (long i = n; i <= n; i++)
                {
                    BoilMathFunctions.FactorialCustom4(i);
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
