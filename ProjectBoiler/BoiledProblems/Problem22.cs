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
    public class Problem22 : BaseProblem
    {
        public Problem22()
        {
            Id = 22;
            Title = @"TmFtZXMgc2NvcmVz";
            Description = @"VXNpbmcgbmFtZXMudHh0IChyaWdodCBjbGljayBhbmQgJ1NhdmUgTGluay9UYXJnZXQgQXMuLi4nKSwgYSA0NksgdGV4dCBmaWxlIGNvbnRhaW5pbmcgb3ZlciBmaXZlLXRob3VzYW5kIGZpcnN0IG5hbWVzLCBiZWdpbiBieSBzb3J0aW5nIGl0IGludG8gYWxwaGFiZXRpY2FsIG9yZGVyLiBUaGVuIHdvcmtpbmcgb3V0IHRoZSBhbHBoYWJldGljYWwgdmFsdWUgZm9yIGVhY2ggbmFtZSwgbXVsdGlwbHkgdGhpcyB2YWx1ZSBieSBpdHMgYWxwaGFiZXRpY2FsIHBvc2l0aW9uIGluIHRoZSBsaXN0IHRvIG9idGFpbiBhIG5hbWUgc2NvcmUuDQoNCkZvciBleGFtcGxlLCB3aGVuIHRoZSBsaXN0IGlzIHNvcnRlZCBpbnRvIGFscGhhYmV0aWNhbCBvcmRlciwgQ09MSU4sIHdoaWNoIGlzIHdvcnRoIDMgKyAxNSArIDEyICsgOSArIDE0ID0gNTMsIGlzIHRoZSA5Mzh0aCBuYW1lIGluIHRoZSBsaXN0LiBTbywgQ09MSU4gd291bGQgb2J0YWluIGEgc2NvcmUgb2YgOTM4IMOXIDUzID0gNDk3MTQuDQoNCldoYXQgaXMgdGhlIHRvdGFsIG9mIGFsbCB0aGUgbmFtZSBzY29yZXMgaW4gdGhlIGZpbGU/DQo=";

            parametersInfo = new string[]
            {
                "t:fil - names text file path",
            };

            defaultParameters = new string[]
            {
                "names.txt"
            };

            ResetParameters();
        }

        public override string Solve()
        {
            var f = parameters[0];
            return findSumOfNameScores(f).ToString();
        }

        private long findSumOfNameScores(string f)
        {
            string[] names;

            using (var sr = new StreamReader(f))
            {
                names = sr.ReadToEnd().Split(new string[] { @""",""", @"""" }, StringSplitOptions.RemoveEmptyEntries);
            }

            Array.Sort<string>(names);

            var result = 0L;

            for (int i = 0; i < names.Length; i++)
            {
                var namescore = 0;
                for (int c = 0; c < names[i].Length; c++)
                {
                    namescore += names[i][c] - 'A' + 1;
                }

                result += namescore * (i + 1);
            }

            return result;
        }
    }
}
