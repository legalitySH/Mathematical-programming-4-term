using System;
using System.Collections.Generic;

namespace Combi
{
    public class Accommodation
    {
        private List<List<int>> arrangements;
        private List<int> elements;
        private int currentArrangementIndex;

        public int Na { get; private set; }

        public Accommodation(List<int> elements, int m)
        {
            if (elements == null || m <= 0 || m > elements.Count)
            {
                throw new ArgumentException("Invalid arguments");
            }

            this.elements = elements;
            arrangements = new List<List<int>>();
            currentArrangementIndex = -1;
            GenerateArrangements(m);
            Reset();
        }

        private void GenerateArrangements(int m)
        {
            arrangements.Clear();
            GenerateArrangements(new List<int>(), m);
        }

        private void GenerateArrangements(List<int> currentArrangement, int remaining)
        {
            if (remaining == 0)
            {
                arrangements.Add(new List<int>(currentArrangement));
                return;
            }

            for (int i = 0; i < elements.Count; i++)
            {
                if (!currentArrangement.Contains(elements[i]))
                {
                    currentArrangement.Add(elements[i]);
                    GenerateArrangements(currentArrangement, remaining - 1);
                    currentArrangement.RemoveAt(currentArrangement.Count - 1);
                }
            }
        }

        public void Reset()
        {
            Na = 0;
            currentArrangementIndex = -1;
        }

        public List<int> GetFirst()
        {
            if (arrangements.Count > 0)
            {
                currentArrangementIndex = 0;
                Na = 0;
                return arrangements[currentArrangementIndex];
            }
            return null;
        }

        public List<int> GetNext()
        {
            if (currentArrangementIndex < arrangements.Count - 1)
            {
                currentArrangementIndex++;
                Na++;
                return arrangements[currentArrangementIndex];
            }
            return null;
        }

        public int Count()
        {
            return arrangements.Count;
        }
    }
}