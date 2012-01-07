using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;

namespace TextAlgorithms
{
    class CommonSubset
    {
        private static List<string> backtrackAllLCS(
            int[,] C,
            string s1, string s2,
            int i, int j)
        {
            List<string> result = new List<string>();
            if (i == 0 || j == 0)
            {
                //System.Diagnostics.Debug.WriteLine(String.Format(
                //    "backtrackAllLCS ({0:d}, {1:d}: Returning empty string list",
                //    i, j));
                result.Add(string.Empty);
                return result;
            }
            else if (s1[i - 1] == s2[j - 1])
            {
                //System.Diagnostics.Debug.WriteLine(String.Format(
                //    "backtrackAllLCS ({0:d}, {1:d}): Found match.  Calling backtrackAllLCS",
                //    i, j));
                foreach (string common in backtrackAllLCS(C, s1, s2, i - 1, j - 1)) {
                    result.Add(common + s1[i - 1]);
                }
            }
            else
            {
                //System.Diagnostics.Debug.WriteLine(String.Format(
                //    "backtrackAllLCS ({0:d}, {1:d}): No match found.  Clearing string list",
                //    i, j));
                result.Clear();
                if (C[i, j - 1] >= C[i - 1, j])
                {
                    //System.Diagnostics.Debug.WriteLine(String.Format(
                    //    "backtrackAllLCS ({0:d}, {1:d}) (Alpha): About to call backtrackAllLCS",
                    //    i, j));
                    foreach (string str in backtrackAllLCS(C, s1, s2, i, j - 1))
                    {
                        //System.Diagnostics.Debug.WriteLine(String.Format(
                        //    "backtrackAllLCS ({0:d}, {1:d}) (Alpha): Adding string {2:s}",
                        //    i, j, str));
                        result.Add(str);
                    }
                }
                if (C[i - 1, j] >= C[i, j - 1])
                {
                    //System.Diagnostics.Debug.WriteLine(String.Format(
                    //    "backtrackAllLCS ({0:d}, {1:d}) (Beta): About to call backtrackAllLCS",
                    //    i, j));
                    foreach (string str in backtrackAllLCS(C, s1, s2, i - 1, j))
                    {
                        //System.Diagnostics.Debug.WriteLine(String.Format(
                        //    "backtrackAllLCS ({0:d}, {1:d}) (Beta): Adding string {2:s}",
                        //    i, j, str));
                        result.Add(str);
                    }
                }
            }

            //System.Diagnostics.Debug.Write(String.Format(
            //    "backtrackAllLCS ({0:d}, {1:d}): returning ({2:d}):", i, j, result.Count));
            //for (int k = 0; k < result.Count; k++)
            //{
            //    System.Diagnostics.Debug.Write(" \"{0:s}\"", result[k]);
            //}
            //System.Diagnostics.Debug.WriteLine(string.Empty);
            return result;
        }

        private static string backtrackLCS(
            int[,] C,
            string s1, string s2,
            int i, int j)
        {
            string result;
            if (i == 0 || j == 0)
            {
                result = string.Empty;
            }
            else if (s1[i - 1] == s2[j - 1])
            {
                result = backtrackLCS(C, s1, s2, i - 1, j - 1) + s1[i - 1];
            }
            else
            {
                if (C[i, j - 1] > C[i - 1, j])
                {
                    result = backtrackLCS(C, s1, s2, i, j - 1);
                }
                else
                {
                    result = backtrackLCS(C, s1, s2, i - 1, j);
                }
            }
            //System.Diagnostics.Debug.WriteLine("INFO: backtrackLCS: returning \"{0:s}\"", result);
            return result;
        }

        private static int[,] commonSubsequenceMatrix(string s1, string s2)
        {
            int m = s1.Length;
            int n = s2.Length;
            int[,] C = new int[m + 1, n + 1];

            for (int i = 0; i <= m; i++) { C[i, 0] = 0; }
            for (int j = 0; j <= n; j++) { C[0, j] = 0; }

            for (int i = 1; i <= m; i++)
            {
                for (int j = 1; j <= n; j++)
                {
                    if (s1[i - 1] == s2[j - 1])
                    {
                        C[i, j] = C[i - 1, j - 1] + 1;
                    }
                    else
                    {
                        C[i, j] = Math.Max(C[i, j - 1], C[i - 1, j]);
                    }
                }
            }
            printCommonSubsetMatrix(C, s1, s2, "Just computed common subseq matrix:");
            return C;
        }

        [System.Diagnostics.Conditional("DEBUG")]
        private static void printCommonSubsetMatrix(int [,] C, string s1, string s2, string header)
        {
            System.Diagnostics.Debug.WriteLine(header);

            if (s2.Length > 0)
            {
                // Banner w/ s2 indices
                System.Diagnostics.Debug.Write("\t          ");
                for (int j = 0; j <= s2.Length; j++)
                {
                    System.Diagnostics.Debug.Write(String.Format("{0,5}  ", j.ToString()));
                }
                System.Diagnostics.Debug.WriteLine(string.Empty);

                // Banner w/ dst characters
                System.Diagnostics.Debug.Write("\t                 ");
                for (int j = 0; j < s2.Length; j++)
                {
                    System.Diagnostics.Debug.Write(String.Format("{0,5}  ", s2[j]));
                }
                System.Diagnostics.Debug.WriteLine(string.Empty);
            }

            // Body of subseq matrix
            for (int i = 0; i <= s1.Length; i++)
            {
                char c = i == 0 ? ' ' : s1[i - 1];
                System.Diagnostics.Debug.Write(String.Format("\t{0,5}({1:s}): ", i.ToString(), c.ToString()));
                for (int j = 0; j <= s2.Length; j++)
                {
                    System.Diagnostics.Debug.Write(String.Format("{0,5}  ", C[i, j].ToString()));
                }
                System.Diagnostics.Debug.WriteLine(string.Empty);
            }
        }

        public static List<string> LongestCommonSubsequences(string s1, string s2)
        {
            List<string> result = new List<string>();
            if (string.IsNullOrEmpty(s1) || string.IsNullOrEmpty(s2))
            {
                return result;
            }

            int[,] C = commonSubsequenceMatrix(s1, s2);
            List<string> subsequences = backtrackAllLCS(C, s1, s2, s1.Length, s2.Length);
            return subsequences;
        }

        public static List<string> LongestCommonSubstrings(string s1, string s2) {
            List<string> result = new List<string>();
            if (String.IsNullOrEmpty(s1) || String.IsNullOrEmpty(s2))
            {
                return result;
            }
            int m = s1.Length;
            int n = s2.Length;
            int[,] L = new int[m, n];
            int longestLengthFound = 0;

            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (s1[i] == s2[j])
                    {
                        L[i, j] = (i == 0 | j == 0) ? 1 : L[i - 1, j - 1] + 1;
                        if (L[i, j] > longestLengthFound)
                        {
                            longestLengthFound = L[i, j];
                            result.Clear();
                        }
                        if (L[i, j] == longestLengthFound)
                        {
                            result.Add(s1.Substring(i - longestLengthFound + 1,
                                longestLengthFound));
                        }
                    }
                    else
                    {
                        L[i, j] = 0;
                    }
                }
            }
            return result;
        }
    }
}