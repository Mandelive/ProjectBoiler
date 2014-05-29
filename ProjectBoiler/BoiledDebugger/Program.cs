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
            int r = 0;
            int n = 100000;
            
            BoilMathFunctions.FactorialCustom8(100);
            Console.WriteLine("Factorial8: {0}ms", Benchmark(() =>
            {
                BoilMathFunctions.FactorialCustom8(n);
                //for (int i = r; i <= n; i++)
                //{
                //    if (BoilMathFunctions.FactorialSolverFoundation(i) != BoilMathFunctions.FactorialCustom11(i))
                //    {
                //        Console.WriteLine("{0}!: {1}", i, BoilMathFunctions.FactorialSolverFoundation(i));
                //        Console.WriteLine("{0}!: {1}", i, BoilMathFunctions.FactorialCustom11(i));
                //    }
                //}
            }, 1, false));

            
            Console.WriteLine("Factorial11: {0}ms", Benchmark(() =>
            {
                BoilMathFunctions.FactorialCustom11(n);
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
