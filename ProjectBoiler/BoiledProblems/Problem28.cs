using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Boilerplate;

namespace BoiledProblems
{
    public class Problem28 : BaseProblem
    {
        public Problem28()
        {
            Id = 28;
            Title = @"TnVtYmVyIHNwaXJhbCBkaWFnb25hbHM=";
            Description = @"U3RhcnRpbmcgd2l0aCB0aGUgbnVtYmVyIDEgYW5kIG1vdmluZyB0byB0aGUgcmlnaHQgaW4gYSBjbG9ja3dpc2UgZGlyZWN0aW9uIGEgNSBieSA1IHNwaXJhbCBpcyBmb3JtZWQgYXMgZm9sbG93czoNCg0KMjEgMjIgMjMgMjQgMjUNCjIwICA3ICA4ICA5IDEwDQoxOSAgNiAgMSAgMiAxMQ0KMTggIDUgIDQgIDMgMTINCjE3IDE2IDE1IDE0IDEzDQoNCkl0IGNhbiBiZSB2ZXJpZmllZCB0aGF0IHRoZSBzdW0gb2YgdGhlIG51bWJlcnMgb24gdGhlIGRpYWdvbmFscyBpcyAxMDEuDQoNCldoYXQgaXMgdGhlIHN1bSBvZiB0aGUgbnVtYmVycyBvbiB0aGUgZGlhZ29uYWxzIGluIGEgMTAwMSBieSAxMDAxIHNwaXJhbCBmb3JtZWQgaW4gdGhlIHNhbWUgd2F5Pw==";

            parametersInfo = new string[]
            {
                "n:num - size of the spiral",
            };

            defaultParameters = new string[]
            {
                "1001"
            };

            ResetParameters();
        }

        public override string Solve()
        {
            var n = Int32.Parse(parameters[0]);
            return findSpiralNumbersDiagonalSum(n).ToString();
        }

        private long findSpiralNumbersDiagonalSum(int n)
        {
            var result = 1L;

            for (int i = 3; i <= n; i += 2)
            {
                result += 4 * (i * i) - (6 * (i - 1));
            }

            return result;
        }
    }
}
