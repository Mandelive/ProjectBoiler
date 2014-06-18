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

            long b0 = -234;
            long b1 = 234;
            int e0 = 2;
            int e1 = 8;

            //TestSuite.AssertEqualFor(BoilMathFunctions.ExpLinear, BoilMathFunctions.ExpBinary, TestSuite.Range(b0, b1), TestSuite.Range(e0, e1), 2);
            //TestSuite.BenchmarkRange(BoilMathFunctions.ExpLinear, b0, b1, e0, e1, 1L, 1, verbosity: 1);
            //TestSuite.BenchmarkRange(BoilMathFunctions.ExpBinary, b0, b1, e0, e1, 1L, 1, verbosity: 1);

            long n0 = 0;
            long n1 = 3037001499L;
            TestSuite.AssertEqualFor(BoilMathFunctions.MaxExponent, BoilMathFunctions.MaxExponent2, TestSuite.Range(n0, n1), 2);
            
            Console.ReadLine();
        }

    }
}
