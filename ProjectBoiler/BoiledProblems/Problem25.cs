using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using Boilerplate;

namespace BoiledProblems
{
    public class Problem25 : BaseProblem
    {
        public Problem25()
        {
            Id = 25;
            Title = @"MTAwMC1kaWdpdCBGaWJvbmFjY2kgbnVtYmVy";
            Description = @"VGhlIEZpYm9uYWNjaSBzZXF1ZW5jZSBpcyBkZWZpbmVkIGJ5IHRoZSByZWN1cnJlbmNlIHJlbGF0aW9uOg0KDQpGbiA9IEZu4oiSMSArIEZu4oiSMiwgd2hlcmUgRjEgPSAxIGFuZCBGMiA9IDEuDQpIZW5jZSB0aGUgZmlyc3QgMTIgdGVybXMgd2lsbCBiZToNCg0KRjEgPSAxDQpGMiA9IDENCkYzID0gMg0KRjQgPSAzDQpGNSA9IDUNCkY2ID0gOA0KRjcgPSAxMw0KRjggPSAyMQ0KRjkgPSAzNA0KRjEwID0gNTUNCkYxMSA9IDg5DQpGMTIgPSAxNDQNClRoZSAxMnRoIHRlcm0sIEYxMiwgaXMgdGhlIGZpcnN0IHRlcm0gdG8gY29udGFpbiB0aHJlZSBkaWdpdHMuDQoNCldoYXQgaXMgdGhlIGluZGV4IG9mIHRoZSBmaXJzdCB0ZXJtIGluIHRoZSBGaWJvbmFjY2kgc2VxdWVuY2UgdG8gY29udGFpbiAxMDAwIGRpZ2l0cz8=";

            parametersInfo = new string[]
            {
                "n:num - number of digits permutation"
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
            return findFirstFibNumWithNDigits(n).ToString();
        }

        private long findFirstFibNumWithNDigits(int n)
        {
            var fib1 = new BigInteger(1);
            var fib2 = new BigInteger(1);
            var fib3 = fib1 + fib2;
            var min = BigInteger.Pow(10, n - 1);

            long nth = 3;

            while (fib3 < min)
            {
                nth++;
                fib1 = fib2;
                fib2 = fib3;
                fib3 += fib1;
            }

            return nth;
        }
    }
}
