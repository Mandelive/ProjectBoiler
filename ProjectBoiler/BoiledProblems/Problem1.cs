using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoiledProblems
{
    public class Problem1 : BaseProblem
    {
        public Problem1(): base(
            1, 
            @"TXVsdGlwbGVzIG9mIDMgYW5kIDU=", 
            @"SWYgd2UgbGlzdCBhbGwgdGhlIG5hdHVyYWwgbnVtYmVycyBiZWxvdyAxMCB0aGF0IGFyZSBtdWx0aXBsZXMgb2YgMyBvciA1LCB3ZSBnZXQgMywgNSwgNiBhbmQgOS4gVGhlIHN1bSBvZiB0aGVzZSBtdWx0aXBsZXMgaXMgMjMuDQoNCkZpbmQgdGhlIHN1bSBvZiBhbGwgdGhlIG11bHRpcGxlcyBvZiAzIG9yIDUgYmVsb3cgMTAwMC4=",
            new string[] {
                "n:num - upperlimit number"
            },
            new string[] {
                "1000"
            }
        ) {}

        public override string Solve(string[] parameters)
        {
            long n = Int64.Parse(parameters[0]);
            return findSumOfThreeFiveMultiples(n).ToString();
        }

        private long findSumOfThreeFiveMultiples(long n)
        {
            n--;

            var threes = n / 3;
            var fives = n / 5;
            var fifteens = n / 15;

            var sumOfThrees = 3 * (threes * (threes + 1)) / 2;
            var sumOfFives = 5 * (fives * (fives + 1)) / 2;
            var sumOfFifteens = 15 * (fifteens * (fifteens + 1)) / 2;

            var result = sumOfThrees + sumOfFives - sumOfFifteens;

            return result;
        }
    }
}
