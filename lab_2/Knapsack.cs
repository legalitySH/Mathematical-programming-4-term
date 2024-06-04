using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_2
{
    public class KnapsackSolver
    {
        public static int SolveKnapsack(int capacity, int[] weights, int[] values)
        {
            int n = weights.Length;
            List<List<int>> allSubsets = GetSubsets(n);

            List<int> bestSubset = new List<int>();
            int maxValue = 0;

            foreach (var subsetIndices in allSubsets)
            {
                int subsetWeight = CalculateSubsetWeight(subsetIndices, weights);

                if (subsetWeight <= capacity)
                {
                    int subsetValue = CalculateSubsetValue(subsetIndices, values);

                    if (subsetValue > maxValue)
                    {
                        maxValue = subsetValue;
                        bestSubset = new List<int>(subsetIndices);
                    }
                }
            }

            Console.WriteLine("Максимальный результат: {" + string.Join(", ", bestSubset) + "}");
            Console.WriteLine("Максимальная стоимость: " + maxValue);

            return maxValue;
        }

        private static List<List<int>> GetSubsets(int n)
        {
            List<List<int>> subsets = new List<List<int>>();
            string[] elements = new string[n];

            for (int i = 0; i < n; i++)
            {
                elements[i] = i.ToString();
            }

            List<List<string>> stringSubsets = Combinatorics.Subsets.getSubsets(elements);

            foreach (var stringSubset in stringSubsets)
            {
                List<int> intSubset = new List<int>();

                foreach (var element in stringSubset)
                {
                    intSubset.Add(int.Parse(element));
                }

                subsets.Add(intSubset);
            }

            return subsets;
        }

        private static int CalculateSubsetWeight(List<int> subsetIndices, int[] weights)
        {
            int weight = 0;
            foreach (int index in subsetIndices)
            {
                weight += weights[index];
            }
            return weight;
        }

        private static int CalculateSubsetValue(List<int> subsetIndices, int[] values)
        {
            int value = 0;
            foreach (int index in subsetIndices)
            {
                value += values[index];
            }
            return value;
        }
    }
}
