using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace BoiledDebugger
{
    internal class TestSuite
    {
        public static IEnumerable<int> Range(int start, int end)
        {
            for (int i = start; i <= end; i++)
            {
                yield return i;
            }
        }

        public static IEnumerable<long> Range(long start, long end)
        {
            for (long i = start; i <= end; i++)
            {
                yield return i;
            }
        }

        public static IEnumerable<BigInteger> Range(BigInteger start, BigInteger end)
        {
            for (BigInteger i = start; i <= end; i++)
            {
                yield return i;
            }
        }

        public static double Benchmark(Action action, int trials = 1, bool warmup = false)
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();

            if (warmup)
            {
                action();
            }

            var startTime = DateTime.UtcNow;
            for (int i = 0; i < trials; i++)
            {
                action();
            }
            var endTime = DateTime.UtcNow;

            var totalTime = endTime - startTime;

            return Math.Round(totalTime.TotalMilliseconds / trials);
        }

        public static bool AssertEqualFor<S, R>(Func<S, R> f1, Func<S, R> f2, IEnumerable<S> range, int verbosity = 0) where R : IComparable<R>
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

        public static bool AssertEqualFor<S1, S2, R>(Func<S1, S2, R> f1, Func<S1, S2, R> f2, IEnumerable<S1> range1, IEnumerable<S2> range2, int verbosity = 0) where R : IComparable<R>
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

        public static double BenchmarkAction(Action action, bool warmup = false, int trials = 1, string actionName = "Action", int verbosity = 0)
        {
            var timeElapsed = Benchmark(action, trials, warmup);

            if (verbosity > 0)
            {
                Console.WriteLine("{0} took {1}ms", actionName, timeElapsed);
            }

            return timeElapsed;
        }

        public static double BenchmarkValue<S, R>(Func<S, R> func, S value, S? warmup = null, int trials = 1, int verbosity = 0) where S : struct
        {
            if (warmup.HasValue)
            {
                func(warmup.Value);
            }

            var timeElapsed = Benchmark(() =>
            {
                func(value);
            }, trials);

            if (verbosity > 0)
            {
                Console.WriteLine("{0} took {1}ms for processing value {2}", func.Method.Name, timeElapsed, value);
            }

            return timeElapsed;
        }

        public static double BenchmarkValue<S1, S2, R>(Func<S1, S2, R> func, S1 value1, S2 value2, S1? warmup1 = null, S2? warmup2 = null, int trials = 1, int verbosity = 0) where S1 : struct where S2 : struct
        {
            if (warmup1.HasValue && warmup2.HasValue)
            {
                func(warmup1.Value, warmup2.Value);
            }

            var timeElapsed = Benchmark(() =>
            {
                func(value1, value2);
            }, trials);

            if (verbosity > 0)
            {
                Console.WriteLine("{0} took {1}ms for processing values {2}", func.Method.Name, timeElapsed, "{ " + value1 + ", " + value2 + " }");
            }

            return timeElapsed;
        }

        public static double BenchmarkRange<R>(Func<int, R> func, int start, int end, int? warmup = null, int trials = 1, int verbosity = 0)
        {
            if (warmup.HasValue)
            {   
                func(warmup.Value);
            }

            var timeElapsed = Benchmark(() =>
            {
                for (var i = start; i <= end; i++)
                {
                    func(i);
                }
            }, trials);

            if (verbosity > 0)
            {
                Console.WriteLine("{0} took {1}ms for processing values from {2} to {3}", func.Method.Name, timeElapsed, start, end);
            }

            return timeElapsed;
        }

        public static double BenchmarkRange<R>(Func<long, R> func, long start, long end, long? warmup = null, int trials = 1, int verbosity = 0)
        {
            if (warmup.HasValue)
            {
                func(warmup.Value);
            }

            var timeElapsed = Benchmark(() =>
            {
                for (var i = start; i <= end; i++)
                {
                    func(i);
                }
            }, trials);

            if (verbosity > 0)
            {
                Console.WriteLine("{0} took {1}ms for processing values from {2} to {3}", func.Method.Name, timeElapsed, start, end);
            }

            return timeElapsed;
        }

        public static double BenchmarkRange<R>(Func<int, int, R> func, int start1, int end1, int start2, int end2, int? warmup1 = null, int? warmup2 = null, int trials = 1, int verbosity = 0)
        {
            if (warmup1.HasValue && warmup2.HasValue)
            {
                func(warmup1.Value, warmup2.Value);
            }

            var timeElapsed = Benchmark(() =>
            {
                for (var i = start1; i <= end1; i++)
                {
                    for (var j = start2; j <= end2; j++)
                    {
                        func(i, j);
                    }
                }
            }, trials);

            if (verbosity > 0)
            {
                Console.WriteLine("{0} took {1}ms for processing values from {2} to {3}", func.Method.Name, timeElapsed, "{ " + start1 + ", " + start2 + " }", "{ " + end1 + ", " + end2 + " }");
            }

            return timeElapsed;
        }

        public static double BenchmarkRange<R>(Func<int, long, R> func, int start1, int end1, long start2, long end2, int? warmup1 = null, long? warmup2 = null, int trials = 1, int verbosity = 0)
        {
            if (warmup1.HasValue && warmup2.HasValue)
            {
                func(warmup1.Value, warmup2.Value);
            }

            var timeElapsed = Benchmark(() =>
            {
                for (var i = start1; i <= end1; i++)
                {
                    for (var j = start2; j <= end2; j++)
                    {
                        func(i, j);
                    }
                }
            }, trials);

            if (verbosity > 0)
            {
                Console.WriteLine("{0} took {1}ms for processing values from {2} to {3}", func.Method.Name, timeElapsed, "{ " + start1 + ", " + start2 + " }", "{ " + end1 + ", " + end2 + " }");
            }

            return timeElapsed;
        }

        public static double BenchmarkRange<R>(Func<long, int, R> func, long start1, long end1, int start2, int end2, long? warmup1 = null, int? warmup2 = null, int trials = 1, int verbosity = 0)
        {
            if (warmup1.HasValue && warmup2.HasValue)
            {
                func(warmup1.Value, warmup2.Value);
            }

            var timeElapsed = Benchmark(() =>
            {
                for (var i = start1; i <= end1; i++)
                {
                    for (var j = start2; j <= end2; j++)
                    {
                        func(i, j);
                    }
                }
            }, trials);

            if (verbosity > 0)
            {
                Console.WriteLine("{0} took {1}ms for processing values from {2} to {3}", func.Method.Name, timeElapsed, "{ " + start1 + ", " + start2 + " }", "{ " + end1 + ", " + end2 + " }");
            }

            return timeElapsed;
        }

        public static double BenchmarkRange<R>(Func<long, long, R> func, long start1, long end1, long start2, long end2, long? warmup1 = null, long? warmup2 = null, int trials = 1, int verbosity = 0)
        {
            if (warmup1.HasValue && warmup2.HasValue)
            {
                func(warmup1.Value, warmup2.Value);
            }

            var timeElapsed = Benchmark(() =>
            {
                for (var i = start1; i <= end1; i++)
                {
                    for (var j = start2; j <= end2; j++)
                    {
                        func(i, j);
                    }
                }
            }, trials);

            if (verbosity > 0)
            {
                Console.WriteLine("{0} took {1}ms for processing values from {2} to {3}", func.Method.Name, timeElapsed, "{ " + start1 + ", " + start2 + " }", "{ " + end1 + ", " + end2 + " }");
            }

            return timeElapsed;
        }
    }
}
