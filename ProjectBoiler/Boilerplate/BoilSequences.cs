using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boilerplate
{
    public class BoilSequences
    {
        public static List<long> FibonacciSequenceUpTo(long upperlimit)
        {
            var result = new List<long>();
            if (upperlimit < 1L)
            {
                return result;
            }
            result.Add(1L);
            result.Add(1L);
            if (upperlimit < 2L)
            {
                return result;
            }

            var fib1 = 1L;
            var fib2 = 1L;
            var fib3 = fib1 + fib2;

            result.Capacity = (int)Math.Ceiling((Math.Log(upperlimit + 0.5) + 0.5 * Math.Log(5)) / Math.Log(BoilConstants.phi)) + 5; //estimate of fibonacci numbers below or equal to upperlimit

            while (fib3 <= upperlimit)
            {
                result.Add(fib3);
                fib1 = fib2;
                fib2 = fib3;
                fib3 += fib1;
            }

            return result;
        }

        public static List<long> FibonacciSequenceNth(int nth)
        {
            var result = new List<long>();
            if (nth < 1)
            {
                return result;
            }
            result.Add(1L);
            if (nth < 2)
            {
                return result;
            }
            result.Add(1L);
            if (nth < 3)
            {
                return result;
            }

            result.Capacity = nth;

            for (int i = 2; i < nth; i++)
            {
                result[i] = result[i - 1] + result[i - 2];
            }

            return result;
        }

        public static List<long> PrimesSequenceUpTo(long upperlimit)
        {
            //TODO:pre-compute index-to-num, use bitwise shifts to reduce memory footprint
            //TODO:parallelize multiples by adding cycle length
            //TODO:Cache segemented sieve

            var primes = new List<long>();
            if (upperlimit < 2)
            {
                return primes;
            }
            primes.Add(2);
            if (upperlimit < 3)
            {
                return primes;
            }
            primes.Add(3);
            if (upperlimit < 5)
            {
                return primes;
            }
            primes.Add(5);
            if (upperlimit < 7)
            {
                return primes;
            }

            byte[] pattern;
            var basePrime = 0L;

            if (upperlimit < 30000)
            {
                pattern = new byte[] { 4, 2, 4, 2, 4, 6, 2, 6 };
                basePrime = 7;
            }
            else if (upperlimit < 30000000)
            {
                primes.Add(7);
                pattern = new byte[] { 2, 4, 2, 4, 6, 2, 6, 4, 2, 4, 6, 6, 2, 6, 4, 2, 6, 4, 6, 8, 4, 2, 4, 2, 4, 8, 6, 4, 6, 2, 4, 6, 2, 6, 6, 4, 2, 4, 6, 2, 6, 4, 2, 4, 2, 10, 2, 10 };
                basePrime = 11;
            }
            else
            {
                primes.Add(7);
                primes.Add(11);
                pattern = new byte[] { 4, 2, 4, 6, 2, 6, 4, 2, 4, 6, 6, 2, 6, 4, 2, 6, 4, 6, 8, 4, 2, 4, 2, 4, 14, 4, 6, 2, 10, 2, 6, 6, 4, 2, 4, 6, 2, 10, 2, 4, 2, 12, 10, 2, 4, 2, 4, 6, 2, 6, 4, 6, 6, 6, 2, 6, 4, 2, 6, 4, 6, 8, 4, 2, 4, 6, 8, 6, 10, 2, 4, 6, 2, 6, 6, 4, 2, 4, 6, 2, 6, 4, 2, 6, 10, 2, 10, 2, 4, 2, 4, 6, 8, 4, 2, 4, 12, 2, 6, 4, 2, 6, 4, 6, 12, 2, 4, 2, 4, 8, 6, 4, 6, 2, 4, 6, 2, 6, 10, 2, 4, 6, 2, 6, 4, 2, 4, 2, 10, 2, 10, 2, 4, 6, 6, 2, 6, 6, 4, 6, 6, 2, 6, 4, 2, 6, 4, 6, 8, 4, 2, 6, 4, 8, 6, 4, 6, 2, 4, 6, 8, 6, 4, 2, 10, 2, 6, 4, 2, 4, 2, 10, 2, 10, 2, 4, 2, 4, 8, 6, 4, 2, 4, 6, 6, 2, 6, 4, 8, 4, 6, 8, 4, 2, 4, 2, 4, 8, 6, 4, 6, 6, 6, 2, 6, 6, 4, 2, 4, 6, 2, 6, 4, 2, 4, 2, 10, 2, 10, 2, 6, 4, 6, 2, 6, 4, 2, 4, 6, 6, 8, 4, 2, 6, 10, 8, 4, 2, 4, 2, 4, 8, 10, 6, 2, 4, 8, 6, 6, 4, 2, 4, 6, 2, 6, 4, 6, 2, 10, 2, 10, 2, 4, 2, 4, 6, 2, 6, 4, 2, 4, 6, 6, 2, 6, 6, 6, 4, 6, 8, 4, 2, 4, 2, 4, 8, 6, 4, 8, 4, 6, 2, 6, 6, 4, 2, 4, 6, 8, 4, 2, 4, 2, 10, 2, 10, 2, 4, 2, 4, 6, 2, 10, 2, 4, 6, 8, 6, 4, 2, 6, 4, 6, 8, 4, 6, 2, 4, 8, 6, 4, 6, 2, 4, 6, 2, 6, 6, 4, 6, 6, 2, 6, 6, 4, 2, 10, 2, 10, 2, 4, 2, 4, 6, 2, 6, 4, 2, 10, 6, 2, 6, 4, 2, 6, 4, 6, 8, 4, 2, 4, 2, 12, 6, 4, 6, 2, 4, 6, 2, 12, 4, 2, 4, 8, 6, 4, 2, 4, 2, 10, 2, 10, 6, 2, 4, 6, 2, 6, 4, 2, 4, 6, 6, 2, 6, 4, 2, 10, 6, 8, 6, 4, 2, 4, 8, 6, 4, 6, 2, 4, 6, 2, 6, 6, 6, 4, 6, 2, 6, 4, 2, 4, 2, 10, 12, 2, 4, 2, 10, 2, 6, 4, 2, 4, 6, 6, 2, 10, 2, 6, 4, 14, 4, 2, 4, 2, 4, 8, 6, 4, 6, 2, 4, 6, 2, 6, 6, 4, 2, 4, 6, 2, 6, 4, 2, 4, 12, 2, 12 };
                basePrime = 13;
            }

            primes.Capacity = (int)(upperlimit / (Math.Log(upperlimit) - 1.08366)) + 1;

            var sqrtUpperlimit = (long)Math.Sqrt(upperlimit) + 1;

            var numIndex = 0L;

            long patternLength = pattern.Length;            

            var mapIndex = new long[patternLength, patternLength];

            for (int i = 0; i < patternLength; i++)
            {
                mapIndex[i, 0] = 0;
                for (int j = 1; j < patternLength; j++)
                {
                    mapIndex[i, j] = mapIndex[i, j - 1] + pattern[(i + j - 1) % patternLength];
                }
            }

            long patternCycle = mapIndex[0, patternLength - 1] + pattern[patternLength - 1];

            var mapInverseIndex = new long[patternLength, patternCycle + 1];

            for (int i = 0; i < patternLength; i++)
            {
                for (int j = 0; j < patternLength; j++)
                {
                    mapInverseIndex[i, mapIndex[i, j]] = j;
                }
            }

            var mapAdjustment = 0;

            var upperlimitIndex = (upperlimit - basePrime) / patternCycle * patternLength;
            var upperlimitAdjust = upperlimit - (upperlimitIndex / patternLength * patternCycle + basePrime);
            for (mapAdjustment = 0; mapAdjustment < patternLength && mapIndex[0, mapAdjustment] <= upperlimitAdjust; mapAdjustment++) ;
            upperlimitIndex += mapAdjustment - 1;

            var sqrtUpperlimitIndex = (sqrtUpperlimit - basePrime) / patternCycle * patternLength;
            var sqrtUpperlimitAdjust = sqrtUpperlimit - (sqrtUpperlimitIndex / patternLength * patternCycle + basePrime);
            for (mapAdjustment = 0; mapAdjustment < patternLength && mapIndex[0, mapAdjustment] <= sqrtUpperlimitAdjust; mapAdjustment++) ;
            sqrtUpperlimitIndex += mapAdjustment - 1;

            var eliminated = new bool[upperlimitIndex + 1];

            while (numIndex <= sqrtUpperlimitIndex)
            {
                if (!eliminated[numIndex])
                {
                    var num = numIndex / patternLength * patternCycle + mapIndex[0, numIndex % patternLength] + basePrime;
                    primes.Add(num);

                    var multiple = num * num;
                    var multipleIndex = (multiple - basePrime) / patternCycle * patternLength + mapInverseIndex[0, (multiple - basePrime) % patternCycle];

                    var multiplePattern = new long[patternLength];
                    var multiplePatternIndex = 0L;
                    var multiplePatternLength = multiplePattern.Count();

                    var currBaseIndex = multipleIndex % patternLength;
                    var currPatternIndex = numIndex % patternLength;
                    var numMultiple = 0L;

                    for (int i = 0; i < multiplePatternLength; i++)
                    {
                        numMultiple = num * pattern[currPatternIndex];
                        multiplePattern[i] = numMultiple / patternCycle * patternLength + mapInverseIndex[currBaseIndex, numMultiple % patternCycle];
                        currBaseIndex = (currBaseIndex + multiplePattern[i]) % patternLength;
                        currPatternIndex = (currPatternIndex + 1) % patternLength;
                    }

                    while (multipleIndex <= upperlimitIndex)
                    {
                        eliminated[multipleIndex] = true;

                        if (multiplePatternIndex == multiplePatternLength)
                        {
                            multiplePatternIndex = 0;
                        }

                        multipleIndex += multiplePattern[multiplePatternIndex];

                        multiplePatternIndex++;
                    }
                }

                numIndex++;
            }

            while (numIndex <= upperlimitIndex)
            {
                if (!eliminated[numIndex])
                {
                    primes.Add(numIndex / patternLength * patternCycle + mapIndex[0, numIndex % patternLength] + basePrime);
                }
                numIndex++;
            }

            return primes;
        }

        public static List<long> PrimesSequenceNth(long nth)
        {
            var upperlimit = 13L;
            if (nth > 6)
            {
                upperlimit = (long)(nth * (Math.Log(nth) + Math.Log(Math.Log(nth))));
            }
             
            var primes = PrimesSequenceUpTo(upperlimit);
            while (primes.Count > nth)
            {
                primes.RemoveAt(primes.Count - 1);
            }
            return primes;
        }

        public static List<long> PrimeFactorizationWF(long n)
        {
            var factors = new List<long>();
            if (n < 2)
            {
                return factors;
            }

            var t = n;

            var smallPrimes = new long[] { 2, 3, 5, 7, 11 };
            for (int i = 0; i < smallPrimes.Length; i++)
            {
                if (t % smallPrimes[i] == 0)
                {
                    factors.Add(smallPrimes[i]);
                    do 
                    {
                        t /= smallPrimes[i];
                    } while (t % smallPrimes[i] == 0);
                }
            }

            if (t == 1)
            {
                return factors;
            }

            var pattern = new long[] { 4, 2, 4, 6, 2, 6, 4, 2, 4, 6, 6, 2, 6, 4, 2, 6, 4, 6, 8, 4, 2, 4, 2, 4, 14, 4, 6, 2, 10, 2, 6, 6, 4, 2, 4, 6, 2, 10, 2, 4, 2, 12, 10, 2, 4, 2, 4, 6, 2, 6, 4, 6, 6, 6, 2, 6, 4, 2, 6, 4, 6, 8, 4, 2, 4, 6, 8, 6, 10, 2, 4, 6, 2, 6, 6, 4, 2, 4, 6, 2, 6, 4, 2, 6, 10, 2, 10, 2, 4, 2, 4, 6, 8, 4, 2, 4, 12, 2, 6, 4, 2, 6, 4, 6, 12, 2, 4, 2, 4, 8, 6, 4, 6, 2, 4, 6, 2, 6, 10, 2, 4, 6, 2, 6, 4, 2, 4, 2, 10, 2, 10, 2, 4, 6, 6, 2, 6, 6, 4, 6, 6, 2, 6, 4, 2, 6, 4, 6, 8, 4, 2, 6, 4, 8, 6, 4, 6, 2, 4, 6, 8, 6, 4, 2, 10, 2, 6, 4, 2, 4, 2, 10, 2, 10, 2, 4, 2, 4, 8, 6, 4, 2, 4, 6, 6, 2, 6, 4, 8, 4, 6, 8, 4, 2, 4, 2, 4, 8, 6, 4, 6, 6, 6, 2, 6, 6, 4, 2, 4, 6, 2, 6, 4, 2, 4, 2, 10, 2, 10, 2, 6, 4, 6, 2, 6, 4, 2, 4, 6, 6, 8, 4, 2, 6, 10, 8, 4, 2, 4, 2, 4, 8, 10, 6, 2, 4, 8, 6, 6, 4, 2, 4, 6, 2, 6, 4, 6, 2, 10, 2, 10, 2, 4, 2, 4, 6, 2, 6, 4, 2, 4, 6, 6, 2, 6, 6, 6, 4, 6, 8, 4, 2, 4, 2, 4, 8, 6, 4, 8, 4, 6, 2, 6, 6, 4, 2, 4, 6, 8, 4, 2, 4, 2, 10, 2, 10, 2, 4, 2, 4, 6, 2, 10, 2, 4, 6, 8, 6, 4, 2, 6, 4, 6, 8, 4, 6, 2, 4, 8, 6, 4, 6, 2, 4, 6, 2, 6, 6, 4, 6, 6, 2, 6, 6, 4, 2, 10, 2, 10, 2, 4, 2, 4, 6, 2, 6, 4, 2, 10, 6, 2, 6, 4, 2, 6, 4, 6, 8, 4, 2, 4, 2, 12, 6, 4, 6, 2, 4, 6, 2, 12, 4, 2, 4, 8, 6, 4, 2, 4, 2, 10, 2, 10, 6, 2, 4, 6, 2, 6, 4, 2, 4, 6, 6, 2, 6, 4, 2, 10, 6, 8, 6, 4, 2, 4, 8, 6, 4, 6, 2, 4, 6, 2, 6, 6, 6, 4, 6, 2, 6, 4, 2, 4, 2, 10, 12, 2, 4, 2, 10, 2, 6, 4, 2, 4, 6, 6, 2, 10, 2, 6, 4, 14, 4, 2, 4, 2, 4, 8, 6, 4, 6, 2, 4, 6, 2, 6, 6, 4, 2, 4, 6, 2, 6, 4, 2, 4, 12, 2, 12 };
            var basePrime = 13L;
            var patternIndex = -1;

            //TODO: check for t == 1?
            while (!BoilMathFunctions.IsPrimeHybrid(t))
            {
                if (t % basePrime == 0)
                {
                    factors.Add(basePrime);
                    do
                    {
                        t /= basePrime;
                    } while (t % basePrime == 0);
                }

                patternIndex++;
                if (patternIndex == pattern.Length)
                {
                    patternIndex = 0;
                }

                basePrime += pattern[patternIndex];
            }

            factors.Add(t);

            return factors;
        }

        public static List<long> PrimeFactorizationWFRepeat(long n)
        {
            var factors = new List<long>();
            if (n < 2)
            {
                return factors;
            }

            var t = n;

            var smallPrimes = new long[] { 2, 3, 5, 7, 11 };
            for (int i = 0; i < smallPrimes.Length; i++)
            {
                if (t % smallPrimes[i] == 0)
                {
                    do
                    {
                        factors.Add(smallPrimes[i]);
                        t /= smallPrimes[i];
                    } while (t % smallPrimes[i] == 0);
                }
            }

            if (t == 1)
            {
                return factors;
            }

            var pattern = new long[] { 4, 2, 4, 6, 2, 6, 4, 2, 4, 6, 6, 2, 6, 4, 2, 6, 4, 6, 8, 4, 2, 4, 2, 4, 14, 4, 6, 2, 10, 2, 6, 6, 4, 2, 4, 6, 2, 10, 2, 4, 2, 12, 10, 2, 4, 2, 4, 6, 2, 6, 4, 6, 6, 6, 2, 6, 4, 2, 6, 4, 6, 8, 4, 2, 4, 6, 8, 6, 10, 2, 4, 6, 2, 6, 6, 4, 2, 4, 6, 2, 6, 4, 2, 6, 10, 2, 10, 2, 4, 2, 4, 6, 8, 4, 2, 4, 12, 2, 6, 4, 2, 6, 4, 6, 12, 2, 4, 2, 4, 8, 6, 4, 6, 2, 4, 6, 2, 6, 10, 2, 4, 6, 2, 6, 4, 2, 4, 2, 10, 2, 10, 2, 4, 6, 6, 2, 6, 6, 4, 6, 6, 2, 6, 4, 2, 6, 4, 6, 8, 4, 2, 6, 4, 8, 6, 4, 6, 2, 4, 6, 8, 6, 4, 2, 10, 2, 6, 4, 2, 4, 2, 10, 2, 10, 2, 4, 2, 4, 8, 6, 4, 2, 4, 6, 6, 2, 6, 4, 8, 4, 6, 8, 4, 2, 4, 2, 4, 8, 6, 4, 6, 6, 6, 2, 6, 6, 4, 2, 4, 6, 2, 6, 4, 2, 4, 2, 10, 2, 10, 2, 6, 4, 6, 2, 6, 4, 2, 4, 6, 6, 8, 4, 2, 6, 10, 8, 4, 2, 4, 2, 4, 8, 10, 6, 2, 4, 8, 6, 6, 4, 2, 4, 6, 2, 6, 4, 6, 2, 10, 2, 10, 2, 4, 2, 4, 6, 2, 6, 4, 2, 4, 6, 6, 2, 6, 6, 6, 4, 6, 8, 4, 2, 4, 2, 4, 8, 6, 4, 8, 4, 6, 2, 6, 6, 4, 2, 4, 6, 8, 4, 2, 4, 2, 10, 2, 10, 2, 4, 2, 4, 6, 2, 10, 2, 4, 6, 8, 6, 4, 2, 6, 4, 6, 8, 4, 6, 2, 4, 8, 6, 4, 6, 2, 4, 6, 2, 6, 6, 4, 6, 6, 2, 6, 6, 4, 2, 10, 2, 10, 2, 4, 2, 4, 6, 2, 6, 4, 2, 10, 6, 2, 6, 4, 2, 6, 4, 6, 8, 4, 2, 4, 2, 12, 6, 4, 6, 2, 4, 6, 2, 12, 4, 2, 4, 8, 6, 4, 2, 4, 2, 10, 2, 10, 6, 2, 4, 6, 2, 6, 4, 2, 4, 6, 6, 2, 6, 4, 2, 10, 6, 8, 6, 4, 2, 4, 8, 6, 4, 6, 2, 4, 6, 2, 6, 6, 6, 4, 6, 2, 6, 4, 2, 4, 2, 10, 12, 2, 4, 2, 10, 2, 6, 4, 2, 4, 6, 6, 2, 10, 2, 6, 4, 14, 4, 2, 4, 2, 4, 8, 6, 4, 6, 2, 4, 6, 2, 6, 6, 4, 2, 4, 6, 2, 6, 4, 2, 4, 12, 2, 12 };
            var basePrime = 13L;
            var patternIndex = -1;

            //TODO: check for t == 1?
            while (!BoilMathFunctions.IsPrimeHybrid(t))
            {
                if (t % basePrime == 0)
                {
                    do
                    {
                        factors.Add(basePrime);
                        t /= basePrime;
                    } while (t % basePrime == 0);
                }

                patternIndex++;
                if (patternIndex == pattern.Length)
                {
                    patternIndex = 0;
                }

                basePrime += pattern[patternIndex];
            }

            factors.Add(t);

            return factors;
        }
    }
}
