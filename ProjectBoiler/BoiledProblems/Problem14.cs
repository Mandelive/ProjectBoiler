using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Boilerplate;

namespace BoiledProblems
{
    public class Problem14 : BaseProblem
    {
        public Problem14()
        {
            Id = 14;
            Title = @"TG9uZ2VzdCBDb2xsYXR6IHNlcXVlbmNl";
            Description = @"VGhlIGZvbGxvd2luZyBpdGVyYXRpdmUgc2VxdWVuY2UgaXMgZGVmaW5lZCBmb3IgdGhlIHNldCBvZiBwb3NpdGl2ZSBpbnRlZ2VyczoNCg0KbiDihpIgbi8yIChuIGlzIGV2ZW4pDQpuIOKGkiAzbiArIDEgKG4gaXMgb2RkKQ0KDQpVc2luZyB0aGUgcnVsZSBhYm92ZSBhbmQgc3RhcnRpbmcgd2l0aCAxMywgd2UgZ2VuZXJhdGUgdGhlIGZvbGxvd2luZyBzZXF1ZW5jZToNCjEzIOKGkiA0MCDihpIgMjAg4oaSIDEwIOKGkiA1IOKGkiAxNiDihpIgOCDihpIgNCDihpIgMiDihpIgMQ0KDQpJdCBjYW4gYmUgc2VlbiB0aGF0IHRoaXMgc2VxdWVuY2UgKHN0YXJ0aW5nIGF0IDEzIGFuZCBmaW5pc2hpbmcgYXQgMSkgY29udGFpbnMgMTAgdGVybXMuIEFsdGhvdWdoIGl0IGhhcyBub3QgYmVlbiBwcm92ZWQgeWV0IChDb2xsYXR6IFByb2JsZW0pLCBpdCBpcyB0aG91Z2h0IHRoYXQgYWxsIHN0YXJ0aW5nIG51bWJlcnMgZmluaXNoIGF0IDEuDQoNCldoaWNoIHN0YXJ0aW5nIG51bWJlciwgdW5kZXIgb25lIG1pbGxpb24sIHByb2R1Y2VzIHRoZSBsb25nZXN0IGNoYWluPw0KDQpOT1RFOiBPbmNlIHRoZSBjaGFpbiBzdGFydHMgdGhlIHRlcm1zIGFyZSBhbGxvd2VkIHRvIGdvIGFib3ZlIG9uZSBtaWxsaW9uLg0K";

            parametersInfo = new string[]
            {
                "n:num - upperlimit number"
            };

            defaultParameters = new string[]
            {
                "1000000"
            };

            ResetParameters();
        }

        public override string Solve()
        {
            var n = Int32.Parse(parameters[0]);
            return findLongestCollatzChain(n).ToString();
        }

        private long findLongestCollatzChain(int n)
        {
            var collatzLookup = new int[n];

            for (int i = 1; i < collatzLookup.Length; i++)
            {
                long collatz = ((i & 1) == 0 ? i >> 1 : 3L * i + 1);
                
                collatzLookup[i] = 1;

                while (collatz != 1)
                {
                    if (collatz < i)
                    {
                        collatzLookup[i] += collatzLookup[collatz];
                        break;
                    }
                    else
                    {
                        collatzLookup[i]++;
                        collatz = ((collatz & 1) == 0 ? collatz >> 1 : 3 * collatz + 1);
                    }
                }
            }

            var max = 0L;
            var result = 0;

            for (int i = 1; i < n; i += 2)
            {
                if (collatzLookup[i] > max)
                {
                    max = collatzLookup[i];
                    result = i;
                }
            }

            return result;
        }
    }
}
