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
    public class Problem24 : BaseProblem
    {
        public Problem24()
        {
            Id = 24;
            Title = @"TGV4aWNvZ3JhcGhpYyBwZXJtdXRhdGlvbnM=";
            Description = @"QSBwZXJtdXRhdGlvbiBpcyBhbiBvcmRlcmVkIGFycmFuZ2VtZW50IG9mIG9iamVjdHMuIEZvciBleGFtcGxlLCAzMTI0IGlzIG9uZSBwb3NzaWJsZSBwZXJtdXRhdGlvbiBvZiB0aGUgZGlnaXRzIDEsIDIsIDMgYW5kIDQuIElmIGFsbCBvZiB0aGUgcGVybXV0YXRpb25zIGFyZSBsaXN0ZWQgbnVtZXJpY2FsbHkgb3IgYWxwaGFiZXRpY2FsbHksIHdlIGNhbGwgaXQgbGV4aWNvZ3JhcGhpYyBvcmRlci4gVGhlIGxleGljb2dyYXBoaWMgcGVybXV0YXRpb25zIG9mIDAsIDEgYW5kIDIgYXJlOg0KDQowMTIgICAwMjEgICAxMDIgICAxMjAgICAyMDEgICAyMTANCg0KV2hhdCBpcyB0aGUgbWlsbGlvbnRoIGxleGljb2dyYXBoaWMgcGVybXV0YXRpb24gb2YgdGhlIGRpZ2l0cyAwLCAxLCAyLCAzLCA0LCA1LCA2LCA3LCA4IGFuZCA5Pw0K";

            parametersInfo = new string[]
            {
                "n:num - nth permutation"    
            };

            defaultParameters = new string[]
            {
                "1000000"
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
