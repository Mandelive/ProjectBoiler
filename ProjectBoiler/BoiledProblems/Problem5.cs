using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Boilerplate;

namespace BoiledProblems
{
    public class Problem5 : BaseProblem
    {
        public Problem5(): base(
            5,
            @"U21hbGxlc3QgbXVsdGlwbGU=",
            @"MjUyMCBpcyB0aGUgc21hbGxlc3QgbnVtYmVyIHRoYXQgY2FuIGJlIGRpdmlkZWQgYnkgZWFjaCBvZiB0aGUgbnVtYmVycyBmcm9tIDEgdG8gMTAgd2l0aG91dCBhbnkgcmVtYWluZGVyLg0KDQpXaGF0IGlzIHRoZSBzbWFsbGVzdCBwb3NpdGl2ZSBudW1iZXIgdGhhdCBpcyBldmVubHkgZGl2aXNpYmxlIGJ5IGFsbCBvZiB0aGUgbnVtYmVycyBmcm9tIDEgdG8gMjA/DQo=",
            new string[] {
                "n:num - divisible from 1 to n"
            },
            new string[] {
                "20"
            }
        ) {}

        public override string Solve(string[] parameters)
        {
            var n = Int64.Parse(parameters[0]);
            return smallestDivisibleFrom1ToN(n).ToString();
        }

        private long smallestDivisibleFrom1ToN(long n)
        {
            if (n < 3)
            {
                return n;
            }

            var primes = BoilSequences.PrimesSequenceUpTo(n);
            var repeats = new List<int>(primes.Count);

            for (int i = 0; i < primes.Count; i++)
            {
                repeats.Add(0);
            }

            for (int i = 2; i <= n; i += 2)
            {
                var t = i;
                var c = 0;
                while ((t & 1) == 0)
                {
                    c++;
                    t >>= 1;
                }
                if (c > repeats[0])
                {
                    repeats[0] = c;
                }
            }

            for (int i = 1; i < primes.Count; i++)
            {
                for (long j = primes[i]; j <= n; j += primes[i])
                {
                    var t = j;
                    var c = 0;
                    while (t % primes[i] == 0)
                    {
                        c++;
                        t /= primes[i];
                    }
                    if (c > repeats[i])
                    {
                        repeats[i] = c;
                    }
                }
            }

            var result = 1L;

            for (int i = 0; i < primes.Count; i++)
            {
                result *= (long)Math.Pow(primes[i], repeats[i]);
            }

            return result;
        }
    }
}
