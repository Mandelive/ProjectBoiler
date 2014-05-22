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
            int n = 100000;

            Console.WriteLine("Factorial: {0}ms", Benchmark(() =>
            {
                //BoilMathFunctions.FactorialSplitRecursive(n);
                BoilMathFunctions.FactorialCustom3(n);
                //for (int i = n; i <= n; i++)
                //{
                //    BoilMathFunctions.FactorialCustom3(i);
                //}
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
