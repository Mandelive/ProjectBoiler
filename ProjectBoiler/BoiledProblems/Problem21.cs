using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Numerics;
using Boilerplate;


namespace BoiledProblems
{
    public class Problem21 : BaseProblem
    {
        public Problem21()
        {
            Id = 21;
            Title = @"QW1pY2FibGUgbnVtYmVycw==";
            Description = @"TGV0IGQobikgYmUgZGVmaW5lZCBhcyB0aGUgc3VtIG9mIHByb3BlciBkaXZpc29ycyBvZiBuIChudW1iZXJzIGxlc3MgdGhhbiBuIHdoaWNoIGRpdmlkZSBldmVubHkgaW50byBuKS4NCklmIGQoYSkgPSBiIGFuZCBkKGIpID0gYSwgd2hlcmUgYSDiiaAgYiwgdGhlbiBhIGFuZCBiIGFyZSBhbiBhbWljYWJsZSBwYWlyIGFuZCBlYWNoIG9mIGEgYW5kIGIgYXJlIGNhbGxlZCBhbWljYWJsZSBudW1iZXJzLg0KDQpGb3IgZXhhbXBsZSwgdGhlIHByb3BlciBkaXZpc29ycyBvZiAyMjAgYXJlIDEsIDIsIDQsIDUsIDEwLCAxMSwgMjAsIDIyLCA0NCwgNTUgYW5kIDExMDsgdGhlcmVmb3JlIGQoMjIwKSA9IDI4NC4gVGhlIHByb3BlciBkaXZpc29ycyBvZiAyODQgYXJlIDEsIDIsIDQsIDcxIGFuZCAxNDI7IHNvIGQoMjg0KSA9IDIyMC4NCg0KRXZhbHVhdGUgdGhlIHN1bSBvZiBhbGwgdGhlIGFtaWNhYmxlIG51bWJlcnMgdW5kZXIgMTAwMDAuDQo=";

            parametersInfo = new string[]
            {
                "n:num - upperlimit number",
            };

            defaultParameters = new string[]
            {
                "10000"
            };

            ResetParameters();
        }

        public override string Solve()
        {
            var n = Int32.Parse(parameters[0]);
            return findSumOfAmicableNumbers(n).ToString();
        }

        private long findSumOfAmicableNumbers(int n)
        {
            var result = 0L;
            var divisorSum = new int[n];

            for (int i = 1; i < n; i++)
            {
                divisorSum[i] = (int)BoilMathFunctions.DivisorSigma1(i, true);
            }

            for (int i = 1; i < n; i++)
            {
                if (divisorSum[i] < n && i < divisorSum[i] && i == divisorSum[divisorSum[i]])
                {
                    result += i + divisorSum[i];
                }
            }

            return result;
        }
    }
}
