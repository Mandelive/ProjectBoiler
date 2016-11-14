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
            Title = @"UGVybXV0ZWQgbXVsdGlwbGVz";
            Description = @"SXQgY2FuIGJlIHNlZW4gdGhhdCB0aGUgbnVtYmVyLCAxMjU4NzQsIGFuZCBpdHMgZG91YmxlLCAyNTE3NDgsIGNvbnRhaW4gZXhhY3RseSB0aGUgc2FtZSBkaWdpdHMsIGJ1dCBpbiBhIGRpZmZlcmVudCBvcmRlci4NCg0KRmluZCB0aGUgc21hbGxlc3QgcG9zaXRpdmUgaW50ZWdlciwgeCwgc3VjaCB0aGF0IDJ4LCAzeCwgNHgsIDV4LCBhbmQgNngsIGNvbnRhaW4gdGhlIHNhbWUgZGlnaXRzLg==";

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
            int countPermutes = 1;
            long currNum = 0L;

            while (countPermutes < n)
            {
                currNum++;
                countPermutes = 1;

                var countReps1 = new int[10];
                long digit = 0;
                long num = currNum;
                while (num > 0)
                {
                    digit = num % 10;
                    countReps1[digit]++;
                    num /= 10;
                }

                for (int i = 2; i <= n; i++)
                {
                    var countReps2 = new int[10];
                    num = i * currNum;
                    while (num > 0)
                    {
                        digit = num % 10;
                        countReps2[digit]++;
                        num /= 10;
                    }

                    bool isPermute = true;
                    for (int d = 0; d < 10; d++)
                    {
                        if (countReps1[d] != countReps2[d])
                        {
                            isPermute = false;
                            break;
                        }
                    }

                    if (isPermute)
                    {
                        countPermutes++;
                    }
                    else
                    {
                        break;
                    }
                }
            }

            return currNum;
        }
    }
}
