using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Numerics;
using Microsoft.VisualBasic.FileIO;
using Boilerplate;


namespace BoiledProblems
{
    public class Problem23 : BaseProblem
    {
        public Problem23()
        {
            Id = 23;
            Title = @"Tm9uLWFidW5kYW50IHN1bXM=";
            Description = @"QSBwZXJmZWN0IG51bWJlciBpcyBhIG51bWJlciBmb3Igd2hpY2ggdGhlIHN1bSBvZiBpdHMgcHJvcGVyIGRpdmlzb3JzIGlzIGV4YWN0bHkgZXF1YWwgdG8gdGhlIG51bWJlci4gRm9yIGV4YW1wbGUsIHRoZSBzdW0gb2YgdGhlIHByb3BlciBkaXZpc29ycyBvZiAyOCB3b3VsZCBiZSAxICsgMiArIDQgKyA3ICsgMTQgPSAyOCwgd2hpY2ggbWVhbnMgdGhhdCAyOCBpcyBhIHBlcmZlY3QgbnVtYmVyLg0KDQpBIG51bWJlciBuIGlzIGNhbGxlZCBkZWZpY2llbnQgaWYgdGhlIHN1bSBvZiBpdHMgcHJvcGVyIGRpdmlzb3JzIGlzIGxlc3MgdGhhbiBuIGFuZCBpdCBpcyBjYWxsZWQgYWJ1bmRhbnQgaWYgdGhpcyBzdW0gZXhjZWVkcyBuLg0KDQpBcyAxMiBpcyB0aGUgc21hbGxlc3QgYWJ1bmRhbnQgbnVtYmVyLCAxICsgMiArIDMgKyA0ICsgNiA9IDE2LCB0aGUgc21hbGxlc3QgbnVtYmVyIHRoYXQgY2FuIGJlIHdyaXR0ZW4gYXMgdGhlIHN1bSBvZiB0d28gYWJ1bmRhbnQgbnVtYmVycyBpcyAyNC4gQnkgbWF0aGVtYXRpY2FsIGFuYWx5c2lzLCBpdCBjYW4gYmUgc2hvd24gdGhhdCBhbGwgaW50ZWdlcnMgZ3JlYXRlciB0aGFuIDI4MTIzIGNhbiBiZSB3cml0dGVuIGFzIHRoZSBzdW0gb2YgdHdvIGFidW5kYW50IG51bWJlcnMuIEhvd2V2ZXIsIHRoaXMgdXBwZXIgbGltaXQgY2Fubm90IGJlIHJlZHVjZWQgYW55IGZ1cnRoZXIgYnkgYW5hbHlzaXMgZXZlbiB0aG91Z2ggaXQgaXMga25vd24gdGhhdCB0aGUgZ3JlYXRlc3QgbnVtYmVyIHRoYXQgY2Fubm90IGJlIGV4cHJlc3NlZCBhcyB0aGUgc3VtIG9mIHR3byBhYnVuZGFudCBudW1iZXJzIGlzIGxlc3MgdGhhbiB0aGlzIGxpbWl0Lg0KDQpGaW5kIHRoZSBzdW0gb2YgYWxsIHRoZSBwb3NpdGl2ZSBpbnRlZ2VycyB3aGljaCBjYW5ub3QgYmUgd3JpdHRlbiBhcyB0aGUgc3VtIG9mIHR3byBhYnVuZGFudCBudW1iZXJzLg0K";

            parametersInfo = new string[]
            {
                
            };

            defaultParameters = new string[]
            {
                
            };

            ResetParameters();
        }

        public override string Solve()
        {
            return findSumOfIntegersNotEqualToSumOfTwoAbundants().ToString();
        }

        private long findSumOfIntegersNotEqualToSumOfTwoAbundants()
        {
            var upperlimit = 20162;

            var abundantNumbers = new List<int>(upperlimit / 3);

            var spider = new List<int>[System.Environment.ProcessorCount];
            for (int i = 0; i < spider.Length; i++)
            {
                spider[i] = new List<int>(100);
            }

            var interval = upperlimit / spider.Length;

            Parallel.For(0, spider.Length, s =>
            {
                var index = s;
                for (int i = index * interval + 1; i < (index + 1) * interval; i++)
                {
                    if (i < BoilMathFunctions.DivisorSigma1(i, true))
                    {
                        spider[index].Add(i);
                    }
                }
            });

            for (int i = 0; i < spider.Length; i++)
            {
                abundantNumbers.AddRange(spider[i]);
            }

            var sumOfTwoAbundants = new bool[upperlimit];

            Parallel.For(0, abundantNumbers.Count, i =>
            {
                for (int j = i; j < abundantNumbers.Count; j++)
                {
                    var sum = abundantNumbers[i] + abundantNumbers[j];
                    if (sum >= upperlimit)
                    {
                        break;
                    }
                    else
                    {
                        sumOfTwoAbundants[sum] = true;
                    }
                }
            });

            var result = 0L;

            for (int i = 0; i < upperlimit; i++)
            {
                if (!sumOfTwoAbundants[i])
                {
                    result += i;
                }
            }

            return result;
        }
    }
}
