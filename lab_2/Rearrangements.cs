using System;
using System.Collections.Generic;

namespace Combinatorics
{
    public class Permutation
    {
        private readonly List<int> elements;
        private readonly List<List<int>> permutations;
        private int currentPermutationIndex;

        public Permutation(List<int> elements)
        {
            this.elements = elements ?? throw new ArgumentNullException(nameof(elements));
            permutations = new List<List<int>>();
            currentPermutationIndex = -1;
        }

        public void GeneratePermutations()
        {
            permutations.Clear();
            GeneratePermutations(elements.Count);
            currentPermutationIndex = -1;
        }

        private void GeneratePermutations(int n)
        {
            if (n == 1)
            {
                permutations.Add(new List<int>(elements));
                return;
            }

            for (int i = 0; i < n; i++)
            {
                GeneratePermutations(n - 1);

                if (n % 2 == 0)
                {
                    Swap(i, n - 1);
                }
                else
                {
                    Swap(0, n - 1);
                }
            }
        }

        private void Swap(int i, int j)
        {
            int temp = elements[i];
            elements[i] = elements[j];
            elements[j] = temp;
        }

        public List<int> GetNextPermutation()
        {
            if (currentPermutationIndex < permutations.Count - 1)
            {
                currentPermutationIndex++;
                return permutations[currentPermutationIndex];
            }

            return default;
        }

        public void Reset()
        {
            currentPermutationIndex = -1;
        }
    }
}