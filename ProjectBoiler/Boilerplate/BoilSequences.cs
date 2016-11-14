using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boilerplate
{
    public class BoilSequences
    {
        static readonly byte[] primeWF13 = new byte[] { 4, 2, 4, 6, 2, 6, 4, 2, 4, 6, 6, 2, 6, 4, 2, 6, 4, 6, 8, 4, 2, 4, 2, 4, 14, 4, 6, 2, 10, 2, 6, 6, 4, 2, 4, 6, 2, 10, 2, 4, 2, 12, 10, 2, 4, 2, 4, 6, 2, 6, 4, 6, 6, 6, 2, 6, 4, 2, 6, 4, 6, 8, 4, 2, 4, 6, 8, 6, 10, 2, 4, 6, 2, 6, 6, 4, 2, 4, 6, 2, 6, 4, 2, 6, 10, 2, 10, 2, 4, 2, 4, 6, 8, 4, 2, 4, 12, 2, 6, 4, 2, 6, 4, 6, 12, 2, 4, 2, 4, 8, 6, 4, 6, 2, 4, 6, 2, 6, 10, 2, 4, 6, 2, 6, 4, 2, 4, 2, 10, 2, 10, 2, 4, 6, 6, 2, 6, 6, 4, 6, 6, 2, 6, 4, 2, 6, 4, 6, 8, 4, 2, 6, 4, 8, 6, 4, 6, 2, 4, 6, 8, 6, 4, 2, 10, 2, 6, 4, 2, 4, 2, 10, 2, 10, 2, 4, 2, 4, 8, 6, 4, 2, 4, 6, 6, 2, 6, 4, 8, 4, 6, 8, 4, 2, 4, 2, 4, 8, 6, 4, 6, 6, 6, 2, 6, 6, 4, 2, 4, 6, 2, 6, 4, 2, 4, 2, 10, 2, 10, 2, 6, 4, 6, 2, 6, 4, 2, 4, 6, 6, 8, 4, 2, 6, 10, 8, 4, 2, 4, 2, 4, 8, 10, 6, 2, 4, 8, 6, 6, 4, 2, 4, 6, 2, 6, 4, 6, 2, 10, 2, 10, 2, 4, 2, 4, 6, 2, 6, 4, 2, 4, 6, 6, 2, 6, 6, 6, 4, 6, 8, 4, 2, 4, 2, 4, 8, 6, 4, 8, 4, 6, 2, 6, 6, 4, 2, 4, 6, 8, 4, 2, 4, 2, 10, 2, 10, 2, 4, 2, 4, 6, 2, 10, 2, 4, 6, 8, 6, 4, 2, 6, 4, 6, 8, 4, 6, 2, 4, 8, 6, 4, 6, 2, 4, 6, 2, 6, 6, 4, 6, 6, 2, 6, 6, 4, 2, 10, 2, 10, 2, 4, 2, 4, 6, 2, 6, 4, 2, 10, 6, 2, 6, 4, 2, 6, 4, 6, 8, 4, 2, 4, 2, 12, 6, 4, 6, 2, 4, 6, 2, 12, 4, 2, 4, 8, 6, 4, 2, 4, 2, 10, 2, 10, 6, 2, 4, 6, 2, 6, 4, 2, 4, 6, 6, 2, 6, 4, 2, 10, 6, 8, 6, 4, 2, 4, 8, 6, 4, 6, 2, 4, 6, 2, 6, 6, 6, 4, 6, 2, 6, 4, 2, 4, 2, 10, 12, 2, 4, 2, 10, 2, 6, 4, 2, 4, 6, 6, 2, 10, 2, 6, 4, 14, 4, 2, 4, 2, 4, 8, 6, 4, 6, 2, 4, 6, 2, 6, 6, 4, 2, 4, 6, 2, 6, 4, 2, 4, 12, 2, 12 };

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

            if (upperlimit > 4)
            {
                primes.AddRange(new long[] { 2, 3, 5 });
            }
            else
            {
                if (upperlimit > 2)
                {
                    primes.AddRange(new long[] { 2, 3 });
                }
                else if (upperlimit > 1)
                {
                    primes.Add(2);
                }
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
                pattern = primeWF13;
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

        public static List<long> PrimesSequenceNth(int nth)
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

            if ((n & 1) == 0)
            {
                factors.Add(2);
                do { n >>= 1; } while ((n & 1) == 0);
            }
            if (n % 3 == 0) 
            {
                factors.Add(3);
                do { n /= 3; } while (n % 3 == 0);
            }
            if (n % 5 == 0)
            {
                factors.Add(5);
                do { n /= 5; } while (n % 5 == 0);
            }
            if (n % 7 == 0)
            {
                factors.Add(7);
                do { n /= 7; } while (n % 7 == 0);
            }
            if (n % 11 == 0)
            {
                factors.Add(11);
                do { n /= 11; } while (n % 11 == 0);
            }

            if (n == 1)
            {
                return factors;
            }

            if (factors.Count == 0 && n > 1000000 && BoilMathFunctions.IsPrimeHybrid(n))
            {
                factors.Add(n);
                return factors;
            }

            var semiPrime = 13L;
            var patternIndex = -1;
            var nsqrt = (long)(Math.Sqrt(n));

            for (int i = 0; i < 2; i++)
            {
                while (semiPrime <= nsqrt)
                {
                    if (n % semiPrime == 0)
                    {
                        factors.Add(semiPrime);
                        do { n /= semiPrime; } while (n % semiPrime == 0);
                        if (n < semiPrime)
                        {
                            break;
                        }
                    }

                    patternIndex++;
                    if (patternIndex == primeWF13.Length)
                    {
                        patternIndex = 0;
                    }

                    semiPrime += primeWF13[patternIndex];
                }

                if (factors.Count == 0)
                {
                    factors.Add(n);
                    return factors;
                }

                nsqrt = (long)(Math.Sqrt(n));                
            }

            if (n > 1)
            {
                factors.Add(n);
            }

            return factors;
        }

        public static IEnumerable<long> PrimeEnumerator(int nth = 1)
        {
            var initialPrimes = new int[] { 2, 3, 5, 7, 11, 13 };

            for (int i = nth - 1; i < initialPrimes.Length; i++)
            {
                yield return initialPrimes[i];
            }

            var semiPrime = 13L;
            var patternIndex = 0;

            nth -= initialPrimes.Length;
            while (nth > 1)
            {
                semiPrime += primeWF13[patternIndex++];

                if (patternIndex == primeWF13.Length)
                {
                    patternIndex = 0;
                }

                if (BoilMathFunctions.IsPrimeHybrid(semiPrime))
                {
                    nth--;
                }
            }

            while (true)
            {
                semiPrime += primeWF13[patternIndex++];

                if (patternIndex == primeWF13.Length)
                {
                    patternIndex = 0;
                }

                if (BoilMathFunctions.IsPrimeHybrid(semiPrime))
                {
                    yield return semiPrime;
                }
            }
        }

        public static IEnumerable<string> PermutationsEnumerator(string numstr, int nth = 1)
        {
            var elements = numstr.ToCharArray();
            var count = elements.Length;

            bool done;

            if (nth == 1)
            {
                yield return new string(elements);
            }
            else
            {
                while (nth > 2)
                {
                    for (int i = count - 1; i > 0; i--)
                    {
                        var curr = elements[i];

                        if (curr < elements[i - 1])
                        {
                            continue;
                        }

                        var prev = elements[i - 1];

                        var currIndex = i;

                        for (var j = i + 1; j < count; j++)
                        {
                            var temp = elements[j];

                            if (temp < curr && temp > prev)
                            {
                                curr = temp;
                                currIndex = j;
                            }
                        }

                        elements[currIndex] = prev;
                        elements[i - 1] = curr;

                        for (var j = count - 1; j > i; j--, i++)
                        {
                            var temp = elements[j];
                            elements[j] = elements[i];
                            elements[i] = temp;
                        }

                        nth--;
                        break;
                    }
                }
            }

            do
            {
                done = true;
                for (int i = count - 1; i > 0; i--)
                {
                    var curr = elements[i];

                    if (curr < elements[i - 1])
                    {
                        continue;
                    }

                    done = false;

                    var prev = elements[i - 1];

                    var currIndex = i;

                    for (var j = i + 1; j < count; j++)
                    {
                        var temp = elements[j];

                        if (temp < curr && temp > prev)
                        {
                            curr = temp;
                            currIndex = j;
                        }
                    }

                    elements[currIndex] = prev;
                    elements[i - 1] = curr;

                    for (var j = count - 1; j > i; j--, i++)
                    {
                        var temp = elements[j];
                        elements[j] = elements[i];
                        elements[i] = temp;
                    }

                    yield return new string(elements);
                    break;
                }

            } while (!done);
        }
    }
}
