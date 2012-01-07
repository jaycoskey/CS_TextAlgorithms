using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TextAlgorithms
{
    class StringDistance
    {
        enum DistanceType { Levenshtein, OptimalStringAlignment };
 
        private static int min3(int a, int b, int c)
        {
            return Math.Min(Math.Min(a, b), c);
        }

        private const int DELETION_COST = 1;
        private const int INSERTION_COST = 1;
        private const int SUBSTITUTION_COST = 1;
        private const int TRANSPOSITION_COST = 1;

        public static int CostOfDeletion(char c)
        {
            //System.Diagnostics.Debug.WriteLine("Considering deleting character {0:c}", c);
            return DELETION_COST;
        }

        public static int CostOfInsertion(char c)
        {
            //System.Diagnostics.Debug.WriteLine("Considering inserting character {0:c}", c);
            return INSERTION_COST;
        }

        public static int CostOfSubstitution(char c1, char c2)
        {
            //System.Diagnostics.Debug.WriteLine("Considering substituting {0:c} -> {1:c}", c1, c2);
            return SUBSTITUTION_COST;
        }

        public static int CostOfTransposition(char c1, char c2)
        {
            //System.Diagnostics.Debug.WriteLine("Considering transposing characters {0:c} and {1:c}", c1, c2);
            return TRANSPOSITION_COST;
        }

        [System.Diagnostics.Conditional("DEBUG")]
        private static void printDistanceMatrix(string src, string dst, int [,] d, string header) {
            System.Diagnostics.Debug.WriteLine(header);

            if (dst.Length > 0)
            {
                // Banner w/ dst indices
                System.Diagnostics.Debug.Write("\t          ");
                for (int j = 0; j <= dst.Length; j++)
                {
                    System.Diagnostics.Debug.Write(String.Format("{0,5}  ", j.ToString()));
                }
                System.Diagnostics.Debug.WriteLine(string.Empty);

                // Banner w/ dst characters
                System.Diagnostics.Debug.Write("\t                 ");
                for (int j = 0; j < dst.Length; j++)
                {
                    System.Diagnostics.Debug.Write(String.Format("{0,5}  ", dst[j]));
                }
                System.Diagnostics.Debug.WriteLine(string.Empty);
            }

            // Body of distance matrix
            for (int i = 0; i <= src.Length; i++)
            {
                char c = i == 0 ? ' ' : src[i - 1];
                System.Diagnostics.Debug.Write(String.Format("\t{0,5}({1:s}): ", i.ToString(), c.ToString()));
                for (int j = 0; j <= dst.Length; j++)
                {
                    System.Diagnostics.Debug.Write(String.Format("{0,5}  ", d[i, j].ToString()));
                }
                System.Diagnostics.Debug.WriteLine(string.Empty);
            }
        }

        public static int DamerauLevenshteinDistance(string src, string dst)
        {
            if (src == null || dst == null)
            {
                throw new Exception("Null argument passed to DamerauLevenshteinDistance");
            }
 
            int m = src.Length;
            int n = dst.Length;
            int[,] d = new int[m + 2, n + 2];

            d[0, 0] = 0;
            for (int i = 1; i <= m; i++)
            {
                d[i, 0] = d[i - 1, 0] + CostOfDeletion(src[i - 1]);
            }
            for (int j = 1; j <= n; j++)
            {
                d[0, j] = d[0, j - 1] + CostOfInsertion(dst[j - 1]);
            }

            SortedDictionary<char, int> chars = new SortedDictionary<char, int>();
            foreach (char c in (src + dst))
            {
                if (!chars.ContainsKey(c)) {
                    chars.Add(c, 0);
                }
            }

            for (int i = 1; i <= m; i++)
            {
                int jPrevMatch = 0;
                for (int j = 1; j <= n; j++)
                {
                    int iPrev = chars[dst[j - 1]];  
                    int jPrev = jPrevMatch;
                    //System.Diagnostics.Debug.WriteLine(
                    //    "INFO: At ({0:d}, {1:d}): (iPrev, jPrev)=({2:d}, {3:d})",
                    //    i, j, iPrev, jPrev);
                    int newCost;
                    if (src[i - 1] == dst[j - 1])
                    {
                        newCost = d[i - 1, j - 1];
                        jPrevMatch = j;
                        //System.Diagnostics.Debug.WriteLine(
                        //    "INFO: At ({0:d}, {1:d}): jPrevMatch={2:d}",
                        //    i, j, jPrevMatch);
                    }
                    else
                    {
                        int delCost = d[i - 1, j] + CostOfDeletion(src[i - 1]);
                        int insCost = d[i, j - 1] + CostOfInsertion(dst[j - 1]);
                        int subCost = d[i - 1, j - 1] + CostOfSubstitution(src[i - 1], dst[j - 1]);
                        //System.Diagnostics.Debug.WriteLine(
                        //    "INFO: At ({0:d}, {1:d}): "
                        //    + "subCost={2:d}, insCost={3:d}, delCost={4:d}",
                        //    i, j, subCost, insCost, delCost);
                        newCost = min3(delCost, insCost, subCost);
                    }
                    if (iPrev > 0 && jPrev > 0)
                    {
                        // This comment provides a simplification where the costs for individual
                        // deletions, insertions, and transpositions are independent of position,
                        // or the characters involved.
                        // int numDeletions = i - iPrev - 1;  // Delete chars b/w iPrev-1 and i-1
                        // int numInsertions = j - jPrev - 1; // Insert chars b/w jPrev-1 and j-1
                        // int transCost = d[iPrev - 1, jPrev - 1]
                        //    + numDeletions * DELETION_COST
                        //    + numInsertions * INSERTION_COST
                        //    + TRANSPOSITION_COST; // Swap src[iPrev-1], src[i-1] to get dst[jPrev-1], dst[j-1]
                        int tDelCost = 0;
                        for (int k = iPrev; k < i - 1; k++)
                        {
                            tDelCost += CostOfDeletion(src[k]);
                        }
                        int tInsCost = 0;
                        for (int k = jPrev; k < j - 1; k++)
                        {
                            tInsCost += CostOfInsertion(dst[k]);
                        }
                        int tTransCost = CostOfTransposition(src[iPrev - 1], src[i - 1]);
                        int transCost = tDelCost + tInsCost + tTransCost;

                        //System.Diagnostics.Debug.WriteLine(
                        //    "INFO: At ({0:d}, {1:d}):"
                        //    + " Moving src[{2:d}]='{3:c}' to dst[{4:d}]='{5:c}'"
                        //    + " and src[{6:d}]='{7:c}' to dst[{8:d}]='{9:c}'"
                        //    + " costs {10:d} = {11:d} (del) + {12:d} (ins) + {13:d} (trans)",
                        //    i, j,
                        //    iPrev - 1, src[iPrev - 1], j - 1, dst[j - 1],
                        //    jPrev - 1, dst[jPrev - 1], i - 1, src[i - 1],
                        //    transCost, tDelCost, tInsCost, tTransCost
                        //    );
                        //if (transCost < newCost)
                        //{
                        //    System.Diagnostics.Debug.WriteLine(
                        //        "INFO: At ({0:d}, {1:d}): transCost < newCost",
                        //        i, j);
                        //}
                        //else
                        //{
                        //    System.Diagnostics.Debug.WriteLine(
                        //        "INFO: At ({0:d}, {1:d}): "
                        //        + "newCost (={2:d}) <= transCost (={3:d})",
                        //        + i, j, newCost, transCost);
                        //}
                        newCost = Math.Min(newCost, transCost);
                    }
                    d[i, j] = newCost;
                    //System.Diagnostics.Debug.WriteLine("INFO: d[{0:d}, {1:d}]={2:d}", i, j, d[i, j]);
                }
                chars[src[i - 1]] = i ;   // chars[c] = most recent src index where the (i-1)st char of src was seen.
                    //System.Diagnostics.Debug.WriteLine("chars[{0:c}] = {1:d}", src[i - 1], i);
            }
            //printDistanceMatrix(src, dst, d, "Damerau-Levenshtein distance:");
            return d[m, n];
        }

        private static int LevenshteinOrOptimalStringAlignmentDistance(string src, string dst, DistanceType dType)
        {
            // for all i and j, d[i,j] will hold the Levenshtein distance between
            // the first i characters of textBox1 and the first j characters of textBox2;
            // note that d has (m+1) * (n+1) values
            int m = src.Length;
            int n = dst.Length;
            int[,] d = new int[m + 1, n + 1];

            d[0, 0] = 0;    // The distance between two empty strings
            // d[i, 0] = the distance from src (of length i) to an empty dst
            // d[0, j] = the distance from an empty src to an dst (of length j)
            for (int i = 1; i <= m; i++) {
                d[i, 0] = d[i - 1, 0] + CostOfDeletion(src[i - 1]);
            }
            for (int j = 1; j <= n; j++) {
                d[0, j] = d[0, j - 1] + CostOfInsertion(dst[j - 1]);
            }

            for (int i = 1; i <= m; i++)
            {
                for (int j = 1; j <= n; j++)
                {
                    if (src[i - 1] == dst[j - 1])
                    {
                        d[i, j] = d[i - 1, j - 1];  // no additional cost
                    }
                    else
                    {
                        int delCost = d[i - 1, j] + CostOfDeletion(src[i - 1]);      // delete src[i-1] to get dst
                        int insCost = d[i, j - 1] + CostOfInsertion(dst[j - 1]);     // insert dst[j-1] into src
                        int subCost = d[i - 1, j - 1] + CostOfSubstitution(src[i - 1], dst[j - 1]);   // change src[i-1] to dst[j-1]

                        //if (delCost <= Math.Min(insCost, subCost))
                        //{
                        //    System.Diagnostics.Debug.WriteLine("(i, j)=({0:d}, {1:d}): delCost={2:d}: deletion of {3:c}",
                        //        i, j, delCost, src[i - 1]);
                        //}
                        //if (insCost <= Math.Min(delCost, subCost))
                        //{
                        //    System.Diagnostics.Debug.WriteLine("(i, j)=({0:d}, {1:d}): insCost={2:d}: insertion of {3:c}",
                        //        i, j, insCost, dst[j - 1]);
                        //}
                        //if (subCost <= Math.Min(delCost, insCost))
                        //{
                        //    System.Diagnostics.Debug.WriteLine("(i, j)=({0:d}, {1:d}): subCost={2:d}: sub from {3:c} -> {4:c}",
                        //        i, j, subCost, src[i - 1], dst[j - 1]);
                        //}

                        int newCost = min3(delCost, insCost, subCost);
                        if (dType == DistanceType.OptimalStringAlignment
                            && i > 1
                            && j > 1
                            && (src[i - 1] == dst[j - 2])
                            && (src[i - 2] == dst[j - 1])
                         )
                        {
                            newCost = Math.Min(newCost, d[i - 2, j - 2] + CostOfTransposition(src[i - 2], src[i - 1]));
                        }
                        d[i, j] = newCost;
                    }
                    //System.Diagnostics.Debug.WriteLine("\td[{0:d},{1:d}]={2:d}", i, j, d[i, j]);
                }
            }
            //printDistanceMatrix(src, dst, d, dType == DistanceType.Levenshtein
            //    ? "Levenshtein distance:" : "Optimal string alignment distance:");
            return d[m, n];
        }

        public static int LevenshteinDistance(string src, string dst)
        {
            return LevenshteinOrOptimalStringAlignmentDistance(src, dst, DistanceType.Levenshtein);
        }

        public static int OptimalStringAlignmentDistance(string src, string dst)
        {
            return LevenshteinOrOptimalStringAlignmentDistance(src, dst, DistanceType.OptimalStringAlignment);
        }
    }
}