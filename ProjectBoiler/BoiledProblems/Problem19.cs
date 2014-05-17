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
                "w:str - weekday (Monday to Sunday)"
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
            var s = DateTime.Parse(parameters[0]);
            var e = DateTime.Parse(parameters[1]);
            var w = parameters[2];

            return findNumberOfWeekdaysBetween(s, e, w).ToString();
        }

        private long findNumberOfWeekdaysBetween(DateTime s, DateTime e, string w)
        {
            var weekdays = new List<string>(new string[] { "monday", "tuesday", "wednesday", "thursday", "friday", "saturday", "sunday" });

            var baseYear = 1900;
            var baseMonth = 1;
            var baseWeekday = weekdays.IndexOf(w);
            var baseDay = 1 + baseWeekday;
            
            var monthdays = new int[] { 0, 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };

            var result = 0L;
            var inRange = false;
            
            for (; baseYear < e.Year || baseMonth < e.Month || baseDay < e.Day; baseDay += 7)
            {
                if (!inRange && baseYear >= s.Year && baseMonth >= s.Month && baseDay >= s.Day)
                {
                    inRange = true;
                }

                if (baseDay > monthdays[baseMonth])
                {
                    if (baseMonth == 2)
                    {
                        if ((baseYear % 100 != 0 && baseYear % 4 == 0) || baseYear % 400 == 0)
                        {
                            if (baseDay > 29)
                            {
                                baseDay = (baseDay - 1) % 29 + 1;
                                baseMonth++;
                            }
                        }
                        else
                        {
                            baseDay = (baseDay - 1) % 28 + 1;
                            baseMonth++;
                        }
                    }
                    else
                    {
                        baseDay = (baseDay - 1) % monthdays[baseMonth] + 1;
                        baseMonth++;
                    }
                }

                if (inRange && baseDay == 1)
                {
                    result++;
                }

                if (baseMonth > 12)
                {
                    baseMonth = 1;
                    baseYear++;
                }
            }

            return result;
        }
    }
}
