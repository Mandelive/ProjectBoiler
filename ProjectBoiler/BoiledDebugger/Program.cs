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
            int n = 50000;
            BoilMathFunctions.FactorialCustom5(100);
            BoilMathFunctions.FactorialCustom8(100);
            Console.WriteLine("Factorial5: {0}ms", Benchmark(() =>
            {
                //BoilMathFunctions.FactorialSplitRecursive(n);
                //BoilMathFunctions.FactorialCustom3(n);
                //BoilMathFunctions.FactorialCustom5(n);
                BoilMathFunctions.FactorialCustom8(n);
                //BoilMathFunctions.FactorialCustom9(n);
                //BoilMathFunctions.FactorialCustom10(n);
                //for (int i = n - 5; i <= n; i++)
                //{
                //    if (BoilMathFunctions.FactorialCustom5(i) != BoilMathFunctions.FactorialCustom10(i))
                //    {
                //        Console.WriteLine("{0}!: {1}", i, BoilMathFunctions.FactorialCustom5(i));
                //        Console.WriteLine("{0}!: {1}", i, BoilMathFunctions.FactorialCustom10(i));
                //    }
                //}
            }, 1, false));
            BoilMathFunctions.FactorialCustom10(100);
            Console.WriteLine("Factorial9: {0}ms", Benchmark(() =>
            {
                //BoilMathFunctions.FactorialSplitRecursive(n);
                //BoilMathFunctions.FactorialCustom3(n);
                //BoilMathFunctions.FactorialCustom5(n);
                //BoilMathFunctions.FactorialCustom8(n);
                //BoilMathFunctions.FactorialCustom9(n);
                //BoilMathFunctions.FactorialCustom9(n);
                BoilMathFunctions.FactorialCustom10(n);
                //BoilMathFunctions.DoubleFactorialBigInteger(n);
                //for (int i = n - 50; i <= n; i++)
                //{
                //    Console.WriteLine("{0}!: {1}", i, BoilMathFunctions.FactorialCustom8(i) == BoilMathFunctions.FactorialCustom3(i));
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
