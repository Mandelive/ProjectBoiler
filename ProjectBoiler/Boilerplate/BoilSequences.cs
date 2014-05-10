using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boilerplate
{
    public class BoilSequences
    {
        public static List<long> FibonacciSequence(long upperlimit)
        {
            var result = new List<long>();
            if (upperlimit < 1)
            {
                return result;
            }
            result.Add(1L);
            result.Add(1L);
            if (upperlimit < 2)
            {
                return result;
            }

            var fib1 = 1L;
            var fib2 = 1L;
            var fib3 = fib1 + fib2;

            result.Capacity = (int)Math.Ceiling((Math.Log(upperlimit + 0.5) + 0.5 * Math.Log(5)) / Math.Log(BoilConstants.phi)) + 5;

            while (fib3 <= upperlimit)
            {
                result.Add(fib3);
                fib1 = fib2;
                fib2 = fib3;
                fib3 += fib1;
            }

            return result;
        }
    }
}
