using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TextAlgorithms
{
    class Palindrome {
        //public static List<string> LongestCommonPalindromes(string s1, string s2) {
        //    SuffixTree sTree = new SuffixTree(s1);
        //    sTree.AddSourceString(s2);
        //    List<string> result = sTree.GetLongestCommonPalindromes();
        //    return result;
        //}

        public static List<string> LongestPalindromes(string seq)
        {
            List<int> palLengths = PalindromeLengths(seq);
            //System.Diagnostics.Debug.Write("Palindrome lengths: ");
            //for (int i = 0; i < palLengths.Count; i++)
            //{
            //    System.Diagnostics.Debug.Write(String.Format("{0:d}, ", palLengths[i]));
            //}
            //System.Diagnostics.Debug.WriteLine(string.Empty);

            List<string> result = new List<string>();
            int maxPalLength = 0;
            for (int i = 0; i < palLengths.Count; i++)
            {
                maxPalLength = Math.Max(maxPalLength, palLengths[i]);
            }

            for (int i = 0; i < palLengths.Count; i++)
            {
                if (palLengths[i] == maxPalLength)
                {
                    int startIndex = (i - maxPalLength) / 2;
                    int length = maxPalLength;
                    string str = seq.Substring(startIndex, length);
                    //System.Diagnostics.Debug.WriteLine(String.Format(
                    //    "About to append palindrome: {0:s}", str)); 
                    result.Add(str); 
                }
            }
            return result;
        }

        public static List<int> PalindromeLengths(string seq)
        {
            int seqLen = seq.Length;
            List<int> l = new List<int>();
            int i = 0;
            int palLen = 0;
            int s = 0;
            int e = 0;
            // Loop invariant: seq[(i - palLen):i] is a palindrome.
            // Loop invariant: len(l) >= 2 * i - palLen. The code path that 
            //     increments palLen skips the l-filling inner-loop.
            // Loop invariant: len(l) < 2 * i + 1. Any code path that increments
            //     i past seqLen - 1 exits the loop early and so skips the
            //     l-filling inner loop.
            while (i < seqLen)
            {
                // First, see if we can extend the current palindrome.  Note that
                // the center of the palindrome remains fixed.
                if (i > palLen && seq[i - palLen - 1] == seq[i])
                {
                    palLen += 2;
                    i += 1;
                    continue;
                }
                l.Add(palLen);
                s = l.Count - 2;
                e = s - palLen;
                bool isPalLenModified = false;  // Hun1Ahpu on stackoverflow.com calls this found.
                for (int j = s; j > e; j--)
                {
                    int d = j - e - 1;
                    if (l[j] == d)
                    {
                        palLen = d;
                        isPalLenModified = true;
                        break;
                    }
                    l.Add(Math.Min(d, l[j]));
                }
                if (!isPalLenModified)
                {
                    palLen = 1;
                    i += 1;
                }
            }
            l.Add(palLen);
            return l;
        }

        public static List<string> LongestPalindromesWithErrors(string s, int numErrors)
        {
            // TODO: Replace with actual implementation
            List<string> result = new List<string>();
            result.Add("PalindromeWithErrorsA");
            result.Add("PalindromeWithErrorsB");
            return result;
        }
    }
}