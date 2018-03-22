using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Boilerplate;

namespace BoiledProblems
{
    public class Problem29 : BaseProblem
    {
        public Problem29()
        {
            Id = 29;
            Title = @"RGlzdGluY3QgcG93ZXJz";
            Description = @"Q29uc2lkZXIgYWxsIGludGVnZXIgY29tYmluYXRpb25zIG9mIGFeYiBmb3IgMiDiiaQgYSDiiaQgNSBhbmQgMiDiiaQgYiDiiaQgNToNCg0KMl4yPTQsIDJeMz04LCAyXjQ9MTYsIDJeNT0zMg0KM14yPTksIDNeMz0yNywgM140PTgxLCAzXjU9MjQzDQo0XjI9MTYsIDReMz02NCwgNF40PTI1NiwgNF41PTEwMjQNCjVeMj0yNSwgNV4zPTEyNSwgNV40PTYyNSwgNV41PTMxMjUNCg0KSWYgdGhleSBhcmUgdGhlbiBwbGFjZWQgaW4gbnVtZXJpY2FsIG9yZGVyLCB3aXRoIGFueSByZXBlYXRzIHJlbW92ZWQsIHdlIGdldCB0aGUgZm9sbG93aW5nIHNlcXVlbmNlIG9mIDE1IGRpc3RpbmN0IHRlcm1zOg0KDQo0LCA4LCA5LCAxNiwgMjUsIDI3LCAzMiwgNjQsIDgxLCAxMjUsIDI0MywgMjU2LCA2MjUsIDEwMjQsIDMxMjUNCg0KSG93IG1hbnkgZGlzdGluY3QgdGVybXMgYXJlIGluIHRoZSBzZXF1ZW5jZSBnZW5lcmF0ZWQgYnkgYV5iIGZvciAyIOKJpCBhIOKJpCAxMDAgYW5kIDIg4omkIGIg4omkIDEwMD8=";

            parametersInfo = new string[]
            {
                "a:num - range for base a",
                "b:num - range for exponent b",
            };

            defaultParameters = new string[]
            {
                "100",
                "100"
            };

            ResetParameters();
        }

        public override string Solve()
        {
            var a = Int32.Parse(parameters[0]);
            var b = Int32.Parse(parameters[1]);
            return findDistinctPowers(a, b).ToString();
        }

        private long findDistinctPowers(int a, int b)
        {
            long result = (a - 1) * (b - 1);

            var covered = new bool[a + 1];

            var repsDict = new Dictionary<int, bool[]>();

            for (int i = 2; i <= a; i++)
            {
                if (covered[i])
                {
                    continue;
                }

                var generation = 2;
                var genBase = (int)Math.Pow(i, generation);
                while (genBase <= a)
                {
                    covered[genBase] = true;
                    repsDict.Add(genBase, new bool[b + 1]);

                    for (int j = 2; j < generation; j++)
                    {
                        var start = 0;
                        var end = 0;
                        var increment = (int)BoilMathFunctions.LcmGcd(BoilMathFunctions.ModPow(i, j, 1), genBase);
                        for (int k = start; k  <= end; k += increment)
                        {
                            repsDict[genBase][k] = true;
                        }
                    }
                }
            }

            return result;
        }
    }
}
