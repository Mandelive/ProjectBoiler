using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Numerics;
using Boilerplate;

namespace BoiledProblems
{
    public class Problem20 : BaseProblem
    {
        public Problem20()
        {
            Id = 20;
            Title = @"RmFjdG9yaWFsIGRpZ2l0IHN1bQ==";
            Description = @"biEgbWVhbnMgbiDDlyAobiDiiJIgMSkgw5cgLi4uIMOXIDMgw5cgMiDDlyAxDQoNCkZvciBleGFtcGxlLCAxMCEgPSAxMCDDlyA5IMOXIC4uLiDDlyAzIMOXIDIgw5cgMSA9IDM2Mjg4MDAsDQphbmQgdGhlIHN1bSBvZiB0aGUgZGlnaXRzIGluIHRoZSBudW1iZXIgMTAhIGlzIDMgKyA2ICsgMiArIDggKyA4ICsgMCArIDAgPSAyNy4NCg0KRmluZCB0aGUgc3VtIG9mIHRoZSBkaWdpdHMgaW4gdGhlIG51bWJlciAxMDAhDQo=";

            parametersInfo = new string[]
            {
                "n:num - n-factorial",
            };

            defaultParameters = new string[]
            {
                "100"
            };

            ResetParameters();
        }

        public override string Solve()
        {
            var n = Int32.Parse(parameters[0]);
            return findSumOfFactorialDigits(n).ToString();
        }

        private long findSumOfFactorialDigits(int n)
        {
            var numString = n.ToString();
            
            var factorialLN = 0.5 * (Math.Log(2 * BoilConstants.pi) - Math.Log(n)) + n * (Math.Log(n + 1 / (12 * n - 1)) - 1);
            var factorial = new byte[(int)(factorialLN / Math.Log(10)) + 10];

            factorial[0] = 1;

            for (int i = n; i > 1; i--)
            {
                var carryOver = (factorial[0] * i) / 10;
                factorial[0] = (byte)((factorial[0] * i) % 10);
                for (int d = 1; d < factorial.Length; d++)
                {
                    var addCarry = carryOver;
                    carryOver = (factorial[d] * i + addCarry) / 10;
                    factorial[d] = (byte)((factorial[d] * i + addCarry) % 10);
                }

                if (carryOver > 0)
                {
                    throw new OverflowException("Factorial overflow");
                }
            }

            var result = 0L;

            for (int i = 0; i < factorial.Length; i++)
            {
                result += factorial[i];
            }

            return result;
        }
    }
}
