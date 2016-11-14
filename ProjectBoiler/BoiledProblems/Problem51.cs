using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Boilerplate;

namespace BoiledProblems
{
    public class Problem51 : BaseProblem
    {
        public Problem51()
        {
            Id = 51;
            Title = @"UHJpbWUgZGlnaXQgcmVwbGFjZW1lbnRz";
            Description = @"QnkgcmVwbGFjaW5nIHRoZSAxc3QgZGlnaXQgb2YgdGhlIDItZGlnaXQgbnVtYmVyICozLCBpdCB0dXJucyBvdXQgdGhhdCBzaXggb2YgdGhlIG5pbmUgcG9zc2libGUgdmFsdWVzOiAxMywgMjMsIDQzLCA1MywgNzMsIGFuZCA4MywgYXJlIGFsbCBwcmltZS4NCg0KQnkgcmVwbGFjaW5nIHRoZSAzcmQgYW5kIDR0aCBkaWdpdHMgb2YgNTYqKjMgd2l0aCB0aGUgc2FtZSBkaWdpdCwgdGhpcyA1LWRpZ2l0IG51bWJlciBpcyB0aGUgZmlyc3QgZXhhbXBsZSBoYXZpbmcgc2V2ZW4gcHJpbWVzIGFtb25nIHRoZSB0ZW4gZ2VuZXJhdGVkIG51bWJlcnMsIHlpZWxkaW5nIHRoZSBmYW1pbHk6IDU2MDAzLCA1NjExMywgNTYzMzMsIDU2NDQzLCA1NjY2MywgNTY3NzMsIGFuZCA1Njk5My4gQ29uc2VxdWVudGx5IDU2MDAzLCBiZWluZyB0aGUgZmlyc3QgbWVtYmVyIG9mIHRoaXMgZmFtaWx5LCBpcyB0aGUgc21hbGxlc3QgcHJpbWUgd2l0aCB0aGlzIHByb3BlcnR5Lg0KDQpGaW5kIHRoZSBzbWFsbGVzdCBwcmltZSB3aGljaCwgYnkgcmVwbGFjaW5nIHBhcnQgb2YgdGhlIG51bWJlciAobm90IG5lY2Vzc2FyaWx5IGFkamFjZW50IGRpZ2l0cykgd2l0aCB0aGUgc2FtZSBkaWdpdCwgaXMgcGFydCBvZiBhbiBlaWdodCBwcmltZSB2YWx1ZSBmYW1pbHku";

            parametersInfo = new string[]
            {
                "n:num - Number of repeated digits",
                "p:num - Number of possible primes"
            };

            defaultParameters = new string[]
            {
                "3",
                "8"
            };

            ResetParameters();
        }

        public override string Solve()
        {
            var n = Int32.Parse(parameters[0]);
            var p = Int32.Parse(parameters[1]);
            return findDigitReplacementPrimeFamily(n, p).ToString();
        }

        private long findDigitReplacementPrimeFamily(int n, int p)
        {
            var pattern = new byte[] { 4, 2, 4, 6, 2, 6, 4, 2, 4, 6, 6, 2, 6, 4, 2, 6, 4, 6, 8, 4, 2, 4, 2, 4, 14, 4, 6, 2, 10, 2, 6, 6, 4, 2, 4, 6, 2, 10, 2, 4, 2, 12, 10, 2, 4, 2, 4, 6, 2, 6, 4, 6, 6, 6, 2, 6, 4, 2, 6, 4, 6, 8, 4, 2, 4, 6, 8, 6, 10, 2, 4, 6, 2, 6, 6, 4, 2, 4, 6, 2, 6, 4, 2, 6, 10, 2, 10, 2, 4, 2, 4, 6, 8, 4, 2, 4, 12, 2, 6, 4, 2, 6, 4, 6, 12, 2, 4, 2, 4, 8, 6, 4, 6, 2, 4, 6, 2, 6, 10, 2, 4, 6, 2, 6, 4, 2, 4, 2, 10, 2, 10, 2, 4, 6, 6, 2, 6, 6, 4, 6, 6, 2, 6, 4, 2, 6, 4, 6, 8, 4, 2, 6, 4, 8, 6, 4, 6, 2, 4, 6, 8, 6, 4, 2, 10, 2, 6, 4, 2, 4, 2, 10, 2, 10, 2, 4, 2, 4, 8, 6, 4, 2, 4, 6, 6, 2, 6, 4, 8, 4, 6, 8, 4, 2, 4, 2, 4, 8, 6, 4, 6, 6, 6, 2, 6, 6, 4, 2, 4, 6, 2, 6, 4, 2, 4, 2, 10, 2, 10, 2, 6, 4, 6, 2, 6, 4, 2, 4, 6, 6, 8, 4, 2, 6, 10, 8, 4, 2, 4, 2, 4, 8, 10, 6, 2, 4, 8, 6, 6, 4, 2, 4, 6, 2, 6, 4, 6, 2, 10, 2, 10, 2, 4, 2, 4, 6, 2, 6, 4, 2, 4, 6, 6, 2, 6, 6, 6, 4, 6, 8, 4, 2, 4, 2, 4, 8, 6, 4, 8, 4, 6, 2, 6, 6, 4, 2, 4, 6, 8, 4, 2, 4, 2, 10, 2, 10, 2, 4, 2, 4, 6, 2, 10, 2, 4, 6, 8, 6, 4, 2, 6, 4, 6, 8, 4, 6, 2, 4, 8, 6, 4, 6, 2, 4, 6, 2, 6, 6, 4, 6, 6, 2, 6, 6, 4, 2, 10, 2, 10, 2, 4, 2, 4, 6, 2, 6, 4, 2, 10, 6, 2, 6, 4, 2, 6, 4, 6, 8, 4, 2, 4, 2, 12, 6, 4, 6, 2, 4, 6, 2, 12, 4, 2, 4, 8, 6, 4, 2, 4, 2, 10, 2, 10, 6, 2, 4, 6, 2, 6, 4, 2, 4, 6, 6, 2, 6, 4, 2, 10, 6, 8, 6, 4, 2, 4, 8, 6, 4, 6, 2, 4, 6, 2, 6, 6, 6, 4, 6, 2, 6, 4, 2, 4, 2, 10, 12, 2, 4, 2, 10, 2, 6, 4, 2, 4, 6, 6, 2, 10, 2, 6, 4, 14, 4, 2, 4, 2, 4, 8, 6, 4, 6, 2, 4, 6, 2, 6, 6, 4, 2, 4, 6, 2, 6, 4, 2, 4, 12, 2, 12 };
            int patternIndex = 0;
            long currPrime = 13;

            int maxFailures = 10 - p;
            int countPrimes = 0;
            string currKey = "";

            HashSet<string> primeFamily = new HashSet<string>();

            int[] countReps = new int[10];

            while (countPrimes < p)
            {
                long digit = 0;
                long num = currPrime;
                while (num > 0)
                {
                    digit = num % 10;
                    countReps[digit]++;
                    num /= 10;
                }

                currKey = "";
                for (int i = 0; i < 10; i++)
                {
                    if (countReps[i] == n && currKey == "")
                    {
                        currKey = currPrime.ToString().Replace((char)('0' + i), 'x');
                    }
                    countReps[i] = 0;
                }

                countPrimes = 0;
                if (currKey != ""  && !primeFamily.Contains(currKey))
                {
                    long memberNum = Int64.Parse(currKey.Replace('x', (char)('0')));
                    if (memberNum.ToString().Length == currKey.Length && BoilMathFunctions.IsPrimeHybrid(memberNum))
                    {
                        countPrimes++;
                    }
                    for (int i = 1; i < maxFailures; i++)
                    {
                        memberNum = Int64.Parse(currKey.Replace('x', (char)('0' + i)));
                        if (BoilMathFunctions.IsPrimeHybrid(memberNum))
                        {
                            countPrimes++;
                        }
                    }
                    if (countPrimes > 0)
                    {
                        for (int i = maxFailures; i < 10; i++)
                        {
                            memberNum = Int64.Parse(currKey.Replace('x', (char)('0' + i)));
                            if (BoilMathFunctions.IsPrimeHybrid(memberNum))
                            {
                                countPrimes++;
                            }
                        }
                    }
                    primeFamily.Add(currKey);
                }

                currPrime += pattern[patternIndex++];
                if (patternIndex == pattern.Length)
                {
                    patternIndex = 0;
                }
            }

            long result = 0L;
            for (int i = 0; i < 10; i++)
            {
                long memberNum = Int64.Parse(currKey.Replace('x', (char)('0' + i)));
                if (BoilMathFunctions.IsPrimeHybrid(memberNum) && memberNum.ToString().Length == currKey.Length)
                {
                    result = memberNum;
                    break;
                }
            }          

            return result;
        }

        private long findDigitReplacementPrimeFamily1(int n, int p)
        {
            var primesEnum = BoilSequences.PrimeEnumerator().GetEnumerator();
            long currPrime = primesEnum.Current;

            int maxFailures = 10 - p;
            int countPrimes = 0;
            string currKey = "";

            HashSet<string> primeFamily = new HashSet<string>();

            int[] countReps = new int[10];

            while (countPrimes < p)
            {
                long digit = 0;
                long num = currPrime;
                while (num > 0)
                {
                    digit = num % 10;
                    countReps[digit]++;
                    num /= 10;
                }

                currKey = "";
                for (int i = 0; i < 10; i++)
                {
                    if (countReps[i] == n && currKey == "")
                    {
                        currKey = currPrime.ToString().Replace((char)('0' + i), 'x');
                    }
                    countReps[i] = 0;
                }

                countPrimes = 0;
                if (currKey != "" && !primeFamily.Contains(currKey))
                {
                    long memberNum = Int64.Parse(currKey.Replace('x', (char)('0')));
                    if (memberNum.ToString().Length == currKey.Length && BoilMathFunctions.IsPrimeHybrid(memberNum))
                    {
                        countPrimes++;
                    }
                    for (int i = 1; i < maxFailures; i++)
                    {
                        memberNum = Int64.Parse(currKey.Replace('x', (char)('0' + i)));
                        if (BoilMathFunctions.IsPrimeHybrid(memberNum))
                        {
                            countPrimes++;
                        }
                    }
                    if (countPrimes > 0)
                    {
                        for (int i = maxFailures; i < 10; i++)
                        {
                            memberNum = Int64.Parse(currKey.Replace('x', (char)('0' + i)));
                            if (BoilMathFunctions.IsPrimeHybrid(memberNum))
                            {
                                countPrimes++;
                            }
                        }
                    }
                    primeFamily.Add(currKey);
                }

                primesEnum.MoveNext();
                currPrime = primesEnum.Current;
            }

            long result = 0L;
            for (int i = 0; i < 10; i++)
            {
                long memberNum = Int64.Parse(currKey.Replace('x', (char)('0' + i)));
                if (BoilMathFunctions.IsPrimeHybrid(memberNum) && memberNum.ToString().Length == currKey.Length)
                {
                    result = memberNum;
                    break;
                }
            }

            return result;
        }

        private long findDigitReplacementPrimeFamily2(int n, int p)
        {
            var primes = new HashSet<long>(BoilSequences.PrimesSequenceUpTo(1000000));
            
            var primeFamilies = new SortedSet<string>();
            foreach (var prime in primes)
            {
                var mask = maskOfFirstExactRepeatedDigit(prime, n);
                if (mask != null)
                {
                    primeFamilies.Add(mask.PadLeft(7));
                }
            }

            
            long result = -1;
            
            foreach (var family in primeFamilies)
            {
                int maxFailures = 11 - p;
                int countPrimes = 0;

                long member = Int64.Parse(family.Replace('#', (char)('0')));

                if (member.ToString().Length == family.TrimStart().Length && primes.Contains(member))
                {
                    countPrimes++;
                }
                else
                {
                    maxFailures--;
                }

                for (int i = 1; maxFailures > 0 && i < 10; i++)
                {
                    member = Int64.Parse(family.Replace('#', (char)('0' + i)));
                    if (primes.Contains(member))
                    {
                        countPrimes++;
                    }
                    else
                    {
                        maxFailures--;
                    }
                }

                if (countPrimes >= p)
                {
                    for (int i = 0; i < 10; i++)
                    {
                        member = Int64.Parse(family.Replace('#', (char)('0' + i)));
                        if (member.ToString().Length == family.TrimStart().Length && primes.Contains(member))
                        {
                            result = member;
                            break;
                        }
                    }
                    break;
                }
            }

            return result;
        }

        private string maskOfFirstExactRepeatedDigit(long n, int r)
        {
            var countDigits = new int[10];
            long num = n;

            long digit = 0;
            while (n > 0)
            {
                digit = n % 10;
                countDigits[digit]++;
                n /= 10;
            }

            for (int i = 0; i < 10; i++)
            {
                if (countDigits[i] == r)
                {
                    return num.ToString().Replace((char)('0' + i),'#');
                }
            }
            return null;
        }
    }
}
