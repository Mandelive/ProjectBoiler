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

            long upperlimit = 1000000;
            long range = 1000;

            TestSuite.BenchmarkAction(() =>
            {
                var ggList = new HashSet<long>(BoilSequences.PrimesSequenceUpTo(upperlimit));
                for (long i = 0; i < range; i++)
                {
                    ggList.Contains(i);
                }
            }, true, 1, "PrimesSequenceUpToList", 1);


            


            //Console.WriteLine();

            //perms = BoilExperimental.GeneratePermutationsQuick(numstr);

            //foreach (var p in perms)
            //{
            //    Console.WriteLine(p);
            //}


            //var primesEnum = BoilSequences.PrimeAdhocGenerator().GetEnumerator();

            //for (int i = 0; i < 1000; i++)
            //{
            //    primesEnum.MoveNext();
            //    if (primesEnum.Current < 0)
            //    {
            //        Console.Write("{0}, ", -primesEnum.Current);
            //    }
            //}

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

            //TestSuite.AssertEqualFor(BoilSequences.PrimeAdhocGenerator, BoilExperimental.PrimeAdhocGenerator2, TestSuite.Range(0, 2000000), 2);

            //var lowerlimit = 0;
            //var upperlimit = 31000000;
            //var reps = 5;

            //TestSuite.BenchmarkAction(() =>
            //{
            //    for (int r = 0; r < reps; r++)
            //    {
            //        for (var i = lowerlimit; i < 2; i++)
            //        {
            //            var gg = BoilSequences.PrimesSequenceUpTo(upperlimit);
            //        }
            //    }
            //}, true, 3, "PrimesSequenceUpTo", 1);

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

            //Console.ReadLine();
        }

    }
}
