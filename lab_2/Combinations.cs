using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Combinatorics
{
    public static class Combinations
    {

        public static List<List<string>> GenerateCombinations(string[] elements, int k)
        {
            List<List<string>> combinations = new List<List<string>>();
            int n = elements.Length;

            void Generate(int start, List<string> currentCombination)
            {
                if (currentCombination.Count == k)
                {
                    combinations.Add(new List<string>(currentCombination));
                    return;
                }

                for (int i = start; i < n; i++)
                {
                    currentCombination.Add(elements[i]);
                    Generate(i + 1, currentCombination);
                    currentCombination.RemoveAt(currentCombination.Count - 1);
                }
            }

            Generate(0, new List<string>());

            return combinations;
        }


    }
}
