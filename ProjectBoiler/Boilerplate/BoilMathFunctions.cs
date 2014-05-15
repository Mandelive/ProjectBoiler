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
        public static long ModPow(long b, long e, long n)
        {
            //if (b != 0 && Int64.MaxValue / (b % n) < n - 1)
            //{
            //    throw new OverflowException("Cannot handle ModPow for base " + b + " and modulus " + n + ".");
            //}

            var result = 1L;
            b = b % n;

            while (e > 0)
            {
                if ((e & 1) == 1)
                {
                    result = (result * b) % n;
                }
                e >>= 1;
                b = (b * b) % n;
            }

            return result;
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
                b -= a;
            } while (b != 0);
 
            return a << shift;
        }

        public static long LcmGcd(long a, long b)
        {
            var gcd = GcdMod(a, b);
            if (a > b)
            {
                return (a / gcd) * b;
            }
            else
            {
                return (b / gcd) * a;
            }
        }

        public static long LcmPrimeFactorization(List<long> nums)
        {
            //TODO
            throw new NotImplementedException("TODO");
        }

        public static long DivisorSigma(long n)
        {
            if (n < 3)
            {
                return n;
            }
            else if (IsPrimeHybrid(n))
            {
                return 2;
            }

            var repeats = new List<int>();
            var primeFactors = 0;

            var smallPrimes = new long[] { 2, 3, 5, 7, 11 };
            for (int i = 0; i < smallPrimes.Length; i++)
            {
                if (n % smallPrimes[i] == 0)
                {                   
                    repeats.Add(0);
                    do 
                    {
                        repeats[primeFactors]++;
                        n /= smallPrimes[i];
                    } while (n % smallPrimes[i] == 0);
                    primeFactors++;
                }
            }

            var pattern = new long[] { 4, 2, 4, 6, 2, 6, 4, 2, 4, 6, 6, 2, 6, 4, 2, 6, 4, 6, 8, 4, 2, 4, 2, 4, 14, 4, 6, 2, 10, 2, 6, 6, 4, 2, 4, 6, 2, 10, 2, 4, 2, 12, 10, 2, 4, 2, 4, 6, 2, 6, 4, 6, 6, 6, 2, 6, 4, 2, 6, 4, 6, 8, 4, 2, 4, 6, 8, 6, 10, 2, 4, 6, 2, 6, 6, 4, 2, 4, 6, 2, 6, 4, 2, 6, 10, 2, 10, 2, 4, 2, 4, 6, 8, 4, 2, 4, 12, 2, 6, 4, 2, 6, 4, 6, 12, 2, 4, 2, 4, 8, 6, 4, 6, 2, 4, 6, 2, 6, 10, 2, 4, 6, 2, 6, 4, 2, 4, 2, 10, 2, 10, 2, 4, 6, 6, 2, 6, 6, 4, 6, 6, 2, 6, 4, 2, 6, 4, 6, 8, 4, 2, 6, 4, 8, 6, 4, 6, 2, 4, 6, 8, 6, 4, 2, 10, 2, 6, 4, 2, 4, 2, 10, 2, 10, 2, 4, 2, 4, 8, 6, 4, 2, 4, 6, 6, 2, 6, 4, 8, 4, 6, 8, 4, 2, 4, 2, 4, 8, 6, 4, 6, 6, 6, 2, 6, 6, 4, 2, 4, 6, 2, 6, 4, 2, 4, 2, 10, 2, 10, 2, 6, 4, 6, 2, 6, 4, 2, 4, 6, 6, 8, 4, 2, 6, 10, 8, 4, 2, 4, 2, 4, 8, 10, 6, 2, 4, 8, 6, 6, 4, 2, 4, 6, 2, 6, 4, 6, 2, 10, 2, 10, 2, 4, 2, 4, 6, 2, 6, 4, 2, 4, 6, 6, 2, 6, 6, 6, 4, 6, 8, 4, 2, 4, 2, 4, 8, 6, 4, 8, 4, 6, 2, 6, 6, 4, 2, 4, 6, 8, 4, 2, 4, 2, 10, 2, 10, 2, 4, 2, 4, 6, 2, 10, 2, 4, 6, 8, 6, 4, 2, 6, 4, 6, 8, 4, 6, 2, 4, 8, 6, 4, 6, 2, 4, 6, 2, 6, 6, 4, 6, 6, 2, 6, 6, 4, 2, 10, 2, 10, 2, 4, 2, 4, 6, 2, 6, 4, 2, 10, 6, 2, 6, 4, 2, 6, 4, 6, 8, 4, 2, 4, 2, 12, 6, 4, 6, 2, 4, 6, 2, 12, 4, 2, 4, 8, 6, 4, 2, 4, 2, 10, 2, 10, 6, 2, 4, 6, 2, 6, 4, 2, 4, 6, 6, 2, 6, 4, 2, 10, 6, 8, 6, 4, 2, 4, 8, 6, 4, 6, 2, 4, 6, 2, 6, 6, 6, 4, 6, 2, 6, 4, 2, 4, 2, 10, 12, 2, 4, 2, 10, 2, 6, 4, 2, 4, 6, 6, 2, 10, 2, 6, 4, 14, 4, 2, 4, 2, 4, 8, 6, 4, 6, 2, 4, 6, 2, 6, 6, 4, 2, 4, 6, 2, 6, 4, 2, 4, 12, 2, 12 };
            var basePrime = 13L;
            var patternIndex = -1;

            while (n > 1)
            {
                if (n % basePrime == 0)
                {
                    repeats.Add(0);
                    do
                    {
                        repeats[primeFactors]++;
                        n /= basePrime;
                    } while (n % basePrime == 0);
                    primeFactors++;
                }

                patternIndex++;
                if (patternIndex == pattern.Length)
                {
                    patternIndex = 0;
                }

                basePrime += pattern[patternIndex];
            }

            var productOfRepeats = 1L;

            for (int i = 0; i < repeats.Count; i++)
            {
                productOfRepeats *= (repeats[i] + 1);
            }

            var result = productOfRepeats;

            return result;
        }

        public static bool IsPrimeWheelFactorization(long n)
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

            var pattern = new byte[] { 4, 2, 4, 6, 2, 6, 4, 2, 4, 6, 6, 2, 6, 4, 2, 6, 4, 6, 8, 4, 2, 4, 2, 4, 14, 4, 6, 2, 10, 2, 6, 6, 4, 2, 4, 6, 2, 10, 2, 4, 2, 12, 10, 2, 4, 2, 4, 6, 2, 6, 4, 6, 6, 6, 2, 6, 4, 2, 6, 4, 6, 8, 4, 2, 4, 6, 8, 6, 10, 2, 4, 6, 2, 6, 6, 4, 2, 4, 6, 2, 6, 4, 2, 6, 10, 2, 10, 2, 4, 2, 4, 6, 8, 4, 2, 4, 12, 2, 6, 4, 2, 6, 4, 6, 12, 2, 4, 2, 4, 8, 6, 4, 6, 2, 4, 6, 2, 6, 10, 2, 4, 6, 2, 6, 4, 2, 4, 2, 10, 2, 10, 2, 4, 6, 6, 2, 6, 6, 4, 6, 6, 2, 6, 4, 2, 6, 4, 6, 8, 4, 2, 6, 4, 8, 6, 4, 6, 2, 4, 6, 8, 6, 4, 2, 10, 2, 6, 4, 2, 4, 2, 10, 2, 10, 2, 4, 2, 4, 8, 6, 4, 2, 4, 6, 6, 2, 6, 4, 8, 4, 6, 8, 4, 2, 4, 2, 4, 8, 6, 4, 6, 6, 6, 2, 6, 6, 4, 2, 4, 6, 2, 6, 4, 2, 4, 2, 10, 2, 10, 2, 6, 4, 6, 2, 6, 4, 2, 4, 6, 6, 8, 4, 2, 6, 10, 8, 4, 2, 4, 2, 4, 8, 10, 6, 2, 4, 8, 6, 6, 4, 2, 4, 6, 2, 6, 4, 6, 2, 10, 2, 10, 2, 4, 2, 4, 6, 2, 6, 4, 2, 4, 6, 6, 2, 6, 6, 6, 4, 6, 8, 4, 2, 4, 2, 4, 8, 6, 4, 8, 4, 6, 2, 6, 6, 4, 2, 4, 6, 8, 4, 2, 4, 2, 10, 2, 10, 2, 4, 2, 4, 6, 2, 10, 2, 4, 6, 8, 6, 4, 2, 6, 4, 6, 8, 4, 6, 2, 4, 8, 6, 4, 6, 2, 4, 6, 2, 6, 6, 4, 6, 6, 2, 6, 6, 4, 2, 10, 2, 10, 2, 4, 2, 4, 6, 2, 6, 4, 2, 10, 6, 2, 6, 4, 2, 6, 4, 6, 8, 4, 2, 4, 2, 12, 6, 4, 6, 2, 4, 6, 2, 12, 4, 2, 4, 8, 6, 4, 2, 4, 2, 10, 2, 10, 6, 2, 4, 6, 2, 6, 4, 2, 4, 6, 6, 2, 6, 4, 2, 10, 6, 8, 6, 4, 2, 4, 8, 6, 4, 6, 2, 4, 6, 2, 6, 6, 6, 4, 6, 2, 6, 4, 2, 4, 2, 10, 12, 2, 4, 2, 10, 2, 6, 4, 2, 4, 6, 6, 2, 10, 2, 6, 4, 14, 4, 2, 4, 2, 4, 8, 6, 4, 6, 2, 4, 6, 2, 6, 6, 4, 2, 4, 6, 2, 6, 4, 2, 4, 12, 2, 12 };
            var baseSemiPrime = 13L;
            var patternIndex = -1L;
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

        public static bool IsPrimeMillerRabinLong(long n)
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

            if (n < 9080191L)
            {
                witnesses = new long[] { 31, 73 };
            }
            else if (n < 4759123141L)
            {
                witnesses = new long[] { 2, 7, 61 };
            }
            else if (n < 47636622961201L)
            {
                witnesses = new long[] { 2, 2570940, 211991001, 3749873356 };
            }
            else
            {
                witnesses = new long[] { 2, 2570940, 880937, 610386380, 4130785767 };
            }

            var s = n - 1;
            while ((s & 1L) == 0)
            {
                s >>= 1;
            }

            for (int i = 0; i < witnesses.Length; i++)
            {
                var a = witnesses[i];
                var d = s;

                var mod = ModPow(a, d, n);
                while (d != n - 1 && mod != 1 && mod != (n - 1))
                {
                    mod = ModPow(mod, 2, n);
                    d <<= 1;
                }

                if (mod != (n - 1) && (d & 1L) == 0)
                {
                    return false;
                }
            }

            return true;
        }

        public static bool IsPrimeMillerRabinBigInteger(long n)
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

            if (n < 9080191L)
            {
                witnesses = new BigInteger[] { 31, 73 };
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
            if (n < 2209)
            {
                return IsPrimeWheelFactorization(n);
            }
            else if ((n & 1L) == 0)
            {
                return false;
            }
            else if (GcdMod(307444891294245705L, n) > 1) //pre-computed multiplciation of first few primes (3 * 5 * ... * 47)
            {
                return false;
            }
            else if (n < 3000000000L)
            {
                return IsPrimeMillerRabinLong(n);
            }

            return IsPrimeMillerRabinBigInteger(n);
        }
    }
}
