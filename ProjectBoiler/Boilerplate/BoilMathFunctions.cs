using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boilerplate
{
    public class BoilMathFunctions
    {
        public static long GcdSub(long a, long b)
        {
            if (a == 0)
            {
                return b;
            }
            if (b == 0)
            {
                return a;
            }

            while (a != b)
            {
                if (a > b)
                {
                    a -= b;
                }
                else
                {
                    b -= a;
                }
            }
            return a;
        }

        public static long GcdMod(long a, long b)
        {
            long t;
            while (b != 0)
            {
                t = b;
                b = a % b;
                a = t;
            }
            return a;
        }

        public static long GcdBin(long a, long b)
        {
            if (a == 0)
            {
                return b;
            }
            if (b == 0)
            {
                return a;
            }

            int shift;
            for (shift = 0; ((a | b) & 1) == 0; shift++)
            {
                a >>= 1;
                b >>= 1;
            }
 
            while ((a & 1) == 0)
            {
                a >>= 1;
            }
 
            long t;
            do {
                while ((b & 1) == 0)
                {
                    b >>= 1;
                }
 
                if (a > b)
                {
                    t = b;
                    b = a;
                    a = t;
                }
                b = b - a;
            } while (b != 0);
 
            return a << shift;
        }

        public static bool IsPrimeRabinMiller(long n)
        {
            if (n < 2)
            {
                return false;
            }
            else if (n < 4)
            {
                return true;
            }

            long[] witnesses;
            if (n < 1373653)
            {
                witnesses = new long[] { 2L, 3L };
            }
            else if (n < 4759123141)
            {
                witnesses = new long[] { 2L, 7L, 61L };
            }
            else if (n < 47636622961201)
            {
                witnesses = new long[] { 2L, 2570940L, 211991001L, 3749873356L };
            }
            else
            {
                witnesses = new long[] { 2L, 2570940L, 880937L, 610386380L, 4130785767L };
            }

            for (int i = 0; i < witnesses.Length; i++)
            {

            }
            return true;
        }
    }
}
