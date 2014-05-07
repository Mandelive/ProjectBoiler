using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoiledProblems
{
    public class Problem3 : BaseProblem
    {
        public Problem3(): base(
            3,
            @"TGFyZ2VzdCBwcmltZSBmYWN0b3I=",
            @"VGhlIHByaW1lIGZhY3RvcnMgb2YgMTMxOTUgYXJlIDUsIDcsIDEzIGFuZCAyOS4NCg0KV2hhdCBpcyB0aGUgbGFyZ2VzdCBwcmltZSBmYWN0b3Igb2YgdGhlIG51bWJlciA2MDA4NTE0NzUxNDMgPw==",
            new string[] {
                "n:num - find the largest prime factor for this number"
            },
            new string[] {
                "600851475143"
            }
        ) {}

        public override string Solve(string[] parameters)
        {
            long n = Int64.Parse(parameters[0]);
            return findSumOfEvenFibonacciNumbers(n).ToString();
        }

        private long findSumOfEvenFibonacciNumbers(long n)
        {
            var result = 2L;
            var fib1 = 1L;
            var fib2 = 2L;
            var fib3 = fib1 + fib2;
            var toggle = 1L;
            while (fib3 < n)
            {
                fib1 = fib2;
                fib2 = fib3;
                fib3 += fib1;
                
                if (toggle == 2L)
                {
                    result += fib3;
                    toggle = 0L;
                }
                else
                {
                    toggle++;   
                }
            }
            return result;
        }
    }
}
