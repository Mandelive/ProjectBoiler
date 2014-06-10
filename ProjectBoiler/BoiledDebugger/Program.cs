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

            var r = 0;
            var n = 3000000;

            BoilMathFunctions.MaxExponent3(100);
            Console.WriteLine("MaxExponent: {0}ms", Benchmark(() =>
            {
                //BoilMathFunctions.MaxExponent3(n);
                for (var i = r; i <= n; i++)
                {
                    var a = BoilMathFunctions.MaxExponent3(i);
                    //var b = BoilMathFunctions.MaxExponent2(i);
                    //if (a != b)
                    //{
                    //    Console.WriteLine("{0}: {1}", i, a);
                    //    Console.WriteLine("{0}: {1}", i, b);
                    //}
                }
            }, 1, false));

            //BoilMathFunctions.FactorialCustom13(100);
            //Console.WriteLine("FactorialCustom13: {0}ms", Benchmark(() =>
            //{
            //    BoilMathFunctions.FactorialCustom13(n);
            //}, 1, false));

            //BoilMathFunctions.LeastPrimeFactor(100);
            //BoilSequences.PrimeFactorizationWF(100);
            //Console.WriteLine("LeastPrimeFactor: {0}ms", Benchmark(() =>
            //{
            //    for (var i = r; i <= n; i++)
            //    {
            //        BoilMathFunctions.LeastPrimeFactor(i);
            //        //var a = BoilMathFunctions.LeastPrimeFactor(i);
            //        //var b = BoilSequences.PrimeFactorizationWF(i).First();
            //        //if (a != b)
            //        //{
            //        //    Console.WriteLine("{0}: {1}, {2}", i, a, b);
            //        //}
            //    }
            //}, 1, false));

            //BoilSequences.PrimeFactorizationWF(100);
            //Console.WriteLine("PrimeFactorizationWF: {0}ms", Benchmark(() =>
            //{
            //    for (var i = r; i <= n; i++)
            //    {
            //        BoilSequences.PrimeFactorizationWF(i).First();
            //    }
            //}, 1, false));
            
            //TestBigInteger();
            
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

        static void TestBigInteger()
        {
            var iterations = 1000000;

            var tinyNumber = new BigInteger(7);
            var smallNumber = new BigInteger(Byte.MaxValue);
            var mediumNumber = new BigInteger(Int16.MaxValue);
            var blargeNumber = new BigInteger(Int32.MaxValue / 2);
            var largeNumber = new BigInteger(Int32.MaxValue);
            var xlargeNumber = new BigInteger(UInt32.MaxValue);
            var hugeNumber = new BigInteger(Int64.MaxValue);
            var xhugeNumber = new BigInteger(UInt64.MaxValue);

            int zeroInt = 0;
            long zeroLong = 0;
            BigInteger zeroBigInteger = 0;
            int oneInt = 1;
            long oneLong = 1;
            BigInteger oneBigInteger = 1;
            int twoInt = 2;
            long twoLong = 2;
            BigInteger twoBigInteger = new BigInteger(2);
            int threeInt = 3;
            long threeLong = 3;
            BigInteger threeBigInteger = new BigInteger(3);
            int sevenInt = 7;
            long sevenLong = 7;
            BigInteger sevenBigInteger = new BigInteger(7);
            int maxInt = Int32.MaxValue;
            long maxLong = Int64.MaxValue;
            BigInteger maxULong = UInt64.MaxValue;

            var buf1 = BigInteger.One;
            Console.WriteLine("Multiply Tiny by 2: {0}ms", Benchmark(() =>
            {
                for (int i = 0; i < iterations; i++)
                {
                    buf1 = mediumNumber * mediumNumber;
                }
            }, 1, false));
        }
    }
}
