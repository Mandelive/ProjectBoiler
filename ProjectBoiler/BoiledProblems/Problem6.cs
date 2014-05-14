using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Boilerplate;

namespace BoiledProblems
{
    public class Problem6 : BaseProblem
    {
        public Problem6(): base(
            6,
            @"U3VtIHNxdWFyZSBkaWZmZXJlbmNl",
            @"VGhlIHN1bSBvZiB0aGUgc3F1YXJlcyBvZiB0aGUgZmlyc3QgdGVuIG5hdHVyYWwgbnVtYmVycyBpcywNCjFeMiArIDJeMiArIC4uLiArIDEwXjIgPSAzODUNCg0KVGhlIHNxdWFyZSBvZiB0aGUgc3VtIG9mIHRoZSBmaXJzdCB0ZW4gbmF0dXJhbCBudW1iZXJzIGlzLA0KKDEgKyAyICsgLi4uICsgMTApXjIgPSA1NTIgPSAzMDI1DQoNCkhlbmNlIHRoZSBkaWZmZXJlbmNlIGJldHdlZW4gdGhlIHN1bSBvZiB0aGUgc3F1YXJlcyBvZiB0aGUgZmlyc3QgdGVuIG5hdHVyYWwgbnVtYmVycyBhbmQgdGhlIHNxdWFyZSBvZiB0aGUgc3VtIGlzIDMwMjUg4oiSIDM4NSA9IDI2NDAuDQoNCkZpbmQgdGhlIGRpZmZlcmVuY2UgYmV0d2VlbiB0aGUgc3VtIG9mIHRoZSBzcXVhcmVzIG9mIHRoZSBmaXJzdCBvbmUgaHVuZHJlZCBuYXR1cmFsIG51bWJlcnMgYW5kIHRoZSBzcXVhcmUgb2YgdGhlIHN1bS4NCg==",
            new string[] {
                "n:num - upperlimit number"
            },
            new string[] {
                "100"
            }
        ) {}

        public override string Solve(string[] parameters)
        {
            var n = Int64.Parse(parameters[0]);
            return findSumSquareDifference(n).ToString();
        }

        private long findSumSquareDifference(long n)
        {
            long squareOfSum = n * (n + 1) / 2;
            squareOfSum *= squareOfSum;

            long sumOfSquares = 0;

            for (long i = 1; i <= n; i++)
            {
                sumOfSquares += i * i;
            }

            var result = squareOfSum - sumOfSquares;

            return result;
        }
    }
}
