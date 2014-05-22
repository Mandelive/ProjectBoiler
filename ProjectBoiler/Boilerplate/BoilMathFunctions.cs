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

        public static long DivisorSigma0(long n)
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
                    repeats.Add(1);
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
                if (basePrime * basePrime > n)
                {
                    repeats.Add(2);
                    break;
                }
                else if (n % basePrime == 0)
                {
                    repeats.Add(1);
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
                productOfRepeats *= repeats[i];
            }

            var result = productOfRepeats;

            return result;
        }

        public static long DivisorSigma1(long n, bool aliquot = false)
        {
            if (n < 2)
            {
                return n;
            }
            else if (IsPrimeHybrid(n))
            {
                if (aliquot)
                {
                    return 1;
                }
                else
                {
                    return n + 1;
                }
            }

            var copyOfN = n;

            var repeats = new List<int>();
            var primes = new List<long>();

            var smallPrimes = new long[] { 2, 3, 5, 7, 11 };
            for (int i = 0; i < smallPrimes.Length; i++)
            {
                if (n % smallPrimes[i] == 0)
                {
                    repeats.Add(1);
                    primes.Add(smallPrimes[i]);
                    do
                    {
                        repeats[primes.Count - 1]++;
                        n /= smallPrimes[i];
                    } while (n % smallPrimes[i] == 0);
                }
            }

            var pattern = new long[] { 4, 2, 4, 6, 2, 6, 4, 2, 4, 6, 6, 2, 6, 4, 2, 6, 4, 6, 8, 4, 2, 4, 2, 4, 14, 4, 6, 2, 10, 2, 6, 6, 4, 2, 4, 6, 2, 10, 2, 4, 2, 12, 10, 2, 4, 2, 4, 6, 2, 6, 4, 6, 6, 6, 2, 6, 4, 2, 6, 4, 6, 8, 4, 2, 4, 6, 8, 6, 10, 2, 4, 6, 2, 6, 6, 4, 2, 4, 6, 2, 6, 4, 2, 6, 10, 2, 10, 2, 4, 2, 4, 6, 8, 4, 2, 4, 12, 2, 6, 4, 2, 6, 4, 6, 12, 2, 4, 2, 4, 8, 6, 4, 6, 2, 4, 6, 2, 6, 10, 2, 4, 6, 2, 6, 4, 2, 4, 2, 10, 2, 10, 2, 4, 6, 6, 2, 6, 6, 4, 6, 6, 2, 6, 4, 2, 6, 4, 6, 8, 4, 2, 6, 4, 8, 6, 4, 6, 2, 4, 6, 8, 6, 4, 2, 10, 2, 6, 4, 2, 4, 2, 10, 2, 10, 2, 4, 2, 4, 8, 6, 4, 2, 4, 6, 6, 2, 6, 4, 8, 4, 6, 8, 4, 2, 4, 2, 4, 8, 6, 4, 6, 6, 6, 2, 6, 6, 4, 2, 4, 6, 2, 6, 4, 2, 4, 2, 10, 2, 10, 2, 6, 4, 6, 2, 6, 4, 2, 4, 6, 6, 8, 4, 2, 6, 10, 8, 4, 2, 4, 2, 4, 8, 10, 6, 2, 4, 8, 6, 6, 4, 2, 4, 6, 2, 6, 4, 6, 2, 10, 2, 10, 2, 4, 2, 4, 6, 2, 6, 4, 2, 4, 6, 6, 2, 6, 6, 6, 4, 6, 8, 4, 2, 4, 2, 4, 8, 6, 4, 8, 4, 6, 2, 6, 6, 4, 2, 4, 6, 8, 4, 2, 4, 2, 10, 2, 10, 2, 4, 2, 4, 6, 2, 10, 2, 4, 6, 8, 6, 4, 2, 6, 4, 6, 8, 4, 6, 2, 4, 8, 6, 4, 6, 2, 4, 6, 2, 6, 6, 4, 6, 6, 2, 6, 6, 4, 2, 10, 2, 10, 2, 4, 2, 4, 6, 2, 6, 4, 2, 10, 6, 2, 6, 4, 2, 6, 4, 6, 8, 4, 2, 4, 2, 12, 6, 4, 6, 2, 4, 6, 2, 12, 4, 2, 4, 8, 6, 4, 2, 4, 2, 10, 2, 10, 6, 2, 4, 6, 2, 6, 4, 2, 4, 6, 6, 2, 6, 4, 2, 10, 6, 8, 6, 4, 2, 4, 8, 6, 4, 6, 2, 4, 6, 2, 6, 6, 6, 4, 6, 2, 6, 4, 2, 4, 2, 10, 12, 2, 4, 2, 10, 2, 6, 4, 2, 4, 6, 6, 2, 10, 2, 6, 4, 14, 4, 2, 4, 2, 4, 8, 6, 4, 6, 2, 4, 6, 2, 6, 6, 4, 2, 4, 6, 2, 6, 4, 2, 4, 12, 2, 12 };
            var basePrime = 13L;
            var patternIndex = -1;

            while (n > 1)
            {
                if (basePrime * basePrime > n)
                {
                    repeats.Add(2);
                    primes.Add(n);
                    break;
                }
                else if (n % basePrime == 0)
                {
                    repeats.Add(1);
                    primes.Add(basePrime);
                    do
                    {
                        repeats[primes.Count - 1]++;
                        n /= basePrime;
                    } while (n % basePrime == 0);
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
                productOfRepeats *= (long)(0.1 + (Math.Pow(primes[i], repeats[i]) - 1) / (primes[i] - 1));
            }

            var result = productOfRepeats;

            if (aliquot)
            {
                result -= copyOfN;
            }

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


        public static BigInteger FactorialBigInteger(int n)
        {
            if (n < 21)
            {
                return FactorialLong(n);
            }

            var result = new BigInteger(9280784638125); // 20! / 2^18

            var oddPairs = BigInteger.One;
            var mid = (n - 20) >> 1;
            var start = 21L;

            var stage1 = new BigInteger[mid];

            if ((n & 1) == 1)
            {
                oddPairs = new BigInteger(21);
                start++;
            }

            for (long i = 0; i < mid; i++)
            {
                stage1[i] = BigInteger.Multiply(start + i, n - i);
            }

            var previousStage = stage1;
            var currentStage = stage1;

            while (mid > 1)
            {
                mid >>= 1;
                start = 0;

                if ((previousStage.Length & 1) == 1)
                {
                    oddPairs *= previousStage[0];
                    start = 1;
                }

                currentStage = new BigInteger[mid];

                for (int i = 0; i < mid; i++)
                {
                    currentStage[i] = BigInteger.Multiply(previousStage[start + i], previousStage[previousStage.Length - i - 1]);
                }

                previousStage = currentStage;
            }

            if (!oddPairs.IsOne)
            {
                result *= oddPairs;
            }

            if (currentStage != null && currentStage.Length > 0)
            {
                result *= currentStage[0];
            }

            return result;
        }

        public static BigInteger FactorialCustom3(int n)
        {
            if (n < 21)
            {
                return FactorialLong(n);
            }

            var minified20Fact = new BigInteger(9280784638125); // 20! / 2^18

            var result = BigInteger.One;
            var mid = n >> 1;

            for (long i = 11; i <= mid; i++)
            {
                result *= i * ((i << 1) - 1);
            }

            if ((n & 1) == 1)
            {
                result *= n;
            }

            var shifts = ((n - 20) >> 1) + 18;
            result = (result * minified20Fact) << shifts;

            return result;
        }

        public static BigInteger FactorialSplitRecursive(int n)
        {
            if (n < 2)
            {
                return FactorialLong(n);
            }

            var p = BigInteger.One;
            var r = BigInteger.One;

            int h = 0, high = 0, len = 0,  shift = 0;
            int log2n = (int)Math.Floor(Math.Log(n) / Math.Log(2));

            BigInteger currentN = BigInteger.One;

            while (h != n)
            {
                shift += h;
                h = n >> log2n--;
                len = high;
                high = (h - 1) | 1;
                len = (high - len) / 2;

                if (len > 0)
                {
                    FactorialSplitState fs = FactorialSplitProduct(len, currentN);
                    currentN = fs.current;
                    p *= fs.result;
                    r *= p;
                }
            }

            return r << shift;
        }

        private static FactorialSplitState FactorialSplitProduct(int n, BigInteger current)
        {
            int m = n / 2;
            FactorialSplitState fs;
            if (m == 0)
            {
                fs.current = current + 2;
                fs.result = fs.current;
                return fs;
            }
            if (n == 2)
            {
                fs.current = current + 4;
                fs.result = (current + 2) * fs.current;
                return fs;
            }
            fs = FactorialSplitProduct(n - m, current);
            BigInteger t = fs.result;
            fs = FactorialSplitProduct(m, fs.current);
            fs.result *= t;
            return fs;
        }

        private struct FactorialSplitState
        {
            public BigInteger result;
            public BigInteger current;
        }

        public static long FactorialLong(long n)
        {
            if (n < 21)
            {
                switch (n)
                {
                    case 0: return 1;
                    case 1: return 1;
                    case 2: return 2;
                    case 3: return 6;
                    case 4: return 24;
                    case 5: return 120;
                    case 6: return 720;
                    case 7: return 5040;
                    case 8: return 40320;
                    case 9: return 362880;
                    case 10: return 3628800;
                    case 11: return 39916800;
                    case 12: return 479001600;
                    case 13: return 6227020800;
                    case 14: return 87178291200;
                    case 15: return 1307674368000;
                    case 16: return 20922789888000;
                    case 17: return 355687428096000;
                    case 18: return 6402373705728000;
                    case 19: return 121645100408832000;
                    case 20: return 2432902008176640000;
                }
            }

            throw new OverflowException("Factortial of n > 20 cannot fit in Int64");
        }

        public static double FactorialStirling(long n)
        {
            var result = 0d;
            return result;
        }
    }
}
