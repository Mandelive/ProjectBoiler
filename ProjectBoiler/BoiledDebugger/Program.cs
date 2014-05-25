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
            int n = 50 + 34;

            Console.WriteLine("Factorial3: {0}ms", Benchmark(() =>
            {
                //BoilMathFunctions.FactorialSplitRecursive(n);
                //BoilMathFunctions.FactorialCustom3(n);
                //BoilMathFunctions.FactorialCustom5(n);
                //BoilMathFunctions.FactorialCustom8(n);
                for (int i = n - 50; i <= n; i++)
                {
                    Console.WriteLine("{0}!: {1}", i, BoilMathFunctions.FactorialCustom8(i));
                    Console.WriteLine("{0}!: {1}", i, BoilMathFunctions.FactorialCustom9(i));
                }
            }, 1, false));

            Console.WriteLine("Factorial8: {0}ms", Benchmark(() =>
            {
                //BoilMathFunctions.FactorialSplitRecursive(n);
                //BoilMathFunctions.FactorialCustom3(n);
                //BoilMathFunctions.FactorialCustom5(n);
                //BoilMathFunctions.FactorialCustom8(n);
                //BoilMathFunctions.DoubleFactorialBigInteger(n);
                //for (int i = n - 50; i <= n; i++)
                //{
                //    Console.WriteLine("{0}!: {1}", i, BoilMathFunctions.FactorialCustom8(i) == BoilMathFunctions.FactorialCustom3(i));
                //}
            }, 1, true));

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
