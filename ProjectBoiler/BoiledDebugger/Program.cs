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
            var n = 1000000L;
            Console.WriteLine("WF: {0}ms", Benchmark(() =>
            {
                for (int i = 0; i < n; i++)
                {
                    BoilMathFunctions.IsPrimeWheelFact(i);
                }
            }, 100));
            Console.WriteLine("HB: {0}ms", Benchmark(() =>
            {
                for (int i = 0; i < n; i++)
                {
                    BoilMathFunctions.IsPrimeHybrid(i);
                }
            }, 100));
            Console.ReadLine();
        }

        static double Benchmark(Action action, int iterations = 1)
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();

            var startTime = DateTime.UtcNow;
            for (int i = 0; i < iterations; i++)
            {
                action();
            }
            var endTime = DateTime.UtcNow;

            var totalTime = endTime - startTime;

            return Math.Round(totalTime.TotalMilliseconds);
        }
    }
}
