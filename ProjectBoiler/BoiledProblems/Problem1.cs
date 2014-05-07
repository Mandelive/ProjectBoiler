using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoiledProblems
{
    public class Problem1 : BaseProblem
    {
        public Problem1(): base(
            1, 
            @"TXVsdGlwbGVzIG9mIDMgYW5kIDU=", 
            @"SWYgd2UgbGlzdCBhbGwgdGhlIG5hdHVyYWwgbnVtYmVycyBiZWxvdyAxMCB0aGF0IGFyZSBtdWx0aXBsZXMgb2YgMyBvciA1LCB3ZSBnZXQgMywgNSwgNiBhbmQgOS4gVGhlIHN1bSBvZiB0aGVzZSBtdWx0aXBsZXMgaXMgMjMuDQoNCkZpbmQgdGhlIHN1bSBvZiBhbGwgdGhlIG11bHRpcGxlcyBvZiAzIG9yIDUgYmVsb3cgMTAwMC4=",
            new string[] {
                "n:num - find the sum of all the multiple below this number"
            },
            new string[] {
                "1000"
            }
        ) {}

        public override string Solve(string[] parameters)
        {
            throw new NotImplementedException("TODO");
        }
    }
}
