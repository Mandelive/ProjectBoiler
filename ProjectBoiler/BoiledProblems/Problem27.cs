using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Boilerplate;

namespace BoiledProblems
{
    public class Problem27 : BaseProblem
    {
        public Problem27()
        {
            Id = 27;
            Title = @"UXVhZHJhdGljIHByaW1lcw==";
            Description = @"RXVsZXIgZGlzY292ZXJlZCB0aGUgcmVtYXJrYWJsZSBxdWFkcmF0aWMgZm9ybXVsYToNCg0Kbl4yICsgbiArIDQxDQoNCkl0IHR1cm5zIG91dCB0aGF0IHRoZSBmb3JtdWxhIHdpbGwgcHJvZHVjZSA0MCBwcmltZXMgZm9yIHRoZSBjb25zZWN1dGl2ZSBpbnRlZ2VyIHZhbHVlcyAwIOKJpCBuIOKJpCAzOS4gSG93ZXZlciwgd2hlbiBuID0gNDAsIDQwXjIgKyA0MCArIDQxID0gNDAgKDQwICsgMSkgKyA0MSBpcyBkaXZpc2libGUgYnkgNDEsIGFuZCBjZXJ0YWlubHkgd2hlbiBuID0gNDEsIDQxXjIgKyA0MSArIDQxIGlzIGNsZWFybHkgZGl2aXNpYmxlIGJ5IDQxLg0KDQpUaGUgaW5jcmVkaWJsZSBmb3JtdWxhIG5eMiDiiJIgNzluICsgMTYwMSB3YXMgZGlzY292ZXJlZCwgd2hpY2ggcHJvZHVjZXMgODAgcHJpbWVzIGZvciB0aGUgY29uc2VjdXRpdmUgdmFsdWVzIDAg4omkIG4g4omkIDc5LiBUaGUgcHJvZHVjdCBvZiB0aGUgY29lZmZpY2llbnRzLCDiiJI3OSBhbmQgMTYwMSwgaXMg4oiSMTI2NDc5Lg0KDQpDb25zaWRlcmluZyBxdWFkcmF0aWNzIG9mIHRoZSBmb3JtOg0KDQpuXjIgKyBhbiArIGIsIHdoZXJlIHxhfCA8IDEwMDAgYW5kIHxifCDiiaQgMTAwMA0KDQp3aGVyZSB8bnwgaXMgdGhlIG1vZHVsdXMvYWJzb2x1dGUgdmFsdWUgb2Ygbg0KZS5nLiB8MTF8ID0gMTEgYW5kIHziiJI0fCA9IDQNCg0KRmluZCB0aGUgcHJvZHVjdCBvZiB0aGUgY29lZmZpY2llbnRzLCBhIGFuZCBiLCBmb3IgdGhlIHF1YWRyYXRpYyBleHByZXNzaW9uIHRoYXQgcHJvZHVjZXMgdGhlIG1heGltdW0gbnVtYmVyIG9mIHByaW1lcyBmb3IgY29uc2VjdXRpdmUgdmFsdWVzIG9mIG4sIHN0YXJ0aW5nIHdpdGggbiA9IDAu";

            parametersInfo = new string[]
            {
                "a:num - Coefficient a absolute range",
                "b:num - Coefficient b absolute range"
            };

            defaultParameters = new string[]
            {
                "1000",
                "1000"
            };

            ResetParameters();
        }

        public override string Solve()
        {
            var a = Int32.Parse(parameters[0]);
            var b = Int32.Parse(parameters[1]);
            return findCoefficientsWithMostPrimes(a, b).ToString();
        }

        private long findCoefficientsWithMostPrimes(int a, int b)
        {
            var maxPrimes = 1;
            var coeffProd = 0L;

            var primes = BoilSequences.PrimesSequenceUpTo(b);

            for (int i = -a + 1; i < a; i++)
            {
                foreach (var p in primes)
                { 
                    if (!BoilMathFunctions.IsPrimeHybrid(maxPrimes * maxPrimes + i * maxPrimes + p))
                    {
                        continue;
                    }

                    var n = 1;
                    var num = n * n + i * n + p;
                    while (BoilMathFunctions.IsPrimeHybrid(num))
                    {
                        n++;
                        num = n * n + i * n + p;
                    }
                    if (n > maxPrimes)
                    {
                        maxPrimes = n;
                        coeffProd = i * p;
                    }
                }
            }

            return coeffProd;
        }
    }
}
