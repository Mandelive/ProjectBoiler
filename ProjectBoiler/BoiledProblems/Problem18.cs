using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Numerics;
using Boilerplate;

namespace BoiledProblems
{
    public class Problem18 : BaseProblem
    {
        public Problem18()
        {
            Id = 18;
            Title = @"TWF4aW11bSBwYXRoIHN1bSBJ";
            Description = @"Qnkgc3RhcnRpbmcgYXQgdGhlIHRvcCBvZiB0aGUgdHJpYW5nbGUgYmVsb3cgYW5kIG1vdmluZyB0byBhZGphY2VudCBudW1iZXJzIG9uIHRoZSByb3cgYmVsb3csIHRoZSBtYXhpbXVtIHRvdGFsIGZyb20gdG9wIHRvIGJvdHRvbSBpcyAyMy4NCg0KICAgMw0KICA3IDQNCiAyIDQgNg0KOCA1IDkgMw0KDQpUaGF0IGlzLCAzICsgNyArIDQgKyA5ID0gMjMuDQoNCkZpbmQgdGhlIG1heGltdW0gdG90YWwgZnJvbSB0b3AgdG8gYm90dG9tIG9mIHRoZSB0cmlhbmdsZSBiZWxvdzoNCg0KICAgICAgICAgICAgICA3NQ0KICAgICAgICAgICAgIDk1IDY0DQogICAgICAgICAgICAxNyA0NyA4Mg0KICAgICAgICAgICAxOCAzNSA4NyAxMA0KICAgICAgICAgIDIwIDA0IDgyIDQ3IDY1DQogICAgICAgICAxOSAwMSAyMyA3NSAwMyAzNA0KICAgICAgICA4OCAwMiA3NyA3MyAwNyA2MyA2Nw0KICAgICAgIDk5IDY1IDA0IDI4IDA2IDE2IDcwIDkyDQogICAgICA0MSA0MSAyNiA1NiA4MyA0MCA4MCA3MCAzMw0KICAgICA0MSA0OCA3MiAzMyA0NyAzMiAzNyAxNiA5NCAyOQ0KICAgIDUzIDcxIDQ0IDY1IDI1IDQzIDkxIDUyIDk3IDUxIDE0DQogICA3MCAxMSAzMyAyOCA3NyA3MyAxNyA3OCAzOSA2OCAxNyA1Nw0KICA5MSA3MSA1MiAzOCAxNyAxNCA5MSA0MyA1OCA1MCAyNyAyOSA0OA0KIDYzIDY2IDA0IDY4IDg5IDUzIDY3IDMwIDczIDE2IDY5IDg3IDQwIDMxDQowNCA2MiA5OCAyNyAyMyAwOSA3MCA5OCA3MyA5MyAzOCA1MyA2MCAwNCAyMw0KDQo=";

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
            return findMaximumTriangleSum().ToString();
        }

        private long findMaximumTriangleSum()
        {
            var triangleInput = @"75
                                 95 64
                                17 47 82
                              18 35 87 10
                             20 04 82 47 65
                            19 01 23 75 03 34
                           88 02 77 73 07 63 67
                          99 65 04 28 06 16 70 92
                         41 41 26 56 83 40 80 70 33
                        41 48 72 33 47 32 37 16 94 29
                       53 71 44 65 25 43 91 52 97 51 14
                      70 11 33 28 77 73 17 78 39 68 17 57
                     91 71 52 38 17 14 91 43 58 50 27 29 48
                    63 66 04 68 89 53 67 30 73 16 69 87 40 31
                   04 62 98 27 23 09 70 98 73 93 38 53 60 04 23";

            var sr = new StringReader(triangleInput);
            var listOfNumbers = new List<long>(triangleInput.Length / 3);

            var rowString = sr.ReadLine();

            while (rowString != null)
            {
                var rowNumStrings = rowString.Trim().Split(' ');
                foreach (var n in rowNumStrings)
                {
                    listOfNumbers.Add(Int64.Parse(n));
                }
                rowString = sr.ReadLine();
            }

            var triangle = new long[(int)Math.Floor(Math.Sqrt(2 * listOfNumbers.Count))][];

            var current = 0;

            for (int i = 0; i < triangle.Length; i++)
            {
                triangle[i] = new long[i + 1];
                for (int j = 0; j < i + 1; j++)
                {
                    triangle[i][j] = listOfNumbers[current++];
                }
            }

            for (int i = triangle.Length - 1; i > 0; i--)
            {
                for (int j = 0; j < triangle[i].Length - 1; j++)
                {
                    triangle[i - 1][j] += (triangle[i][j] > triangle[i][j + 1] ? triangle[i][j] : triangle[i][j + 1]);
                }
            }

            var result = triangle[0][0];

            return result;
        }
    }
}
