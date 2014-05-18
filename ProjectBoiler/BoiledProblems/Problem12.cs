using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Boilerplate;

namespace BoiledProblems
{
    public class Problem12 : BaseProblem
    {
        public Problem12()
        {
            Id = 12;
            Title = @"SGlnaGx5IGRpdmlzaWJsZSB0cmlhbmd1bGFyIG51bWJlcg==";
            Description = @"VGhlIHNlcXVlbmNlIG9mIHRyaWFuZ2xlIG51bWJlcnMgaXMgZ2VuZXJhdGVkIGJ5IGFkZGluZyB0aGUgbmF0dXJhbCBudW1iZXJzLiBTbyB0aGUgN3RoIHRyaWFuZ2xlIG51bWJlciB3b3VsZCBiZSAxICsgMiArIDMgKyA0ICsgNSArIDYgKyA3ID0gMjguIFRoZSBmaXJzdCB0ZW4gdGVybXMgd291bGQgYmU6DQoNCjEsIDMsIDYsIDEwLCAxNSwgMjEsIDI4LCAzNiwgNDUsIDU1LCAuLi4NCg0KTGV0IHVzIGxpc3QgdGhlIGZhY3RvcnMgb2YgdGhlIGZpcnN0IHNldmVuIHRyaWFuZ2xlIG51bWJlcnM6DQoNCiAgICAgMTogMQ0KICAgICAzOiAxLDMNCiAgICAgNjogMSwyLDMsNg0KICAgIDEwOiAxLDIsNSwxMA0KICAgIDE1OiAxLDMsNSwxNQ0KICAgIDIxOiAxLDMsNywyMQ0KICAgIDI4OiAxLDIsNCw3LDE0LDI4DQoNCldlIGNhbiBzZWUgdGhhdCAyOCBpcyB0aGUgZmlyc3QgdHJpYW5nbGUgbnVtYmVyIHRvIGhhdmUgb3ZlciBmaXZlIGRpdmlzb3JzLg0KDQpXaGF0IGlzIHRoZSB2YWx1ZSBvZiB0aGUgZmlyc3QgdHJpYW5nbGUgbnVtYmVyIHRvIGhhdmUgb3ZlciBmaXZlIGh1bmRyZWQgZGl2aXNvcnM/DQo=";

            parametersInfo = new string[]
            {
                "n:num - number of divisors"
            };

            defaultParameters = new string[]
            {
                "500"
            };

            ResetParameters();
        }

        public override string Solve()
        {
            var n = Int64.Parse(parameters[0]);
            return findSumOfPrimesBelow(n).ToString();
        }

        private long findSumOfPrimesBelow(long n)
        {
            var t0 = (n - 1);
            if ((t0 & 1) == 0)
            {
                t0 = (n - 2);
            }
            var d0 = BoilMathFunctions.DivisorSigma0(t0);

            var t1 = 0L;
            var d1 = 0L;

            var divisors = 0L;

            while (divisors < n)
            {
                t0++;
                t1 = ((t0 & 1) == 0? t0 >> 1 : t0);
                d1 = BoilMathFunctions.DivisorSigma0(t1);
                divisors = d0 * d1;
                d0 = d1;
            }

            var result = t0 * (t0 - 1) / 2;

            return result;
        }
    }
}
