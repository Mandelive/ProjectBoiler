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
    public class Problem19 : BaseProblem
    {
        public Problem19()
        {
            Id = 19;
            Title = @"Q291bnRpbmcgU3VuZGF5cw==";
            Description = @"WW91IGFyZSBnaXZlbiB0aGUgZm9sbG93aW5nIGluZm9ybWF0aW9uLCBidXQgeW91IG1heSBwcmVmZXIgdG8gZG8gc29tZSByZXNlYXJjaCBmb3IgeW91cnNlbGYuDQoNCiAgICAxIEphbiAxOTAwIHdhcyBhIE1vbmRheS4NCiAgICBUaGlydHkgZGF5cyBoYXMgU2VwdGVtYmVyLA0KICAgIEFwcmlsLCBKdW5lIGFuZCBOb3ZlbWJlci4NCiAgICBBbGwgdGhlIHJlc3QgaGF2ZSB0aGlydHktb25lLA0KICAgIFNhdmluZyBGZWJydWFyeSBhbG9uZSwNCiAgICBXaGljaCBoYXMgdHdlbnR5LWVpZ2h0LCByYWluIG9yIHNoaW5lLg0KICAgIEFuZCBvbiBsZWFwIHllYXJzLCB0d2VudHktbmluZS4NCiAgICBBIGxlYXAgeWVhciBvY2N1cnMgb24gYW55IHllYXIgZXZlbmx5IGRpdmlzaWJsZSBieSA0LCBidXQgbm90IG9uIGEgY2VudHVyeSB1bmxlc3MgaXQgaXMgZGl2aXNpYmxlIGJ5IDQwMC4NCg0KSG93IG1hbnkgU3VuZGF5cyBmZWxsIG9uIHRoZSBmaXJzdCBvZiB0aGUgbW9udGggZHVyaW5nIHRoZSB0d2VudGlldGggY2VudHVyeSAoMSBKYW4gMTkwMSB0byAzMSBEZWMgMjAwMCk/DQo=";

            parametersInfo = new string[]
            {
                "s:dat - start date",
                "e:dat - end date",
                "w:str - weekday (Sunday to Saturday)"
            };

            defaultParameters = new string[]
            {
                "1901-01-01",
                "2000-12-31",
                "sunday"
            };

            ResetParameters();
        }

        public override string Solve()
        {
            return findMaximumTriangleSum().ToString();
        }

        private long findMaximumTriangleSum()
        {
            var result = 0L;

            return result;
        }
    }
}
