using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BoiledProblems;
using Boilerplate;
using System.Diagnostics;
using System.Numerics;

namespace BoiledDebugger
{
    class Program
    {
        static void Main(string[] args)
        {
            Process.GetCurrentProcess().PriorityClass = ProcessPriorityClass.High;

            
            
            //BigInteger b0 = 0;
            //BigInteger b1 = 10000;
            //int e0 = 0;
            //int e1 = 100;
            //Parallel.For(0, Int32.MaxValue - 1, i =>
            ////for (long i = 0; i <= Int32.MaxValue; i++)
            //{
            //    for (int j = 0; j <= BoilMathFunctions.MaxExponent(i); i++)
            //    {
            //        var a = BoilMathFunctions.ExpLinear(i, j);
            //        var b = BoilMathFunctions.ExpDouble(i, j);
            //        if (a != b)
            //        {
            //            Console.WriteLine("{0}, {1}: {2} != {3}", i, j, a, b);
            //        }
            //    }
            //});
            //TestSuite.AssertEqualFor(BoilMathFunctions., BoilMathFunctions.ExpDouble, TestSuite.Range(-1448L, 1448L), TestSuite.Range(0, 4), 2);
            

            //TestSuite.BenchmarkAction(() =>
            //{
            //    for (BigInteger i = b0; i <= b1; i++)
            //    {
            //        for (int j = e0; j <= e1; j++)
            //        {
            //            BoilMathFunctions.ExpLinear(i, j);
            //        }
            //    }
            //}, false, 1, "ExpLinear", 1);

            //TestSuite.BenchmarkAction(() =>
            //{
            //    for (BigInteger i = b0; i <= b1; i++)
            //    {
            //        for (int j = e0; j <= e1; j++)
            //        {
            //            BoilMathFunctions.ExpBinary(i, j);
            //        }
            //    }
            //}, false, 1, "ExpBinary", 1);

            //TestSuite.BenchmarkAction(() =>
            //{
            //    for (BigInteger i = b0; i <= b1; i++)
            //    {
            //        for (int j = e0; j <= e1; j++)
            //        {
            //            BigInteger.Pow(i, j);
            //        }
            //    }
            //}, false, 1, "BigInteger.Pow", 1);

            //long n0 = 0L;
            //long n1 = 300000000L;
            //TestSuite.AssertEqualFor(BoilMathFunctions.MaxExponent2, BoilMathFunctions.MaxExponent3 TestSuite.Range(n0, n1), 2);
            //TestSuite.BenchmarkRange(BoilMathFunctions.MaxExponent2, n0, n1, n0, 1, 1);
            //TestSuite.BenchmarkRange(BoilMathFunctions.MaxExponent, n0, n1, n0, 1, 1);
            
            Console.ReadLine();
        }

    }
}
