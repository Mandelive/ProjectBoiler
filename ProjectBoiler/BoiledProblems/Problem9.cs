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
        public Problem9(): base(
            9,
            @"U3BlY2lhbCBQeXRoYWdvcmVhbiB0cmlwbGV0",
            @"QSBQeXRoYWdvcmVhbiB0cmlwbGV0IGlzIGEgc2V0IG9mIHRocmVlIG5hdHVyYWwgbnVtYmVycywgYSA8IGIgPCBjLCBmb3Igd2hpY2gsDQphXjIgKyBiXjIgPSBjXjINCg0KRm9yIGV4YW1wbGUsIDNeMiArIDReMiA9IDkgKyAxNiA9IDI1ID0gNV4yLg0KDQpUaGVyZSBleGlzdHMgZXhhY3RseSBvbmUgUHl0aGFnb3JlYW4gdHJpcGxldCBmb3Igd2hpY2ggYSArIGIgKyBjID0gMTAwMC4NCkZpbmQgdGhlIHByb2R1Y3QgYWJjLg0K",
            new string[] {
                "s:num - sum of pythagorean triplet"
            },
            new string[] {
                "1000"
            }
        ) {}

        public override string Solve(string[] parameters)
        {
            var s = Int64.Parse(parameters[0]);
            return findProductOfPythagoreanTriplet(s).ToString();
        }

        private long findProductOfPythagoreanTriplet(long s)
        {
            for (int a = 3; a < s / 3; a++)
            {
                for (int b = a + 1; b <= (s - a) / 2; b++)
                {
                    var c = s - (a + b);
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
