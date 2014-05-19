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
            var n = Int64.Parse(parameters[0]);
            return findLexicographicPermutation(n).ToString();
        }

        private long findLexicographicPermutation(long n)
        {
            var result = 0L;

            return result;
        }
    }
}
