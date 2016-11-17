using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Boilerplate;

namespace BoiledProblems
{
    public class Problem26 : BaseProblem
    {
        public Problem26()
        {
            Id = 26;
            Title = @"UmVjaXByb2NhbCBjeWNsZXM=";
            Description = @"QSB1bml0IGZyYWN0aW9uIGNvbnRhaW5zIDEgaW4gdGhlIG51bWVyYXRvci4gVGhlIGRlY2ltYWwgcmVwcmVzZW50YXRpb24gb2YgdGhlIHVuaXQgZnJhY3Rpb25zIHdpdGggZGVub21pbmF0b3JzIDIgdG8gMTAgYXJlIGdpdmVuOg0KDQoxLzIJPSAJMC41DQoxLzMJPSAJMC4oMykNCjEvNAk9IAkwLjI1DQoxLzUJPSAJMC4yDQoxLzYJPSAJMC4xKDYpDQoxLzcJPSAJMC4oMTQyODU3KQ0KMS84CT0gCTAuMTI1DQoxLzkJPSAJMC4oMSkNCjEvMTAJPSAJMC4xDQpXaGVyZSAwLjEoNikgbWVhbnMgMC4xNjY2NjYuLi4sIGFuZCBoYXMgYSAxLWRpZ2l0IHJlY3VycmluZyBjeWNsZS4gSXQgY2FuIGJlIHNlZW4gdGhhdCAxLzcgaGFzIGEgNi1kaWdpdCByZWN1cnJpbmcgY3ljbGUuDQoNCkZpbmQgdGhlIHZhbHVlIG9mIGQgPCAxMDAwIGZvciB3aGljaCAxL2QgY29udGFpbnMgdGhlIGxvbmdlc3QgcmVjdXJyaW5nIGN5Y2xlIGluIGl0cyBkZWNpbWFsIGZyYWN0aW9uIHBhcnQu";

            parametersInfo = new string[]
            {
                "n:num - upperlimit of the denominator"
            };

            defaultParameters = new string[]
            {
                "1000"
            };

            ResetParameters();
        }

        public override string Solve()
        {
            var n = Int32.Parse(parameters[0]);
            return findLargestRecurringCycle(n).ToString();
        }

        private long findLargestRecurringCycle(int n)
        {
            int maxLen = 0;
            int maxNum = 0;
            int currLen = 0;

            int q, r;

            for (int i = 1; i < n; i++)
            {
                currLen = 0;
                r = 1;

                if (r < i)
                {
                    r *= 10;
                }

                q = r / i;
                r = r % i;

                var cycleHeads = new HashSet<int>();

                while (r != 0 && !cycleHeads.Contains(q*n+r))
                {
                    currLen++;
                    cycleHeads.Add(q*n+r);
                    if (r < i)
                    {
                        r *= 10;
                    }

                    q = r / i;
                    r = r % i;
                }

                if (currLen > maxLen)
                {
                    maxLen = currLen;
                    maxNum = i;
                }
            }

            return maxNum;
        }
    }
}
