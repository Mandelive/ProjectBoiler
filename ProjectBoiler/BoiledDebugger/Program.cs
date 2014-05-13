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
            long n = 4000000000L;
            Console.WriteLine("HB: {0}ms", Benchmark(() =>
            {
                Parallel.For(3000000000L, n, i =>
                {
                    BoilMathFunctions.IsPrimeHybrid(i);
                });
            }, 1));
            //Console.WriteLine("WF: {0}ms", Benchmark(() =>
            //{
            //    Parallel.For(30000000, n, i =>
            //    {
            //        BoilMathFunctions.IsPrimeWheelFact(i);
            //    });
            //}, 1));
            
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

            return Math.Round(totalTime.TotalMilliseconds / iterations);
        }
    }
}
