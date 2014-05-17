using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Boilerplate;

namespace BoiledProblems
{
    public class Problem15 : BaseProblem
    {
        public Problem15()
        {
            Id = 15;
            Title = @"TGF0dGljZSBwYXRocw==";
            Description = @"U3RhcnRpbmcgaW4gdGhlIHRvcCBsZWZ0IGNvcm5lciBvZiBhIDLDlzIgZ3JpZCwgYW5kIG9ubHkgYmVpbmcgYWJsZSB0byBtb3ZlIHRvIHRoZSByaWdodCBhbmQgZG93biwgdGhlcmUgYXJlIGV4YWN0bHkgNiByb3V0ZXMgdG8gdGhlIGJvdHRvbSByaWdodCBjb3JuZXIuDQoNCkhvdyBtYW55IHN1Y2ggcm91dGVzIGFyZSB0aGVyZSB0aHJvdWdoIGEgMjDDlzIwIGdyaWQ/DQo=";

            parametersInfo = new string[]
            {
                "n:num - grid size"
            };

            defaultParameters = new string[]
            {
                "20"
            };

            ResetParameters();
        }

        public override string Solve()
        {
            var n = Int32.Parse(parameters[0]);
            return findNumberOfLatticePaths(n).ToString();
        }

        private long findNumberOfLatticePaths(int n)
        {
            var grid = new long[n + 1, n + 1];

            for (int i = 1; i <= n; i++)
            {
                grid[0, i] = 1;
                grid[i, 0] = 1;

                for (int r = 1; r < i; r++)
                {
                    grid[r, i] = grid[r - 1, i] + grid[r, i - 1];
                }

                for (int c = 1; c < i; c++)
                {
                    grid[i, c] = grid[i - 1, c] + grid[i, c - 1];
                }

                grid[i, i] = grid[i - 1, i] + grid[i, i - 1];
            }

            var result = grid[n, n];

            return result;
        }
    }
}
