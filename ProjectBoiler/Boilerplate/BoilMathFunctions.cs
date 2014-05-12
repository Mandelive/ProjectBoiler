using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace Boilerplate
{
    public class BoilMathFunctions
    {
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
                b -= a;
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

        public static bool IsPrimeWheelFact(long n)
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
            else if (n < 15)
            {
                if (n == 9)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            else if (n % 3 == 0 || n % 5 == 0 || n % 7 == 0 || n % 11 == 0)
            {
                return false;
            }

            var pattern = new long[] { 4, 2, 4, 6, 2, 6, 4, 2, 4, 6, 6, 2, 6, 4, 2, 6, 4, 6, 8, 4, 2, 4, 2, 4, 14, 4, 6, 2, 10, 2, 6, 6, 4, 2, 4, 6, 2, 10, 2, 4, 2, 12, 10, 2, 4, 2, 4, 6, 2, 6, 4, 6, 6, 6, 2, 6, 4, 2, 6, 4, 6, 8, 4, 2, 4, 6, 8, 6, 10, 2, 4, 6, 2, 6, 6, 4, 2, 4, 6, 2, 6, 4, 2, 6, 10, 2, 10, 2, 4, 2, 4, 6, 8, 4, 2, 4, 12, 2, 6, 4, 2, 6, 4, 6, 12, 2, 4, 2, 4, 8, 6, 4, 6, 2, 4, 6, 2, 6, 10, 2, 4, 6, 2, 6, 4, 2, 4, 2, 10, 2, 10, 2, 4, 6, 6, 2, 6, 6, 4, 6, 6, 2, 6, 4, 2, 6, 4, 6, 8, 4, 2, 6, 4, 8, 6, 4, 6, 2, 4, 6, 8, 6, 4, 2, 10, 2, 6, 4, 2, 4, 2, 10, 2, 10, 2, 4, 2, 4, 8, 6, 4, 2, 4, 6, 6, 2, 6, 4, 8, 4, 6, 8, 4, 2, 4, 2, 4, 8, 6, 4, 6, 6, 6, 2, 6, 6, 4, 2, 4, 6, 2, 6, 4, 2, 4, 2, 10, 2, 10, 2, 6, 4, 6, 2, 6, 4, 2, 4, 6, 6, 8, 4, 2, 6, 10, 8, 4, 2, 4, 2, 4, 8, 10, 6, 2, 4, 8, 6, 6, 4, 2, 4, 6, 2, 6, 4, 6, 2, 10, 2, 10, 2, 4, 2, 4, 6, 2, 6, 4, 2, 4, 6, 6, 2, 6, 6, 6, 4, 6, 8, 4, 2, 4, 2, 4, 8, 6, 4, 8, 4, 6, 2, 6, 6, 4, 2, 4, 6, 8, 4, 2, 4, 2, 10, 2, 10, 2, 4, 2, 4, 6, 2, 10, 2, 4, 6, 8, 6, 4, 2, 6, 4, 6, 8, 4, 6, 2, 4, 8, 6, 4, 6, 2, 4, 6, 2, 6, 6, 4, 6, 6, 2, 6, 6, 4, 2, 10, 2, 10, 2, 4, 2, 4, 6, 2, 6, 4, 2, 10, 6, 2, 6, 4, 2, 6, 4, 6, 8, 4, 2, 4, 2, 12, 6, 4, 6, 2, 4, 6, 2, 12, 4, 2, 4, 8, 6, 4, 2, 4, 2, 10, 2, 10, 6, 2, 4, 6, 2, 6, 4, 2, 4, 6, 6, 2, 6, 4, 2, 10, 6, 8, 6, 4, 2, 4, 8, 6, 4, 6, 2, 4, 6, 2, 6, 6, 6, 4, 6, 2, 6, 4, 2, 4, 2, 10, 12, 2, 4, 2, 10, 2, 6, 4, 2, 4, 6, 6, 2, 10, 2, 6, 4, 14, 4, 2, 4, 2, 4, 8, 6, 4, 6, 2, 4, 6, 2, 6, 6, 4, 2, 4, 6, 2, 6, 4, 2, 4, 12, 2, 12 };
            var baseSemiPrime = 13L;
            var patternIndex = -1;
            var nsqrt = (long)(Math.Sqrt(n));

            for (long sp = baseSemiPrime; sp <= nsqrt; sp += pattern[patternIndex])
            {
                if (n % sp == 0)
                {
                    return false;
                }
                patternIndex++;
                if (patternIndex == pattern.Length)
                {
                    patternIndex = 0;
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

            BigInteger[] witnesses;

            if (n < 1373653L)
            {
                witnesses = new BigInteger[] { 2, 3 };
            }
            else if (n < 4759123141L)
            {
                witnesses = new BigInteger[] { 2, 7, 61 };
            }
            else if (n < 47636622961201L)
            {
                witnesses = new BigInteger[] { 2, 2570940, 211991001, 3749873356 };
            }
            else
            {
                witnesses = new BigInteger[] { 2, 2570940, 880937, 610386380, 4130785767 };
            }

            var s = n - 1;
            while ((s & 1L) == 0)
            {
                s >>= 1;
            }

            var bigN = new BigInteger(n);
            var bigNm1 = new BigInteger(n - 1);

            for (int i = 0; i < witnesses.Length; i++)
            {
                var a = witnesses[i];
                var d = s;

                var mod = BigInteger.ModPow(a, new BigInteger(d), bigN);
                while(d != n - 1 && !mod.IsOne && mod != bigNm1)
                {
		            mod = BigInteger.ModPow(mod, 2, bigN);
		            d <<= 1;
                }

                if(mod != bigNm1 && (d & 1L) == 0)
                {
		            return false;
                }
            }

            return true;
        }

        public static bool IsPrimeHybrid(long n)
        {
            if (n < 510511L)
            {
                return IsPrimeWheelFact(n);
            }
            else if ((n & 1L) == 0)
            {
                return false;
            }
            else if (BoilMathFunctions.GcdMod(n, 510510L) > 1) //pre-computed multiplciation of first few primes (3 * 5 * ... * 19)
            {
                return false;
            }
            //else if (n > 9699690 && BoilMathFunctions.GcdMod(3359814435017L, n) > 1) //pre-computed multiplciation of first few primes (23 * 5 * ... * 53)
            //{
            //    return false;
            //}

            return IsPrimeMillerRabin(n);
        }
    }
}
