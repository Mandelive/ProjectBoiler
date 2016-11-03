using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boilerplate
{
    public class BoilStrings
    {
        public static bool IsPalindrome(string s)
        {
            var mid = s.Length / 2;
            var end = s.Length - 1;
            for (int i = 0; i < mid; i++)
            {
                if (s[i] != s[end - i])
                {
                    return false;
                }
            }
            return true;
        }

        public static int CountCharInString(char c, string s)
        {
            int count = 0;
            var charArray = s.ToCharArray();

            for (int i = 0; i < charArray.Length; i++)
            {
                if (charArray[i] == c)
                {
                    count++;
                }
            }
            return count;
        }
    }
}
