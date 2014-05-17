using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using Boilerplate;

namespace BoiledProblems
{
    public class Problem17 : BaseProblem
    {
        public Problem17()
        {
            Id = 17;
            Title = @"TnVtYmVyIGxldHRlciBjb3VudHM=";
            Description = @"SWYgdGhlIG51bWJlcnMgMSB0byA1IGFyZSB3cml0dGVuIG91dCBpbiB3b3Jkczogb25lLCB0d28sIHRocmVlLCBmb3VyLCBmaXZlLCB0aGVuIHRoZXJlIGFyZSAzICsgMyArIDUgKyA0ICsgNCA9IDE5IGxldHRlcnMgdXNlZCBpbiB0b3RhbC4NCg0KSWYgYWxsIHRoZSBudW1iZXJzIGZyb20gMSB0byAxMDAwIChvbmUgdGhvdXNhbmQpIGluY2x1c2l2ZSB3ZXJlIHdyaXR0ZW4gb3V0IGluIHdvcmRzLCBob3cgbWFueSBsZXR0ZXJzIHdvdWxkIGJlIHVzZWQ/DQoNCk5PVEU6IERvIG5vdCBjb3VudCBzcGFjZXMgb3IgaHlwaGVucy4gRm9yIGV4YW1wbGUsIDM0MiAodGhyZWUgaHVuZHJlZCBhbmQgZm9ydHktdHdvKSBjb250YWlucyAyMyBsZXR0ZXJzIGFuZCAxMTUgKG9uZSBodW5kcmVkIGFuZCBmaWZ0ZWVuKSBjb250YWlucyAyMCBsZXR0ZXJzLiBUaGUgdXNlIG9mICJhbmQiIHdoZW4gd3JpdGluZyBvdXQgbnVtYmVycyBpcyBpbiBjb21wbGlhbmNlIHdpdGggQnJpdGlzaCB1c2FnZS4NCg==";

            parametersInfo = new string[]
            {
                "n:num - upperlimit number"
            };

            defaultParameters = new string[]
            {
                "1000"
            };

            ResetParameters();
        }

        public override string Solve()
        {
            var n = Int32.Parse(parameters[0]);
            return findNumberOfLettersInWrittenOutNumber(n).ToString();
        }

        private long findNumberOfLettersInWrittenOutNumber(int n)
        {
            var onesLabel = new string[] { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
            var teensLabel = new string[] { "ten", "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen" };
            var tensLabel = new string[] { "zero", "ten", "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety" };
            var scalesLabel = new string[] { "hundred", "thousand", "million", "billion", "trillion" };

            var ones = new byte[onesLabel.Length];
            var teens = new byte[teensLabel.Length];
            var tens = new byte[tensLabel.Length];
            var scales = new byte[scalesLabel.Length];
            var ands = new byte[] { 3 };

            for (int i = 0; i < 10; i++)
            {
                ones[i] = (byte)onesLabel[i].Length;
                teens[i] = (byte)teensLabel[i].Length;
                tens[i] = (byte)tensLabel[i].Length;
            }

            for (int i = 0; i < scalesLabel.Length; i++)
            {
                scales[i] = (byte)scalesLabel[i].Length;
            }

            var result = 0L;

            for (int i = 1; i <= n; i++)
            {
                var digits = new byte[(i.ToString().Length - 1)/ 3 * 3 + 3];
                var numString = i.ToString().PadLeft(digits.Length, '0');

                for (int c = 0; c < numString.Length; c++)
                {
                    digits[c] = (byte)(numString[numString.Length - c - 1] - '0');
                }
                
                for (int t = 0; t < digits.Length / 3; t++)
                {
                    if (t > 0 && (digits[3 * t] + digits[3 * t + 1] + digits[3 * t + 2]) > 0)
                    {
                        result += scales[t];
                    }

                    if (digits[3 * t + 2] != 0)
                    {
                        result += scales[0] + ones[digits[3 * t + 2]];
                        if ((digits[3 * t] + digits[3 * t + 1]) > 0)
                        {
                            result += ands[0];
                        }
                    }

                    if (digits[3 * t + 1] == 1)
                    {
                        result += teens[digits[3 * t]];
                    }
                    else
                    {
                        if (digits[3 * t] > 0)
                        {
                            result += ones[digits[3 * t]];
                        }

                        if (digits[3 * t + 1] > 1)
                        {
                            result += tens[digits[3 * t + 1]];
                        }
                    }
                }

                if (digits[2] == 0 && (digits[0] + digits[1]) > 0 && i >= 1000)
                {
                    result += ands[0];
                }
            }

            return result;
        }
    }
}
