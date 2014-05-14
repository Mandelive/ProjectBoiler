using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Boilerplate;

namespace BoiledProblems
{
    public class Problem3 : BaseProblem
    {
        public Problem3()
        {
            Id = 3;
            Title = @"TGFyZ2VzdCBwcmltZSBmYWN0b3I=";
            Description = @"VGhlIHByaW1lIGZhY3RvcnMgb2YgMTMxOTUgYXJlIDUsIDcsIDEzIGFuZCAyOS4NCg0KV2hhdCBpcyB0aGUgbGFyZ2VzdCBwcmltZSBmYWN0b3Igb2YgdGhlIG51bWJlciA2MDA4NTE0NzUxNDMgPw==";

            parametersInfo = new string[]
            {
                "n:num - number to factor"
            };

            defaultParameters = new string[]
            {
                "600851475143"
            };

            ResetParameters();
        }

        public override string Solve()
        {
            long n = Int64.Parse(parameters[0]);
            return findLargestPrimeFactor(n).ToString();
        }

        private long findLargestPrimeFactor(long n)
        {
            var result = BoilSequences.PrimeFactorizationWF(n).Last();
            return result;
        }
    }
}
