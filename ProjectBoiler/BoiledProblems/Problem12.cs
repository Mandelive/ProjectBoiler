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

            var t = (n - 1) * ((n - 2) / 2); //experimental, not based on proven math
            var i = n - 1;

            while (BoilMathFunctions.DivisorSigma(t) < n)
            {
                t += i;
                i++;
            }

            var result = t;

            return result;
        }
    }
}
