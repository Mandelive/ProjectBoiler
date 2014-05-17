using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using Boilerplate;

namespace BoiledProblems
{
    public class Problem16 : BaseProblem
    {
        public Problem16()
        {
            Id = 16;
            Title = @"UG93ZXIgZGlnaXQgc3Vt";
            Description = @"Ml4xNSA9IDMyNzY4IGFuZCB0aGUgc3VtIG9mIGl0cyBkaWdpdHMgaXMgMyArIDIgKyA3ICsgNiArIDggPSAyNi4NCg0KV2hhdCBpcyB0aGUgc3VtIG9mIHRoZSBkaWdpdHMgb2YgdGhlIG51bWJlciAyXjEwMDA/DQo=";

            parametersInfo = new string[]
            {
                "n:num - power of two"
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
            return findSumOfDigitsOfPowerTwo(n).ToString();
        }

        private long findSumOfDigitsOfPowerTwo(int n)
        {
            BigInteger bi = BigInteger.Pow(2, n);

            var result = 0L;

            var num = bi.ToString();

            for (int i = 0; i < num.Length; i++)
            {
                result += num[i] - '0';
            }

            return result;
        }
    }
}
