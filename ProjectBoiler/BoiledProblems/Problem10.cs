using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Boilerplate;

namespace BoiledProblems
{
    public class Problem10 : BaseProblem
    {
        public Problem10()
        {
            Id = 10;
            Title = @"U3VtbWF0aW9uIG9mIHByaW1lcw==";
            Description = @"VGhlIHN1bSBvZiB0aGUgcHJpbWVzIGJlbG93IDEwIGlzIDIgKyAzICsgNSArIDcgPSAxNy4NCg0KRmluZCB0aGUgc3VtIG9mIGFsbCB0aGUgcHJpbWVzIGJlbG93IHR3byBtaWxsaW9uLg0K";

            parametersInfo = new string[]
            {
                "n:num - upperlimit number"
            };

            defaultParameters = new string[]
            {
                "2000000"
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
            var primes = BoilSequences.PrimesSequenceUpTo(n);

            var result = 0L;

            for (int i = 0; i < primes.Count; i++)
            {
                result += primes[i];
            }

            return result;
        }
    }
}
