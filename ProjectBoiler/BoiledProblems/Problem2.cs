using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoiledProblems
{
    public class Problem2 : BaseProblem
    {
        public Problem2(): base(
            2,
            @"RXZlbiBGaWJvbmFjY2kgbnVtYmVycw==",
            @"RWFjaCBuZXcgdGVybSBpbiB0aGUgRmlib25hY2NpIHNlcXVlbmNlIGlzIGdlbmVyYXRlZCBieSBhZGRpbmcgdGhlIHByZXZpb3VzIHR3byB0ZXJtcy4gQnkgc3RhcnRpbmcgd2l0aCAxIGFuZCAyLCB0aGUgZmlyc3QgMTAgdGVybXMgd2lsbCBiZToNCg0KMSwgMiwgMywgNSwgOCwgMTMsIDIxLCAzNCwgNTUsIDg5LCAuLi4NCg0KQnkgY29uc2lkZXJpbmcgdGhlIHRlcm1zIGluIHRoZSBGaWJvbmFjY2kgc2VxdWVuY2Ugd2hvc2UgdmFsdWVzIGRvIG5vdCBleGNlZWQgZm91ciBtaWxsaW9uLCBmaW5kIHRoZSBzdW0gb2YgdGhlIGV2ZW4tdmFsdWVkIHRlcm1zLg==",
            new string[] {
                "n:num - upperlimit number"
            },
            new string[] {
                "4000000"
            }
        ) {}

        public override string Solve(string[] parameters)
        {
            long n = Int64.Parse(parameters[0]);
            return findSumOfEvenFibonacciNumbers(n).ToString();
        }

        private long findSumOfEvenFibonacciNumbers(long n)
        {
            var result = 2L;
            var fib1 = 1L;
            var fib2 = 2L;
            var fib3 = fib1 + fib2;
            var toggle = 1L;
            while (fib3 < n)
            {
                fib1 = fib2;
                fib2 = fib3;
                fib3 += fib1;
                
                if (toggle == 2L)
                {
                    result += fib3;
                    toggle = 0L;
                }
                else
                {
                    toggle++;   
                }
            }
            return result;
        }
    }
}
