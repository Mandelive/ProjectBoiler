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
            //TODO: Implement better exponentiation methods and benchmark
            var result = 1L;
            b = b % n;

            while (e > 0)
            {
                if ((e & 1) != 0)
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

        public static long LcmPrimeFactorization(IEnumerable<long> nums)
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

        public static long LeastPrimeFactor(long n)
        {
            //TODO: TEST IT!
            if (n < 2)
            {
                return n;
            }

            if ((n & 1) == 0) return 2;
            if (n % 3 == 0) return 3;
            if (n % 5 == 0) return 5;
            if (n % 7 == 0) return 7;
            if (n % 11 == 0) return 11;

            if (n > 1000000 && BoilMathFunctions.IsPrimeHybrid(n))
            {
                return n;
            }

            var pattern = new byte[] { 4, 2, 4, 6, 2, 6, 4, 2, 4, 6, 6, 2, 6, 4, 2, 6, 4, 6, 8, 4, 2, 4, 2, 4, 14, 4, 6, 2, 10, 2, 6, 6, 4, 2, 4, 6, 2, 10, 2, 4, 2, 12, 10, 2, 4, 2, 4, 6, 2, 6, 4, 6, 6, 6, 2, 6, 4, 2, 6, 4, 6, 8, 4, 2, 4, 6, 8, 6, 10, 2, 4, 6, 2, 6, 6, 4, 2, 4, 6, 2, 6, 4, 2, 6, 10, 2, 10, 2, 4, 2, 4, 6, 8, 4, 2, 4, 12, 2, 6, 4, 2, 6, 4, 6, 12, 2, 4, 2, 4, 8, 6, 4, 6, 2, 4, 6, 2, 6, 10, 2, 4, 6, 2, 6, 4, 2, 4, 2, 10, 2, 10, 2, 4, 6, 6, 2, 6, 6, 4, 6, 6, 2, 6, 4, 2, 6, 4, 6, 8, 4, 2, 6, 4, 8, 6, 4, 6, 2, 4, 6, 8, 6, 4, 2, 10, 2, 6, 4, 2, 4, 2, 10, 2, 10, 2, 4, 2, 4, 8, 6, 4, 2, 4, 6, 6, 2, 6, 4, 8, 4, 6, 8, 4, 2, 4, 2, 4, 8, 6, 4, 6, 6, 6, 2, 6, 6, 4, 2, 4, 6, 2, 6, 4, 2, 4, 2, 10, 2, 10, 2, 6, 4, 6, 2, 6, 4, 2, 4, 6, 6, 8, 4, 2, 6, 10, 8, 4, 2, 4, 2, 4, 8, 10, 6, 2, 4, 8, 6, 6, 4, 2, 4, 6, 2, 6, 4, 6, 2, 10, 2, 10, 2, 4, 2, 4, 6, 2, 6, 4, 2, 4, 6, 6, 2, 6, 6, 6, 4, 6, 8, 4, 2, 4, 2, 4, 8, 6, 4, 8, 4, 6, 2, 6, 6, 4, 2, 4, 6, 8, 4, 2, 4, 2, 10, 2, 10, 2, 4, 2, 4, 6, 2, 10, 2, 4, 6, 8, 6, 4, 2, 6, 4, 6, 8, 4, 6, 2, 4, 8, 6, 4, 6, 2, 4, 6, 2, 6, 6, 4, 6, 6, 2, 6, 6, 4, 2, 10, 2, 10, 2, 4, 2, 4, 6, 2, 6, 4, 2, 10, 6, 2, 6, 4, 2, 6, 4, 6, 8, 4, 2, 4, 2, 12, 6, 4, 6, 2, 4, 6, 2, 12, 4, 2, 4, 8, 6, 4, 2, 4, 2, 10, 2, 10, 6, 2, 4, 6, 2, 6, 4, 2, 4, 6, 6, 2, 6, 4, 2, 10, 6, 8, 6, 4, 2, 4, 8, 6, 4, 6, 2, 4, 6, 2, 6, 6, 6, 4, 6, 2, 6, 4, 2, 4, 2, 10, 12, 2, 4, 2, 10, 2, 6, 4, 2, 4, 6, 6, 2, 10, 2, 6, 4, 14, 4, 2, 4, 2, 4, 8, 6, 4, 6, 2, 4, 6, 2, 6, 6, 4, 2, 4, 6, 2, 6, 4, 2, 4, 12, 2, 12 };
            var semiPrime = 13L;
            var patternIndex = -1;
            var nsqrt = (long)(Math.Sqrt(n));

            while (semiPrime <= nsqrt)
            {
                if (n % semiPrime == 0)
                {
                    return semiPrime;
                }

                patternIndex++;
                if (patternIndex == pattern.Length)
                {
                    patternIndex = 0;
                }

                semiPrime += pattern[patternIndex];
            }

            return n;
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
            if (n < 2704)
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
            var minified20Factorial = new BigInteger(9280784638125); // 20! / 2^18
            var result = BigInteger.One;

            var oddPairs = BigInteger.One;
            var mid = (n - 20) >> 1;
            var start = 21L;

            var stage1 = new BigInteger[mid];

            if ((n & 1) != 0)
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

                if ((previousStage.Length & 1) != 0)
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

            result *= minified20Factorial;

            return result;
        }

        public static BigInteger FactorialBigInteger2(int n)
        {
            if (n < 21)
            {
                return FactorialLong(n);
            }

            var minified20Fact = new BigInteger(9280784638125); // 20! / 2^18

            var result = BigInteger.One;

            var oddPairs = BigInteger.One;
            long upperTerm = n - 1;

            if ((n & 1) != 0)
            {
                oddPairs = n;
                upperTerm--;
            }

            int index = 0;
            int count = (n >> 1) - 10;
            long mid = n >> 1;
           
            var stage = new BigInteger[count];

            for (long i = 11; i <= mid; i++)
            {
                stage[index] = i * upperTerm;
                index++;
                upperTerm -= 2L;
            }

            while (count > 1)
            {
                int upperIndex = count - 1;

                if ((count & 1) != 0)
                {
                    oddPairs *= stage[upperIndex];
                    upperIndex--;
                }

                count >>= 1;

                var previousStage = stage;
                stage = new BigInteger[count];

                for (int i = 0; i < count; i++)
                {
                    stage[i] = previousStage[i] * previousStage[upperIndex];
                    upperIndex--;
                }
            }

            for (int i = 0; i < stage.Length; i++)
            {
                result *= stage[i];
            }

            //if (stage.Length > 0)
            //{
            //    result = stage[0];
            //}

            if (!oddPairs.IsOne)
            {
                result *= oddPairs;
            }
            
            var shifts = ((n - 20) >> 1) + 18;
            result = (result * minified20Fact) << shifts;

            return result;
        }

        public static BigInteger FactorialBigInteger3(int n)
        {
            if (n < 21)
            {
                return FactorialLong(n);
            }

            var minified20Fact = new BigInteger(9280784638125); // 20! / 2^18

            var result = BigInteger.One;

            var oddPairs = BigInteger.One;
            long upperTerm = n - 1;

            if ((n & 1) != 0)
            {
                oddPairs = n;
                upperTerm--;
            }

            int index = 0;
            int count = (n >> 1) - 10;
            long mid = n >> 1;

            var stage = new BigInteger[count];

            for (long i = 11; i <= mid; i++)
            {
                stage[index] = i * upperTerm;
                index++;
                upperTerm -= 2L;
            }

            while (count > 1)
            {
                if ((count & 1) != 0)
                {
                    oddPairs *= stage.Last();
                }

                count >>= 1;

                int downwards = count - 1;
                int upwards = count;

                var previousStage = stage;
                stage = new BigInteger[count];

                for (int i = 0; i < count; i++)
                {
                    stage[i] = previousStage[downwards--] * previousStage[upwards++];
                }
            }

            for (int i = 0; i < stage.Length; i++)
            {
                result *= stage[i];
            }

            if (!oddPairs.IsOne)
            {
                result *= oddPairs;
            }

            var shifts = ((n - 20) >> 1) + 18;
            result = (result * minified20Fact) << shifts;

            return result;
        }
        
        public static BigInteger FactorialCustom5(int n)
        {
            if (n < 21)
            {
                return FactorialLong(n);
            }

            var minified20Fact = new BigInteger(9280784638125); // 20! / 2^18

            var result = BigInteger.One;
            long mid = n >> 1;

            long upperTerm = ((n & 1) == 0 ? n - 1 : n);

            for (long i = 11; i <= mid; i++)
            {
                result *= i * upperTerm;
                upperTerm -= 2;
            }

            if ((n & 1) != 0)
            {
                result *= upperTerm;
            }

            var shifts = ((n - 20) >> 1) + 18;
            result = (result * minified20Fact) << shifts;

            return result;
        }

        public static BigInteger FactorialCustom6(int n)
        {
            if (n < 21)
            {
                return FactorialLong(n);
            }

            var minified20Fact = new BigInteger(9280784638125); // 20! / 2^18

            var result = BigInteger.One;
            if ((n & 1) != 0)
            {
                result = n;
            }

            long mid = n >> 1;
            var count = mid - 10;

            long downwards = mid;
            long upwards = 21L;

            for (int i = 0; i < count; i++)
            {
                result *= upwards * downwards;
                upwards += 2L;
                downwards--;
            }

            var shifts = ((n - 20) >> 1) + 18;
            result = (result * minified20Fact) << shifts;

            return result;
        }

        public static BigInteger FactorialCustom7(int n)
        {
            //TODO: Same as Custom6 but without using minified20Fact
            if (n < 21)
            {
                return FactorialLong(n);
            }

            var result = BigInteger.One;
            if ((n & 1) != 0)
            {
                result = n;
            }
            // 10! = 1 * 3 * 2 * 5 * 3 * 7 * 4 * 9 * 5
            // 2 * 3 * 4 * 5 * 6  * 7  * 8  * 9
            // 3 * 5 * 7 * 9 * 11 * 13 * 15 * 17
            // 
            // 10 / 2 = 5

            long mid = n >> 1;
            var count = mid;

            long downwardsA = mid;
            long upwardsA = downwardsA + 2;
            long downwardsB = (mid + 1) >> 1;
            long upwardsB = downwardsB + 1;
            
            for (int i = 0; i < count; i++)
            {
                result *= downwardsA * upwardsB;
                result *= downwardsB * upwardsA;
                downwardsA -= 2L;
                downwardsB--;
                upwardsA += 2L;
                upwardsB++;
            }

            var shifts = (n >> 1);
            result = result << shifts;

            return result;
        }

        public static BigInteger FactorialCustom12(int n)
        {
            if (n < 21)
            {
                return FactorialLong(n);
            }

            var segmentEnds = new List<int>();
            var segmentStarts = new List<int>();
            var evenTerms = new List<int>();
            var shifts = 0;

            do
            {
                if ((n & 1) == 0)
                {
                    evenTerms.Add(n >> 1);
                    n--;
                }
                segmentEnds.Add(n);
                n >>= 1;
                segmentStarts.Add(n + 1 + (n & 1));
                shifts += n;
            } while (n > 20);

            shifts += evenTerms.Count;
            var evenTermsMult = BigInteger.One;
            for (int i = 0; i < evenTerms.Count; i++)
            {
                evenTermsMult *= evenTerms[i];
            }

            var baselineFactorial = FactorialLong(n);
            while ((baselineFactorial & 1) == 0)
            {
                baselineFactorial >>= 1;
                shifts++;
            }

            long lowerTerm = 3L;
            var lowerRepeats = segmentStarts.Count;
            var lowerCounter = 0;
            long upperTerm = segmentEnds.First();
            var upperRepeats = 1;
            var upperCounter = 0;
            var result = BigInteger.One;

            while (lowerTerm < upperTerm)
            {
                result *= lowerTerm * upperTerm;
                lowerCounter++;
                upperCounter++;

                if (lowerCounter == lowerRepeats)
                {
                    lowerCounter = 0;
                    lowerTerm += 2;
                    if (lowerTerm > segmentEnds[lowerRepeats - 1])
                    {
                        lowerRepeats--;
                    }
                }

                if (upperCounter == upperRepeats)
                {
                    upperCounter = 0;
                    upperTerm -= 2;
                    if (upperTerm < segmentStarts[upperRepeats - 1])
                    {
                        upperRepeats++;
                    }
                }
            }
            
            if (lowerTerm == upperTerm)
            {
                if (lowerCounter == 0)
                {
                    result *= BigInteger.Pow(upperTerm, upperRepeats - upperCounter);
                }
                else
                {
                    result *= BigInteger.Pow(lowerTerm, lowerRepeats - lowerCounter);
                }
            }

            result *= evenTermsMult * baselineFactorial;

            result <<= shifts;

            return result;
        }

        public static BigInteger FactorialPrimeFactoriazation(int n)
        {
            if (n < 21)
            {
                return FactorialLong(n);
            }

            var primes = BoilSequences.PrimesSequenceUpTo(n);
            var exponents = new int[primes.Count];

            var oddTerms = BigInteger.One;
            var result = BigInteger.One;
            
            for (int i = primes.Count - 1; i >= 1; i--)
            {
                var num = n;
                while (num > 0)
                {
                    num /= (int)primes[i];
                    exponents[i] += num;
                }
                var mod3 = exponents[i] % 3;
                if (mod3 > 0)
                {
                    oddTerms *= BigInteger.Pow(primes[i], mod3);
                }
                result *= BigInteger.Pow(primes[i] * primes[i] * primes[i], exponents[i] / 3);
            }

            var shifts = 0;
            while (n > 0)
            {
                n >>= 1;
                shifts += n;
            }

            //var lowerIndex = 1;
            //var lowerCounter = 0;
            //long lowerTerm = primes[lowerIndex];
            //var upperIndex = primes.Count - 1;
            //var upperCounter = 0;
            //long upperTerm = primes[upperIndex];

            //while (lowerIndex < upperIndex)
            //{
            //    result *= lowerTerm * upperTerm;
            //    lowerCounter++;
            //    upperCounter++;

            //    if (lowerCounter == exponents[lowerIndex])
            //    {
            //        lowerCounter = 0;
            //        lowerIndex++;
            //        lowerTerm = primes[lowerIndex];
            //    }

            //    if (upperCounter == exponents[upperIndex])
            //    {
            //        upperCounter = 0;
            //        upperIndex--;
            //        upperTerm = primes[upperIndex];
            //    }
            //}

            //if (lowerTerm == upperTerm)
            //{
            //    if (lowerCounter == 0)
            //    {
            //        result *= BigInteger.Pow(upperTerm, exponents[upperIndex] - upperCounter);
            //    }
            //    else
            //    {
            //        result *= BigInteger.Pow(lowerTerm, exponents[lowerIndex] - lowerCounter);
            //    }
            //}

            result *= oddTerms;
            result <<= shifts;

            return result;            
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

        public static BigInteger DoubleFactorialBigInteger(int n)
        {
            if (n < 34)
            {
                return DoubleFactorialLong(n);
            }
            else if ((n & 1) == 0)
            {
                throw new ArgumentException("Double Factorial function does not support even numbers");
            }

            var result = (BigInteger)n;
            var upperTerm = (long)n - 2;
            var lowerTerm = 3L;

            while (lowerTerm < upperTerm)
            {
                result *= lowerTerm * upperTerm;
                lowerTerm += 2;
                upperTerm -= 2;
            }

            if (lowerTerm == upperTerm)
            {
                result *= lowerTerm;
            }

            return result;
        }

        public static BigInteger DoubleFactorialBigInteger(int n, int r)
        {
            if (r < 3)
            {
                return DoubleFactorialBigInteger(n);
            }

            if (n < 34)
            {
                return DoubleFactorialLong(n) / DoubleFactorialLong(r);
            }
            else if ((n & 1) == 0 || (r & 1) == 0)
            {
                throw new ArgumentException("Double Factorial function does not support even numbers");
            }

            var result = (BigInteger)n;
            var upperTerm = (long)n - 2;
            var lowerTerm = (long)r;

            while (lowerTerm < upperTerm)
            {
                result *= lowerTerm * upperTerm;
                lowerTerm += 2;
                upperTerm -= 2;
            }

            if (lowerTerm == upperTerm)
            {
                result *= lowerTerm;
            }

            return result;
        }

        public static long DoubleFactorialLong(int n)
        {
            if (n < 34)
            {
                switch (n)
                {
                    case 1: return 1;
                    case 3: return 3;
                    case 5: return 15;
                    case 7: return 105;
                    case 9: return 945;
                    case 11: return 10395;
                    case 13: return 135135;
                    case 15: return 2027025;
                    case 17: return 34459425;
                    case 19: return 654729075;
                    case 21: return 13749310575;
                    case 23: return 316234143225;
                    case 25: return 7905853580625;
                    case 27: return 213458046676875;
                    case 29: return 6190283353629375;
                    case 31: return 191898783962510625;
                    case 33: return 6332659870762850625;
                }
            }

            throw new OverflowException("Double Factortial of n > 33 cannot fit in Int64");
        }

        public static double FactorialStirling(long n)
        {
            if (n < 21)
            {
                return FactorialLong(n);
            }

            throw new NotImplementedException("TODO: FacotiralStirling");
        }

        public static double FactorialStieltjes(long n)
        {
            if (n < 21)
            {
                return FactorialLong(n);
            }

            double a0 = 1.0 / 12.0;
            double a1 = 1.0 / 30.0;
            double a2 = 53.0 / 210.0;
            double a3 = 195.0 / 371.0;
            double a4 = 22999.0 / 22737.0;
            double a5 = 29944523.0 / 19733142.0;
            double a6 = 109535241009.0 / 48264275462.0;
            double N = n + 1;

            var result = 0.5 * Math.Log(2 * BoilConstants.pi) + (N - 0.5) * Math.Log(N) - N + a0 / (N + a1 / (N + a2 / (N + a3 / (N + a4 / (N + a5 / (N + a6 / N))))));
            result = Math.Exp(result);

            return result;
        }

        public static long ExpLinear(long n, int e)
        {
            switch (e)
            {
                case 0: return 1L;
                case 1: return n;
            }

            var result = 1L;
            for (int i = 0; i < e; i++)
            {
                result *= n;
            }
            return result;
        }

        public static long ExpBinary(long n, int e)
        {
            switch (e)
            {
                case 0: return 1L;
                case 1: return n;
            }
            
            var result = 1L;

            if (n < 0)
            {
                n = -n;
                if ((e & 1) != 0)
                {
                    result = -1L;
                }
            }

            var power2 = n;

            while (e > 0)
            {
                if ((e & 1) != 0)
                {
                    result *= power2;
                }
                power2 *= power2;
                e >>= 1;
            }

            return result;
        }

        public static double DivideBigIntegersDouble(BigInteger a, BigInteger b)
        {
            var result = Math.Exp(BigInteger.Log(a) - BigInteger.Log(b));
            return result;
        }
        
        public static int MaxExponent(long b)
        {
            if (b < 0) b = -b;
            if (b < 2) return Int32.MaxValue;
            if (b < 10)
            {
                switch (b)
                {
                    case 2: return 62;
                    case 3: return 39;
                    case 4: return 31;
                    case 5: return 27;
                    case 6: return 24;
                    case 7: return 22;
                    case 8: return 20;
                    case 9: return 19;
                }
            }
            else if (b < 79)
            {
                if (b < 12) return 18;
                if (b < 14) return 17;
                if (b < 16) return 16;
                if (b < 19) return 15;
                if (b < 23) return 14;
                if (b < 29) return 13;
                if (b < 39) return 12;
                if (b < 53) return 11;
                return 10;
            }
            else
            {
                if (b > 3037000499) return 1;
                if (b > 2097151) return 2;
                if (b > 55108) return 3;
                if (b > 6208) return 4;
                if (b > 1448) return 5;
                if (b > 511) return 6;
                if (b > 234) return 7;
                if (b > 127) return 8;
                return 9;
            }

            return 1;
        }

        public static int MaxExponent2(long b)
        {
            if (b < 0) b = -b;
            if (b < 2) return Int32.MaxValue;
            if (b > 3037000499) return 1;

            if (b > 511)
            {
                if (b > 2097151) return 2;
                if (b > 55108) return 3;
                if (b > 6208) return 4;
                if (b > 1448) return 5;
                return 6;
            }
            else
            {
                if (b > 78)
                {
                    if (b > 234) return 7;
                    if (b > 127) return 8;
                    return 9;
                }
                else
                {
                    if (b > 11)
                    {
                        if (b > 22)
                        {
                            if (b > 52) return 10;
                            if (b > 38) return 11;
                            if (b > 28) return 12;
                            return 13;
                        }
                        else
                        {
                            if (b > 18) return 14;
                            if (b > 15) return 15;
                            if (b > 13) return 16;
                            return 17;
                        }
                    }
                    else
                    {
                        if (b > 5)
                        {
                            if (b > 9) return 18;
                            if (b == 9) return 19;
                            if (b == 8) return 20;
                            if (b == 7) return 22;
                            return 24;   
                        }
                        else
                        {
                            if (b == 5) return 27;
                            if (b == 4) return 31;
                            if (b == 3) return 39;
                            return 62;
                        }
                    }
                }
            }
        }
    }
}
