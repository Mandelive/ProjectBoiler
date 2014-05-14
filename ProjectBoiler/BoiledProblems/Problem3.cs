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
        public Problem3(): base(
            3,
            @"TGFyZ2VzdCBwcmltZSBmYWN0b3I=",
            @"VGhlIHByaW1lIGZhY3RvcnMgb2YgMTMxOTUgYXJlIDUsIDcsIDEzIGFuZCAyOS4NCg0KV2hhdCBpcyB0aGUgbGFyZ2VzdCBwcmltZSBmYWN0b3Igb2YgdGhlIG51bWJlciA2MDA4NTE0NzUxNDMgPw==",
            new string[] {
                "n:num - number to factor"
            },
            new string[] {
                "600851475143"
            }
        ) {}

        public override string Solve(string[] parameters)
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
