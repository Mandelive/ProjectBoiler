using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Boilerplate;

namespace BoiledProblems
{
    public class Problem53 : BaseProblem
    {
        public Problem53()
        {
            Id = 53;
            Title = @"Q29tYmluYXRvcmljIHNlbGVjdGlvbnM=";
            Description = @"VGhlcmUgYXJlIGV4YWN0bHkgdGVuIHdheXMgb2Ygc2VsZWN0aW5nIHRocmVlIGZyb20gZml2ZSwgMTIzNDU6DQoNCjEyMywgMTI0LCAxMjUsIDEzNCwgMTM1LCAxNDUsIDIzNCwgMjM1LCAyNDUsIGFuZCAzNDUNCg0KSW4gY29tYmluYXRvcmljcywgd2UgdXNlIHRoZSBub3RhdGlvbiwgNUMzID0gMTAuDQoNCkluIGdlbmVyYWwsDQoNCm5DciA9IG4hIC8gciEobuKIknIpISAsd2hlcmUgciDiiaQgbiwgbiEgPSBuw5cobuKIkjEpw5cuLi7DlzPDlzLDlzEsIGFuZCAwISA9IDEuDQoNCkl0IGlzIG5vdCB1bnRpbCBuID0gMjMsIHRoYXQgYSB2YWx1ZSBleGNlZWRzIG9uZS1taWxsaW9uOiAyM0MxMCA9IDExNDQwNjYuDQoNCkhvdyBtYW55LCBub3QgbmVjZXNzYXJpbHkgZGlzdGluY3QsIHZhbHVlcyBvZiAgbkNyLCBmb3IgMSDiiaQgbiDiiaQgMTAwLCBhcmUgZ3JlYXRlciB0aGFuIG9uZS1taWxsaW9uPw==";

            parametersInfo = new string[]
            {
                "n:num - number range",
                "t:num - exceed threshold"
            };

            defaultParameters = new string[]
            {
                "100",
                "1000000"
            };

            ResetParameters();
        }

        public override string Solve()
        {
            var n = Int32.Parse(parameters[0]);
            var t = Int64.Parse(parameters[1]);
            return findCombinatoricValuesOverThreshold(n, t).ToString();
        }

        private long findCombinatoricValuesOverThreshold(int n, long t)
        {
            var result = 0L;

            for (int i = 1; i <= n; i++)
            {
                for (int k = 1; k < n; k++)
                {
                    var product = 1.0f;
                    var term = 1;
                    while (product <= t && term <= k)
                    {
                        product *= (i - term + 1) / (float)term;
                        term++;
                    }

                    if (product > t)
                    {
                        result += i - (k << 1) + 1;
                        break;
                    }
                }
            }

            return result;
        }
    }
}
