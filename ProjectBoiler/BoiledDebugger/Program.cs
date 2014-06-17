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

            long s = 0;
            long e = 52;
            int b0 = -15;
            int b1 = 15;

            AssertEqualFor(BoilMathFunctions.ExpLinear, BoilMathFunctions.ExpBinary, Range(s, e), Range(b0, b1), 2);
            BenchmarkRange(BoilMathFunctions.MaxExponent, s, e, 1, 2L);
            
            Console.ReadLine();
        }

        static IEnumerable<int> Range(int start, int end)
        {
            for (var i = start; i <= end; i++)
            {
                yield return i;
            }
        }

        static IEnumerable<long> Range(long start, long end)
        {
            for (var i = start; i <= end; i++)
            {
                yield return i;
            }
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

        static bool AssertEqualFor<S, R>(Func<S, R> f1, Func<S, R> f2, IEnumerable<S> range, int verbosity = 0) where R : IComparable
        {
            long errorCount = 0L;

            foreach (var i in range)
            {
                var a = f1(i);
                var b = f2(i);
                if (a.CompareTo(b) != 0)
                {
                    errorCount++;
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
                if (errorCount == 0)
                {
                    Console.WriteLine("{0} == {1} for all values from {2} to {3}", f1.Method.Name, f2.Method.Name, range.First(), range.Last());
                }
                else
                {
                    Console.WriteLine("{0} != {1} for {2} values from {3} to {4}", f1.Method.Name, f2.Method.Name, errorCount, range.First(), range.Last());
                }
            }

            return (errorCount == 0 ? true : false);
        }

        static bool AssertEqualFor<S1, S2, R>(Func<S1, S2, R> f1, Func<S1, S2, R> f2, IEnumerable<S1> range1, IEnumerable<S2> range2, int verbosity = 0) where R : IComparable
        {
            long errorCount = 0L;

            foreach (var i in range1)
            {
                foreach (var j in range2)
                {
                    var a = f1(i, j);
                    var b = f2(i, j);
                    if (a.CompareTo(b) != 0)
                    {
                        errorCount++;
                        if (verbosity > 1)
                        {
                            Console.WriteLine("{0}: {1}", f1.Method.Name + "(" + i.ToString() + ", " + j.ToString() + ")", a);
                            Console.WriteLine("{0}: {1}", f2.Method.Name + "(" + i.ToString() + ", " + j.ToString() + ")", b);
                            Console.WriteLine();
                        }
                        else
                        {
                            break;
                        }
                    }
                }
            }
            if (verbosity > 0)
            {
                if (errorCount == 0)
                {
                    Console.WriteLine("{0} == {1} for for all values", f1.Method.Name, f2.Method.Name);
                }
                else
                {
                    Console.WriteLine("{0} != {1} for {2} values", f1.Method.Name, f2.Method.Name, errorCount);
                }
            }

            return (errorCount == 0 ? true : false);
        }

        static double BenchmarkRange<R>(Func<int, R> f1, int start, int end, int verbosity = 0, int? warmup = null)
        {
            if (warmup.HasValue)
            {
                f1(warmup.Value);
            }

            var timeElapsed = Benchmark(() =>
            {
                for (var i = start; i <= end; i++)
                {
                    BoilMathFunctions.MaxExponent(i);
                }
            }, 1, false);

            if (verbosity > 0)
            {
                Console.WriteLine("{0} took {1}ms for processing values from {2} to {3}", f1.Method.Name, timeElapsed, start, end);
            }

            return timeElapsed;
        }

        static double BenchmarkRange<R>(Func<long, R> f1, long start, long end, int verbosity = 0, long? warmup = null)
        {
            if (warmup.HasValue)
            {
                f1(warmup.Value);
            }

            var timeElapsed = Benchmark(() =>
            {
                for (var i = start; i <= end; i++)
                {
                    BoilMathFunctions.MaxExponent(i);
                }
            }, 1, false);

            if (verbosity > 0)
            {
                Console.WriteLine("{0} took {1}ms for processing values from {2} to {3}", f1.Method.Name, timeElapsed, start, end);
            }

            return timeElapsed;
        }
    }
}
