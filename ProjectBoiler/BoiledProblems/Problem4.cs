using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Boilerplate;

namespace BoiledProblems
{
    public class Problem4 : BaseProblem
    {
        public Problem4(): base(
            4,
            @"TGFyZ2VzdCBwYWxpbmRyb21lIHByb2R1Y3Q=",
            @"QSBwYWxpbmRyb21pYyBudW1iZXIgcmVhZHMgdGhlIHNhbWUgYm90aCB3YXlzLiBUaGUgbGFyZ2VzdCBwYWxpbmRyb21lIG1hZGUgZnJvbSB0aGUgcHJvZHVjdCBvZiB0d28gMi1kaWdpdCBudW1iZXJzIGlzIDkwMDkgPSA5MSDDlyA5OS4NCg0KRmluZCB0aGUgbGFyZ2VzdCBwYWxpbmRyb21lIG1hZGUgZnJvbSB0aGUgcHJvZHVjdCBvZiB0d28gMy1kaWdpdCBudW1iZXJzLg0K",
            new string[] {
                "n:num - n-digit number"
            },
            new string[] {
                "3"
            }
        ) {}

        public override string Solve(string[] parameters)
        {
            int n = Int32.Parse(parameters[0]);
            return findLargestPalindromTwoNDigits(n).ToString();
        }

        private long findLargestPalindromTwoNDigits(int n)
        {
            var top = (int)Math.Pow(10, n) - 1;
            var bottom = (int)Math.Sqrt(Math.Pow(10, 2 * n - 1));

            var max = 1L;

            for (int a = top; a > bottom; a--)
            {
                for (int b = a; b > bottom; b--)
                {
                    var t = a * b;
                    if (t > max && BoilStrings.IsPalindrome(t.ToString()))
                    {
                        max = t;
                    }
                }
            }

            var result = max;

            return result;
        }
    }
}
