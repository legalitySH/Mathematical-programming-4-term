using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Combinatorics
{
    public class Subsets
    {
        public static List<List<string>> getSubsets(string[] elements)
        {
            List<List<string>> subsets = new List<List<string>>();
            int n = elements.Length;

            for (int i = 0; i < (1 << n); i++)
            {
                List<string> subset = new List<string>();

                for (int j = 0; j < n; j++)
                {
                    if ((i & (1 << j)) != 0)
                    {
                        subset.Add(elements[j]);
                    }
                }

                subsets.Add(subset);
            }

            return subsets;
        }
    }

}
