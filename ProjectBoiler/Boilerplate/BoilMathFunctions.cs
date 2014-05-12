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

        public static bool IsPrimeTrialDivision(long n)
        {
            if (n < 2)
            {
                return false;
            }
            else if (n < 4)
            {
                return true;
            }
            else if ((n & 1L) == 0)
            {
                return false;
            }

            var nsqrt = (long)(Math.Sqrt(n));
            var primes = BoilSequences.PrimesSequenceUpTo(nsqrt);

            foreach (var p in primes)
            {
                if (n % p == 0)
                {
                    return false;
                }
            }

            return true;
        }

        public static bool IsPrimeMillerRabin(long n)
        {
            if (n < 2)
            {
                return false;
            }
            else if (n < 4)
            {
                return true;
            }
            else if ((n & 1L) == 0)
            {
                return false;
            }

            long[] witnesses;

            if (n < 1373653L)
            {
                witnesses = new long[] { 2L, 3L };
            }
            else if (n < 4759123141L)
            {
                witnesses = new long[] { 2L, 7L, 61L };
            }
            else if (n < 47636622961201L)
            {
                witnesses = new long[] { 2L, 2570940L, 211991001L, 3749873356L };
            }
            else
            {
                witnesses = new long[] { 2L, 2570940L, 880937L, 610386380L, 4130785767L };
            }

            var s = n - 1;
            while ((s & 1L) == 0)
            {
                s >>= 1;
            }

            for (int i = 0; i < witnesses.Length; i++)
            {
                var a = witnesses[i];
                var temp = s;
                var mod = (long)Math.Pow((double)a, (double)temp) % n;
                while(temp != n - 1 && mod != 1 && mod != n - 1)
                {
		            mod = (mod * mod) % n;
		            temp = temp * 2;
                }
                if(mod != n - 1 && temp % 2 == 0)
                {
		            return false;
                }
            }

            return true;
        }

        public static bool IsPrimeHybrid(long n)
        {
            if (n < 2809)
            {
                return IsPrimeTrialDivision(n);
            }
            else if ((n & 1L) == 0)
            {
                return false;
            }
            else if (BoilMathFunctions.GcdMod(307444891294245705L, n) > 1) //pre-computed multiplciation of first few primes (3 * 5 * ... * 47)
            {
                return false;
            }

            return IsPrimeMillerRabin(n);
        }
    }
}
