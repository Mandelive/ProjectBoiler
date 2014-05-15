using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Boilerplate;

namespace BoiledProblems
{
    public class Problem7 : BaseProblem
    {
        public Problem7()
        {
            Id = 7;
            Title = @"MTAwMDFzdCBwcmltZQ==";
            Description = @"QnkgbGlzdGluZyB0aGUgZmlyc3Qgc2l4IHByaW1lIG51bWJlcnM6IDIsIDMsIDUsIDcsIDExLCBhbmQgMTMsIHdlIGNhbiBzZWUgdGhhdCB0aGUgNnRoIHByaW1lIGlzIDEzLg0KDQpXaGF0IGlzIHRoZSAxMCAwMDFzdCBwcmltZSBudW1iZXI/DQo=";

            parametersInfo = new string[]
            {
                "n:num - nth prime"
            };

            defaultParameters = new string[]
            {
                "10001"
            };

            ResetParameters();
        }

        public override string Solve()
        {
            var n = Int32.Parse(parameters[0]);
            return findNthPrime(n).ToString();
        }

        private long findNthPrime(int n)
        {
            var primes = BoilSequences.PrimesSequenceNth(n);

            var result = primes.Last();

            return result;
        }
    }
}
