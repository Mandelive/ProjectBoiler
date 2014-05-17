using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Boilerplate;

namespace BoiledProblems
{
    public class Problem9 : BaseProblem
    {
        public Problem9()
        {
            Id = 9;
            Title = @"U3BlY2lhbCBQeXRoYWdvcmVhbiB0cmlwbGV0";
            Description = @"QSBQeXRoYWdvcmVhbiB0cmlwbGV0IGlzIGEgc2V0IG9mIHRocmVlIG5hdHVyYWwgbnVtYmVycywgYSA8IGIgPCBjLCBmb3Igd2hpY2gsDQphXjIgKyBiXjIgPSBjXjINCg0KRm9yIGV4YW1wbGUsIDNeMiArIDReMiA9IDkgKyAxNiA9IDI1ID0gNV4yLg0KDQpUaGVyZSBleGlzdHMgZXhhY3RseSBvbmUgUHl0aGFnb3JlYW4gdHJpcGxldCBmb3Igd2hpY2ggYSArIGIgKyBjID0gMTAwMC4NCkZpbmQgdGhlIHByb2R1Y3QgYWJjLg0K";

            parametersInfo = new string[]
            {
                "n:num - sum of pythagorean triplet"
            };

            defaultParameters = new string[]
            {
                "1000"
            };

            ResetParameters();
        }

        public override string Solve()
        {
            var n = Int64.Parse(parameters[0]);
            return findProductOfPythagoreanTriplet(n).ToString();
        }

        private long findProductOfPythagoreanTriplet(long n)
        {
            for (int a = 3; a < n / 3; a++)
            {
                for (int b = a + 1; b <= (n - a) / 2; b++)
                {
                    var c = n - (a + b);
                    if (c * c == (a * a) + (b * b))
                    {
                        return a * b * c;
                    }
                }
            }

            return -1;
        }
    }
}
