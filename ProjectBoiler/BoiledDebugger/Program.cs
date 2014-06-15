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

            long r = 0;
            long n = 5000000;

            AssertEqualFor<int>(BoilMathFunctions.MaxExponent, BoilMathFunctions.MaxExponent, r, n, 2);
            BenchmarkAgainst<int>(BoilMathFunctions.MaxExponent, BoilMathFunctions.MaxExponent, r, n, 2, 1);
            
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

        static bool AssertEqualFor<T>(Func<long, T> f1, Func<long, T> f2, long s, long e, int verbosity = 0)
        {
            bool isTrue = true;
            for (long i = s; i <= e; i++)
            {
                var a = (IComparable)f1(i);
                var b = (IComparable)f2(i);
                if (a.CompareTo(b) != 0)
                {
                    isTrue = false;
                    if (verbosity > 1)
                    {
                        Console.WriteLine("{0}: {1}", f1.Method.Name + "(" + i.ToString() + ")", a);
                        Console.WriteLine("{0}: {1}", f2.Method.Name + "(" + i.ToString() + ")", b);
                        Console.WriteLine();
                    }
                    else
                    {
                        break;
                    }
                }
            }
            if (verbosity > 0)
            {
                if (isTrue)
                {
                    Console.WriteLine("{0} == {1} for all inputs from {2} to {3}", f1.Method.Name, f2.Method.Name, s, e);
                }
                else
                {
                    Console.WriteLine("{0} != {1} for some inputs from {2} to {3}", f1.Method.Name, f2.Method.Name, s, e);
                }
            }
            return isTrue;
        }

        static bool AssertEqualFor<T>(Func<int, T> f1, Func<int, T> f2, int s, int e, int verbosity = 0)
        {
            bool isTrue = true;
            for (int i = s; i <= e; i++)
            {
                var a = (IComparable)f1(i);
                var b = (IComparable)f2(i);
                if (a.CompareTo(b) != 0)
                {
                    isTrue = false;
                    if (verbosity > 1)
                    {
                        Console.WriteLine("{0}: {1}", f1.Method.Name + "(" + i.ToString() + ")", a);
                        Console.WriteLine("{0}: {1}", f2.Method.Name + "(" + i.ToString() + ")", b);
                        Console.WriteLine();
                    }
                    else
                    {
                        break;
                    }
                }
            }
            if (verbosity > 0)
            {
                if (isTrue)
                {
                    Console.WriteLine("{0} == {1} for all inputs from {2} to {3}", f1.Method.Name, f2.Method.Name, s, e);
                }
                else
                {
                    Console.WriteLine("{0} != {1} for some inputs from {2} to {3}", f1.Method.Name, f2.Method.Name, s, e);
                }
            }
            return isTrue;
        }

        static double BenchmarkAgainst<T>(Func<long, T> f1, Func<long, T> f2, long s, long e, int verbosity = 0, long warmup = Int64.MinValue)
        {
            double timeDiff = 0.0;

            if (warmup > Int64.MinValue)
            {
                f1(warmup);
                f2(warmup);
            }

            var a = Benchmark(() =>
            {
                for (long i = s; i <= e; i++)
                {
                    f1(i);
                }
            }, 1, false);

            if (verbosity > 0)
            {
                Console.WriteLine("{0} took {1}ms", f1.Method.Name, a);
            }

            var b = Benchmark(() =>
            {
                for (long i = s; i <= e; i++)
                {
                    f2(i);
                }
            }, 1, false);

            if (verbosity > 0)
            {
                Console.WriteLine("{0} took {1}ms", f2.Method.Name, b);
            }

            timeDiff = a - b;

            return timeDiff;
        }
    }
}
