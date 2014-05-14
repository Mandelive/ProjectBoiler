using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Boilerplate;

namespace BoiledProblems
{
    public class Problem8 : BaseProblem
    {
        public Problem8(): base(
            8,
            @"TGFyZ2VzdCBwcm9kdWN0IGluIGEgc2VyaWVz",
            @"RmluZCB0aGUgZ3JlYXRlc3QgcHJvZHVjdCBvZiBmaXZlIGNvbnNlY3V0aXZlIGRpZ2l0cyBpbiB0aGUgMTAwMC1kaWdpdCBudW1iZXIuDQoNCjczMTY3MTc2NTMxMzMwNjI0OTE5MjI1MTE5Njc0NDI2NTc0NzQyMzU1MzQ5MTk0OTM0DQo5Njk4MzUyMDMxMjc3NDUwNjMyNjIzOTU3ODMxODAxNjk4NDgwMTg2OTQ3ODg1MTg0Mw0KODU4NjE1NjA3ODkxMTI5NDk0OTU0NTk1MDE3Mzc5NTgzMzE5NTI4NTMyMDg4MDU1MTENCjEyNTQwNjk4NzQ3MTU4NTIzODYzMDUwNzE1NjkzMjkwOTYzMjk1MjI3NDQzMDQzNTU3DQo2Njg5NjY0ODk1MDQ0NTI0NDUyMzE2MTczMTg1NjQwMzA5ODcxMTEyMTcyMjM4MzExMw0KNjIyMjk4OTM0MjMzODAzMDgxMzUzMzYyNzY2MTQyODI4MDY0NDQ0ODY2NDUyMzg3NDkNCjMwMzU4OTA3Mjk2MjkwNDkxNTYwNDQwNzcyMzkwNzEzODEwNTE1ODU5MzA3OTYwODY2DQo3MDE3MjQyNzEyMTg4Mzk5ODc5NzkwODc5MjI3NDkyMTkwMTY5OTcyMDg4ODA5Mzc3Ng0KNjU3MjczMzMwMDEwNTMzNjc4ODEyMjAyMzU0MjE4MDk3NTEyNTQ1NDA1OTQ3NTIyNDMNCjUyNTg0OTA3NzExNjcwNTU2MDEzNjA0ODM5NTg2NDQ2NzA2MzI0NDE1NzIyMTU1Mzk3DQo1MzY5NzgxNzk3Nzg0NjE3NDA2NDk1NTE0OTI5MDg2MjU2OTMyMTk3ODQ2ODYyMjQ4Mg0KODM5NzIyNDEzNzU2NTcwNTYwNTc0OTAyNjE0MDc5NzI5Njg2NTI0MTQ1MzUxMDA0NzQNCjgyMTY2MzcwNDg0NDAzMTk5ODkwMDA4ODk1MjQzNDUwNjU4NTQxMjI3NTg4NjY2ODgxDQoxNjQyNzE3MTQ3OTkyNDQ0MjkyODIzMDg2MzQ2NTY3NDgxMzkxOTEyMzE2MjgyNDU4Ng0KMTc4NjY0NTgzNTkxMjQ1NjY1Mjk0NzY1NDU2ODI4NDg5MTI4ODMxNDI2MDc2OTAwNDINCjI0MjE5MDIyNjcxMDU1NjI2MzIxMTExMTA5MzcwNTQ0MjE3NTA2OTQxNjU4OTYwNDA4DQowNzE5ODQwMzg1MDk2MjQ1NTQ0NDM2Mjk4MTIzMDk4Nzg3OTkyNzI0NDI4NDkwOTE4OA0KODQ1ODAxNTYxNjYwOTc5MTkxMzM4NzU0OTkyMDA1MjQwNjM2ODk5MTI1NjA3MTc2MDYNCjA1ODg2MTE2NDY3MTA5NDA1MDc3NTQxMDAyMjU2OTgzMTU1MjAwMDU1OTM1NzI5NzI1DQo3MTYzNjI2OTU2MTg4MjY3MDQyODI1MjQ4MzYwMDgyMzI1NzUzMDQyMDc1Mjk2MzQ1MA==",
            new string[] {
                "n:num - number of consecutive digits"
            },
            new string[] {
                "5"
            }
        ) {}

        public override string Solve(string[] parameters)
        {
            var n = Int32.Parse(parameters[0]);
            return findGreatestProductOfConsecutiveDigits(n).ToString();
        }

        private long findGreatestProductOfConsecutiveDigits(int n)
        {
            var vlongNumber = @"73167176531330624919225119674426574742355349194934
                                96983520312774506326239578318016984801869478851843
                                85861560789112949495459501737958331952853208805511
                                12540698747158523863050715693290963295227443043557
                                66896648950445244523161731856403098711121722383113
                                62229893423380308135336276614282806444486645238749
                                30358907296290491560440772390713810515859307960866
                                70172427121883998797908792274921901699720888093776
                                65727333001053367881220235421809751254540594752243
                                52584907711670556013604839586446706324415722155397
                                53697817977846174064955149290862569321978468622482
                                83972241375657056057490261407972968652414535100474
                                82166370484403199890008895243450658541227588666881
                                16427171479924442928230863465674813919123162824586
                                17866458359124566529476545682848912883142607690042
                                24219022671055626321111109370544217506941658960408
                                07198403850962455444362981230987879927244284909188
                                84580156166097919133875499200524063689912560717606
                                05886116467109405077541002256983155200055935729725
                                71636269561882670428252483600823257530420752963450";

            vlongNumber = vlongNumber.Replace(" ", "");
            vlongNumber = vlongNumber.Replace("\t", "");
            vlongNumber = vlongNumber.Replace("\r", "");
            vlongNumber = vlongNumber.Replace("\n", "");

            var max = 0L;

            for (int i = 0; i < vlongNumber.Length - n; i++)
            {
                var segement = vlongNumber.Substring(i, n);
                if (!segement.Contains('0'))
                {
                    var t = 1L;
                    for (int d = 0; d < n; d++)
                    {
                        t *= Int64.Parse(segement[d] + "");
                    }
                    if (t > max)
                    {
                        max = t;
                    }
                }
            }

            var result = max;

            return result;
        }
    }
}
