using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Boilerplate;

namespace BoiledProblems
{
    public class Problem52 : BaseProblem
    {
        public Problem52()
        {
            Id = 52;
            Title = @"";
            Description = @"";

            parametersInfo = new string[]
            {
                "n:num - Number of repeated digits"
            };

            defaultParameters = new string[]
            {
                "6"
            };

            ResetParameters();
        }

        public override string Solve()
        {
            var n = Int32.Parse(parameters[0]);
            return findSmallestMultipleWithSameDigits(n).ToString();
        }

        private long findSmallestMultipleWithSameDigits(int n)
        {
            long result = 0;

            return result;
        }
    }
}
