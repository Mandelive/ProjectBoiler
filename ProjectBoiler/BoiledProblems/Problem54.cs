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

        private enum Cards { Two = 2, Three, Four, Five, Six, Seven, Eight, Nine, Ten, Jack, Queen, King, Ace };
        private enum Suits { Clubs, Spades, Hearts, Diamonds };
        
        private long findPokerHandsWon(string f)
        {
            string[] pokerGames;

            using (var sr = new StreamReader(f))
            {
                pokerGames = sr.ReadToEnd().Split(new char[] { ' ', '\t', '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
            }

            var numOfGames = pokerGames.Length;

            var player1 = new List<KeyValuePair<Suits, Cards>>(numOfGames);
            var player2 = new List<KeyValuePair<Suits, Cards>>(numOfGames);


            var currPlayer = player1;
            for (int i = 0; i < numOfGames; i++)
            {
                if (i % 5 == 0)
                {
                    if ((i & 1) == 0)
                    {
                        currPlayer = player1;
                    }
                    else
                    {
                        currPlayer = player2;
                    }
                }

                var cc = pokerGames[i][0];
                var cs = pokerGames[i][1];

                Cards card = Cards.Two;
                if (cc < 'A')
                {
                    card = (Cards)(cc - '0');
                }
                else
                {
                    switch (cc)
                    {
                        case 'T': card = Cards.Ten; break;
                        case 'J': card = Cards.Jack; break;
                        case 'Q': card = Cards.Queen; break;
                        case 'K': card = Cards.King; break;
                        case 'A': card = Cards.Ace; break;
                    }
                }

                Suits suit = Suits.Clubs;
                switch (cs)
                {
                    case 'C': suit = Suits.Clubs; break;
                    case 'S': suit = Suits.Spades; break;
                    case 'H': suit = Suits.Hearts; break;
                    case 'D': suit = Suits.Diamonds; break;
                }

                currPlayer.Add(new KeyValuePair<Suits, Cards>(suit, card));
            }

            
            
            return (int)player1[3].Value;
        }
    }
}
