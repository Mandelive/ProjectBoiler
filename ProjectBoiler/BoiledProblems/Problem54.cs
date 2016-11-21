using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Boilerplate;
using System.IO;

namespace BoiledProblems
{
    public class Problem54 : BaseProblem
    {
        public Problem54()
        {
            Id = 54;
            Title = @"UG9rZXIgaGFuZHM=";
            Description = @"biB0aGUgY2FyZCBnYW1lIHBva2VyLCBhIGhhbmQgY29uc2lzdHMgb2YgZml2ZSBjYXJkcyBhbmQgYXJlIHJhbmtlZCwgZnJvbSBsb3dlc3QgdG8gaGlnaGVzdCwgaW4gdGhlIGZvbGxvd2luZyB3YXk6DQoNCkhpZ2ggQ2FyZDogSGlnaGVzdCB2YWx1ZSBjYXJkLg0KT25lIFBhaXI6IFR3byBjYXJkcyBvZiB0aGUgc2FtZSB2YWx1ZS4NClR3byBQYWlyczogVHdvIGRpZmZlcmVudCBwYWlycy4NClRocmVlIG9mIGEgS2luZDogVGhyZWUgY2FyZHMgb2YgdGhlIHNhbWUgdmFsdWUuDQpTdHJhaWdodDogQWxsIGNhcmRzIGFyZSBjb25zZWN1dGl2ZSB2YWx1ZXMuDQpGbHVzaDogQWxsIGNhcmRzIG9mIHRoZSBzYW1lIHN1aXQuDQpGdWxsIEhvdXNlOiBUaHJlZSBvZiBhIGtpbmQgYW5kIGEgcGFpci4NCkZvdXIgb2YgYSBLaW5kOiBGb3VyIGNhcmRzIG9mIHRoZSBzYW1lIHZhbHVlLg0KU3RyYWlnaHQgRmx1c2g6IEFsbCBjYXJkcyBhcmUgY29uc2VjdXRpdmUgdmFsdWVzIG9mIHNhbWUgc3VpdC4NClJveWFsIEZsdXNoOiBUZW4sIEphY2ssIFF1ZWVuLCBLaW5nLCBBY2UsIGluIHNhbWUgc3VpdC4NClRoZSBjYXJkcyBhcmUgdmFsdWVkIGluIHRoZSBvcmRlcjoNCjIsIDMsIDQsIDUsIDYsIDcsIDgsIDksIDEwLCBKYWNrLCBRdWVlbiwgS2luZywgQWNlLg0KDQpJZiB0d28gcGxheWVycyBoYXZlIHRoZSBzYW1lIHJhbmtlZCBoYW5kcyB0aGVuIHRoZSByYW5rIG1hZGUgdXAgb2YgdGhlIGhpZ2hlc3QgdmFsdWUgd2luczsgZm9yIGV4YW1wbGUsIGEgcGFpciBvZiBlaWdodHMgYmVhdHMgYSBwYWlyIG9mIGZpdmVzIChzZWUgZXhhbXBsZSAxIGJlbG93KS4gQnV0IGlmIHR3byByYW5rcyB0aWUsIGZvciBleGFtcGxlLCBib3RoIHBsYXllcnMgaGF2ZSBhIHBhaXIgb2YgcXVlZW5zLCB0aGVuIGhpZ2hlc3QgY2FyZHMgaW4gZWFjaCBoYW5kIGFyZSBjb21wYXJlZCAoc2VlIGV4YW1wbGUgNCBiZWxvdyk7IGlmIHRoZSBoaWdoZXN0IGNhcmRzIHRpZSB0aGVuIHRoZSBuZXh0IGhpZ2hlc3QgY2FyZHMgYXJlIGNvbXBhcmVkLCBhbmQgc28gb24uDQoNCkNvbnNpZGVyIHRoZSBmb2xsb3dpbmcgZml2ZSBoYW5kcyBkZWFsdCB0byB0d28gcGxheWVyczoNCg0KMSAJNUggNUMgNlMgN1MgS0QNCglQYWlyIG9mIEZpdmVzDQogCTJDIDNTIDhTIDhEIFREDQoJUGFpciBvZiBFaWdodHMNCiAJUGxheWVyIDIgV2lucw0KDQoyCSA1RCA4QyA5UyBKUyBBQw0KCUhpZ2hlc3QgY2FyZCBBY2UNCiAJMkMgNUMgN0QgOFMgUUgNCglIaWdoZXN0IGNhcmQgUXVlZW4NCiAJUGxheWVyIDEgV2lucw0KDQozIAkyRCA5QyBBUyBBSCBBQw0KCVRocmVlIEFjZXMNCiAJM0QgNkQgN0QgVEQgUUQNCglGbHVzaCB3aXRoIERpYW1vbmRzDQogCVBsYXllciAyIFdpbnMNCg0KNAk0RCA2UyA5SCBRSCBRQw0KCVBhaXIgb2YgUXVlZW5zDQoJSGlnaGVzdCBjYXJkIE5pbmUNCiAJM0QgNkQgN0ggUUQgUVMNCglQYWlyIG9mIFF1ZWVucw0KCUhpZ2hlc3QgY2FyZCBTZXZlbg0KIAlQbGF5ZXIgMSBXaW5zDQoNCjUJMkggMkQgNEMgNEQgNFMNCglGdWxsIEhvdXNlDQoJV2l0aCBUaHJlZSBGb3Vycw0KIAkzQyAzRCAzUyA5UyA5RA0KCUZ1bGwgSG91c2UNCgl3aXRoIFRocmVlIFRocmVlcw0KIAlQbGF5ZXIgMSBXaW5zDQoNClRoZSBmaWxlLCBwb2tlci50eHQsIGNvbnRhaW5zIG9uZS10aG91c2FuZCByYW5kb20gaGFuZHMgZGVhbHQgdG8gdHdvIHBsYXllcnMuIEVhY2ggbGluZSBvZiB0aGUgZmlsZSBjb250YWlucyB0ZW4gY2FyZHMgKHNlcGFyYXRlZCBieSBhIHNpbmdsZSBzcGFjZSk6IHRoZSBmaXJzdCBmaXZlIGFyZSBQbGF5ZXIgMSdzIGNhcmRzIGFuZCB0aGUgbGFzdCBmaXZlIGFyZSBQbGF5ZXIgMidzIGNhcmRzLiBZb3UgY2FuIGFzc3VtZSB0aGF0IGFsbCBoYW5kcyBhcmUgdmFsaWQgKG5vIGludmFsaWQgY2hhcmFjdGVycyBvciByZXBlYXRlZCBjYXJkcyksIGVhY2ggcGxheWVyJ3MgaGFuZCBpcyBpbiBubyBzcGVjaWZpYyBvcmRlciwgYW5kIGluIGVhY2ggaGFuZCB0aGVyZSBpcyBhIGNsZWFyIHdpbm5lci4NCg0KSG93IG1hbnkgaGFuZHMgZG9lcyBQbGF5ZXIgMSB3aW4/";

            parametersInfo = new string[]
            {
                "t:fil - poker text file path"
            };

            defaultParameters = new string[]
            {
                "poker.txt"
            };

            ResetParameters();
        }

        public override string Solve()
        {
            var f = parameters[0];
            return findPokerHandsWon(f).ToString();
        }
        
        private long findPokerHandsWon(string f)
        {
            string[] pokerGames;

            using (var sr = new StreamReader(f))
            {
                pokerGames = sr.ReadToEnd().Split(new char[] { ' ', '\t', '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
            }

            var numOfCards = pokerGames.Length;
            var numOfGames = numOfCards / 10;

            var cards = new char[5];

            var countP1Won = 0;

            for (int i = 0; i < numOfCards; i += 10)
            {    
                var p1Flush = true;
                for (int j = 0; j < 5; j++)
                {
                    cards[j] = translateCard(pokerGames[i + j][0]);

                    if (j > 0 && pokerGames[i + j][1] != pokerGames[i + j - 1][1])
                    {
                        p1Flush = false;
                    }
                }
                var p1Cards = cards.OrderByDescending(c => c).ToArray();
                var p1Pairs = (p1Flush? 0 : hasPairs(p1Cards));

                var p2Flush = true;
                for (int j = 0; j < 5; j++)
                {
                    cards[j] = translateCard(pokerGames[i + j + 5][0]);

                    if (j > 0 && pokerGames[i + j + 5][1] != pokerGames[i + j + 4][1])
                    {
                        p2Flush = false;
                    }
                }
                var p2Cards = cards.OrderByDescending(c => c).ToArray();
                var p2Pairs = (p2Flush? 0 : hasPairs(p2Cards));

                var p1Won = false;
                if (p1Flush)
                {
                    if (p2Flush)
                    {
                        if (isStraight(p1Cards))
                        {
                            if (isStraight(p2Cards))
                            {
                                if (isPlayer1Higher(p1Cards, p2Cards))
                                {
                                    p1Won = true;
                                }
                            }
                            else
                            {
                                p1Won = true;
                            }
                        }
                        else if (!isStraight(p2Cards))
                        {
                            if (isPlayer1Higher(p1Cards, p2Cards))
                            {
                                p1Won = true;
                            }
                        }
                    }
                    else if (p2Pairs > 3)
                    {
                        if (isStraight(p1Cards))
                        {
                            p1Won = true;
                        }
                    }
                    else
                    {
                        p1Won = true;
                    }
                }
                else
                {
                    if (isStraight(p1Cards))
                    {
                        if (isStraight(p2Cards))
                        {
                            if (isPlayer1Higher(p1Cards, p2Cards))
                            {
                                p1Won = true;
                            }
                        }
                        else if (p2Pairs < 4)
                        {
                            p1Won = true;
                        }
                    }
                    else if (p2Flush || isStraight(p2Cards))
                    {
                        if (p1Pairs > 3)
                        {
                            p1Won = true;
                        }
                    }
                    else if (p1Pairs > p2Pairs)
                    {
                        p1Won = true;
                    }
                    else if (p1Pairs == p2Pairs)
                    {
                        if (p1Pairs > 0)
                        {
                            if (isPlayer1HigherPair(p1Cards, p2Cards, p1Pairs))
                            {
                                p1Won = true;
                            }
                        }
                        else if (isPlayer1Higher(p1Cards, p2Cards))
                        {
                            p1Won = true;
                        }
                    }
                }

                if (p1Won)
                {
                    countP1Won++;
                }
            }

            return countP1Won;
        }

        private char translateCard(char cc)
        {
            if (cc < 'A')
            {
                return cc;
            }
            else
            {
                switch (cc)
                {
                    case 'T': return (char)('0' + 10);
                    case 'J': return (char)('0' + 11);
                    case 'Q': return (char)('0' + 12);
                    case 'K': return (char)('0' + 13);
                    case 'A': return (char)('0' + 14);
                }
            }
            throw new InvalidOperationException();
        }

        private bool isStraight(char[] cards)
        {
            for (int i = 0; i < 4; i++)
            {
                if (cards[i] - cards[i + 1] != 1)
                {
                    return false; //not straight
                }
            }
            return true;
        }

        private int hasPairs(char[] cards)
        {
            var count = new byte[13];

            for (int i = 0; i < 5; i++)
            {
                count[cards[i] - '2']++;
            }
            var pairs = 0;
            var three = false;

            for (int i = 0; i < 13; i++)
            {
                if (count[i] < 2)
                {
                    continue;
                }
                else if (count[i] == 2)
                {
                    pairs++;
                }
                else if (count[i] == 3)
                {
                    three = true;
                }
                else if (count[i] == 4)
                {
                    return 5; //four of a kind
                }
            }

            if (three)
            {
                if (pairs == 1)
                {
                    return 4; //full house
                }
                return 3; //three of a kind
            }

            return pairs; //two, one or no pairs
        }

        private bool isPlayer1Higher(char[] p1Cards, char[] p2Cards)
        {
            for (int i = 0; i < 5; i++)
            {
                if (p1Cards[i] > p2Cards[i])
                {
                    return true;
                }
                else if (p2Cards[i] > p1Cards[i])
                {
                    return false;
                }
            }

            return false;
        }

        private bool isPlayer1HigherPair(char[] p1Cards, char[] p2Cards, int pairLevel)
        {
            var p1Count = new byte[13];
            var p2Count = new byte[13];

            for (int i = 0; i < 5; i++)
            {
                p1Count[p1Cards[i] - '2']++;
                p2Count[p2Cards[i] - '2']++;
            }

            if (pairLevel == 4)
            {
                var p1High = Array.IndexOf<byte>(p1Count, 3);
                var p2High = Array.IndexOf<byte>(p2Count, 3);

                if (p1High > p2High)
                {
                    return true;
                }
                else if (p1High == p2High)
                {
                    p1High = Array.IndexOf<byte>(p1Count, 2);
                    p2High = Array.IndexOf<byte>(p2Count, 2);

                    if (p1High > p2High)
                    {
                        return true;
                    }
                    else if (p1High == p2High)
                    {
                        return isPlayer1Higher(p1Cards, p2Cards);
                    }
                }
            }
            else if (pairLevel == 2)
            {
                var p1A = Array.IndexOf<byte>(p1Count, 2);
                var p1B = Array.LastIndexOf<byte>(p1Count, 2);
                if (p1B > p1A)
                {
                    var t = p1A;
                    p1A = p1B;
                    p1B = t;
                }

                var p2A = Array.IndexOf<byte>(p2Count, 2);
                var p2B = Array.LastIndexOf<byte>(p2Count, 2);
                if (p2B > p2A)
                {
                    var t = p2A;
                    p2A = p2B;
                    p2B = t;
                }

                if (p1A > p2A)
                {
                    return true;
                }
                else if (p1A == p2A)
                {
                    if (p1B > p2B)
                    {
                        return true;
                    }
                    else if (p1B == p2B)
                    {
                        return isPlayer1Higher(p1Cards, p2Cards);
                    }
                }
            }
            else
            {
                var pairLen = (byte)pairLevel;
                if (pairLevel == 5)
                {
                    pairLen = 4;
                }
                else if (pairLevel == 1)
                {
                    pairLen = 2;
                }

                var p1High = Array.IndexOf<byte>(p1Count, pairLen);
                var p2High = Array.IndexOf<byte>(p2Count, pairLen);

                if (p1High > p2High)
                {
                    return true;
                }
                else if (p1High == p2High)
                {
                    return isPlayer1Higher(p1Cards, p2Cards);
                }
            }

            return false;
        }

    }
}
