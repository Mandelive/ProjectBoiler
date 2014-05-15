using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Boilerplate;

namespace BoiledProblems
{
    public class Problem11 : BaseProblem
    {
        public Problem11()
        {
            Id = 11;
            Title = @"TGFyZ2VzdCBwcm9kdWN0IGluIGEgZ3JpZA==";
            Description = @"SW4gdGhlIDIww5cyMCBncmlkIGJlbG93LCBmb3VyIG51bWJlcnMgYWxvbmcgYSBkaWFnb25hbCBsaW5lIGhhdmUgYmVlbiBtYXJrZWQgaW4gcmVkLg0KDQowOCAwMiAyMiA5NyAzOCAxNSAwMCA0MCAwMCA3NSAwNCAwNSAwNyA3OCA1MiAxMiA1MCA3NyA5MSAwOA0KNDkgNDkgOTkgNDAgMTcgODEgMTggNTcgNjAgODcgMTcgNDAgOTggNDMgNjkgNDggMDQgNTYgNjIgMDANCjgxIDQ5IDMxIDczIDU1IDc5IDE0IDI5IDkzIDcxIDQwIDY3IDUzIDg4IDMwIDAzIDQ5IDEzIDM2IDY1DQo1MiA3MCA5NSAyMyAwNCA2MCAxMSA0MiA2OSAyNCA2OCA1NiAwMSAzMiA1NiA3MSAzNyAwMiAzNiA5MQ0KMjIgMzEgMTYgNzEgNTEgNjcgNjMgODkgNDEgOTIgMzYgNTQgMjIgNDAgNDAgMjggNjYgMzMgMTMgODANCjI0IDQ3IDMyIDYwIDk5IDAzIDQ1IDAyIDQ0IDc1IDMzIDUzIDc4IDM2IDg0IDIwIDM1IDE3IDEyIDUwDQozMiA5OCA4MSAyOCA2NCAyMyA2NyAxMCAyNiAzOCA0MCA2NyA1OSA1NCA3MCA2NiAxOCAzOCA2NCA3MA0KNjcgMjYgMjAgNjggMDIgNjIgMTIgMjAgOTUgNjMgOTQgMzkgNjMgMDggNDAgOTEgNjYgNDkgOTQgMjENCjI0IDU1IDU4IDA1IDY2IDczIDk5IDI2IDk3IDE3IDc4IDc4IDk2IDgzIDE0IDg4IDM0IDg5IDYzIDcyDQoyMSAzNiAyMyAwOSA3NSAwMCA3NiA0NCAyMCA0NSAzNSAxNCAwMCA2MSAzMyA5NyAzNCAzMSAzMyA5NQ0KNzggMTcgNTMgMjggMjIgNzUgMzEgNjcgMTUgOTQgMDMgODAgMDQgNjIgMTYgMTQgMDkgNTMgNTYgOTINCjE2IDM5IDA1IDQyIDk2IDM1IDMxIDQ3IDU1IDU4IDg4IDI0IDAwIDE3IDU0IDI0IDM2IDI5IDg1IDU3DQo4NiA1NiAwMCA0OCAzNSA3MSA4OSAwNyAwNSA0NCA0NCAzNyA0NCA2MCAyMSA1OCA1MSA1NCAxNyA1OA0KMTkgODAgODEgNjggMDUgOTQgNDcgNjkgMjggNzMgOTIgMTMgODYgNTIgMTcgNzcgMDQgODkgNTUgNDANCjA0IDUyIDA4IDgzIDk3IDM1IDk5IDE2IDA3IDk3IDU3IDMyIDE2IDI2IDI2IDc5IDMzIDI3IDk4IDY2DQo4OCAzNiA2OCA4NyA1NyA2MiAyMCA3MiAwMyA0NiAzMyA2NyA0NiA1NSAxMiAzMiA2MyA5MyA1MyA2OQ0KMDQgNDIgMTYgNzMgMzggMjUgMzkgMTEgMjQgOTQgNzIgMTggMDggNDYgMjkgMzIgNDAgNjIgNzYgMzYNCjIwIDY5IDM2IDQxIDcyIDMwIDIzIDg4IDM0IDYyIDk5IDY5IDgyIDY3IDU5IDg1IDc0IDA0IDM2IDE2DQoyMCA3MyAzNSAyOSA3OCAzMSA5MCAwMSA3NCAzMSA0OSA3MSA0OCA4NiA4MSAxNiAyMyA1NyAwNSA1NA0KMDEgNzAgNTQgNzEgODMgNTEgNTQgNjkgMTYgOTIgMzMgNDggNjEgNDMgNTIgMDEgODkgMTkgNjcgNDgNCg0KVGhlIHByb2R1Y3Qgb2YgdGhlc2UgbnVtYmVycyBpcyAyNiDDlyA2MyDDlyA3OCDDlyAxNCA9IDE3ODg2OTYuDQoNCldoYXQgaXMgdGhlIGdyZWF0ZXN0IHByb2R1Y3Qgb2YgZm91ciBhZGphY2VudCBudW1iZXJzIGluIHRoZSBzYW1lIGRpcmVjdGlvbiAodXAsIGRvd24sIGxlZnQsIHJpZ2h0LCBvciBkaWFnb25hbGx5KSBpbiB0aGUgMjDDlzIwIGdyaWQ/DQo=";

            parametersInfo = new string[]
            {
                "n:num - number of adjacent numbers"
            };

            defaultParameters = new string[]
            {
                "4"
            };

            ResetParameters();
        }

        public override string Solve()
        {
            var n = Int32.Parse(parameters[0]);
            return findLargestProductOfAdjacentsInGrid(n).ToString();
        }

        private long findLargestProductOfAdjacentsInGrid(int n)
        {
            var gridString =  @"08 02 22 97 38 15 00 40 00 75 04 05 07 78 52 12 50 77 91 08
                                49 49 99 40 17 81 18 57 60 87 17 40 98 43 69 48 04 56 62 00
                                81 49 31 73 55 79 14 29 93 71 40 67 53 88 30 03 49 13 36 65
                                52 70 95 23 04 60 11 42 69 24 68 56 01 32 56 71 37 02 36 91
                                22 31 16 71 51 67 63 89 41 92 36 54 22 40 40 28 66 33 13 80
                                24 47 32 60 99 03 45 02 44 75 33 53 78 36 84 20 35 17 12 50
                                32 98 81 28 64 23 67 10 26 38 40 67 59 54 70 66 18 38 64 70
                                67 26 20 68 02 62 12 20 95 63 94 39 63 08 40 91 66 49 94 21
                                24 55 58 05 66 73 99 26 97 17 78 78 96 83 14 88 34 89 63 72
                                21 36 23 09 75 00 76 44 20 45 35 14 00 61 33 97 34 31 33 95
                                78 17 53 28 22 75 31 67 15 94 03 80 04 62 16 14 09 53 56 92
                                16 39 05 42 96 35 31 47 55 58 88 24 00 17 54 24 36 29 85 57
                                86 56 00 48 35 71 89 07 05 44 44 37 44 60 21 58 51 54 17 58
                                19 80 81 68 05 94 47 69 28 73 92 13 86 52 17 77 04 89 55 40
                                04 52 08 83 97 35 99 16 07 97 57 32 16 26 26 79 33 27 98 66
                                88 36 68 87 57 62 20 72 03 46 33 67 46 55 12 32 63 93 53 69
                                04 42 16 73 38 25 39 11 24 94 72 18 08 46 29 32 40 62 76 36
                                20 69 36 41 72 30 23 88 34 62 99 69 82 67 59 85 74 04 36 16
                                20 73 35 29 78 31 90 01 74 31 49 71 48 86 81 16 23 57 05 54
                                01 70 54 71 83 51 54 69 16 92 33 48 61 43 52 01 89 19 67 48";

            const int rowSize = 20;
            const int colSize = 20;

            var grid = new int[rowSize, colSize];

            var sr = new System.IO.StringReader(gridString);            
            for (int r = 0; r < rowSize; r++)
            {
                var lineNumbers = sr.ReadLine().Trim().Split(' ');
                for (int c = 0; c < colSize; c++)
                {
                    grid[r, c] = Int32.Parse(lineNumbers[c]);
                }
            }
            sr.Close();

            var result = 0L;

            var m = n - 1;

            for (int r = 0; r < rowSize - m; r++)
            {
                for (int c = 0; c < colSize; c++)
                {
                    var product = 1L;
                    for (int i = 0; i < n; i++)
                    {
                        product *= grid[r + i, c];
                    }
                    if (product > result)
                    {
                        result = product;
                    }
                }
            }

            for (int c = 0; c < colSize - m; c++)
            {
                for (int r = 0; r < rowSize; r++)
                {
                    var product = 1L;
                    for (int i = 0; i < n; i++)
                    {
                        product *= grid[r, c + i];
                    }
                    if (product > result)
                    {
                        result = product;
                    }
                }
            }

            for (int r = 0; r < rowSize - m; r++)
            {
                for (int c = 0; c < colSize - m; c++)
                {
                    var product = 1L;
                    for (int i = 0; i < n; i++)
                    {
                        product *= grid[r + i, c + i];
                    }
                    if (product > result)
                    {
                        result = product;
                    }
                }
            }

            for (int r = 0; r < rowSize - m; r++)
            {
                for (int c = colSize - 1; c >= m; c--)
                {
                    var product = 1L;
                    for (int i = 0; i < n; i++)
                    {
                        product *= grid[r + i, c - i];
                    }
                    if (product > result)
                    {
                        result = product;
                    }
                }
            }

            return result;
        }
    }
}
