
using System;
using System.Diagnostics;
using System.Xml.Linq;
using Combi;
using Combinatorics;

namespace lab_2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string[] set = { "1", "2", "3", "4", "5" };
            Console.WriteLine("Множество: ");

            foreach (string s in set)
            {
                Console.Write(s + ' ');
            }


            Console.WriteLine("Задание 1:");

            List<List<string>> subsets = Subsets.getSubsets(set);
            Console.WriteLine("\nПодмножества:");
            foreach (var subset in subsets)
            {
                Console.WriteLine(string.Join(" ", subset));
            }

            Console.WriteLine("Задание 2:");

            Console.WriteLine("Введите размер комбинаций сочетания:");
            int k = int.Parse(Console.ReadLine());

            List<List<string>> combinations = Combinations.GenerateCombinations(set, k);
            Console.WriteLine("Комбинации: ");
            foreach (var combination in combinations)
            {
                Console.WriteLine(string.Join(" ", combination));
            }

            Console.WriteLine("Задание 3:");

            List<int> elements = new List<int> { 1, 2, 3, 4 };
            Permutation permutation = new Permutation(elements);

            permutation.GeneratePermutations();

            int permutationNumber = 0;
            List<int> currentPermutation;

            while ((currentPermutation = permutation.GetNextPermutation()) != null)
            {
                Console.Write($"{permutationNumber + 1}: {{ ");
                Console.Write(string.Join(", ", currentPermutation));
                Console.WriteLine(" }");
                permutationNumber++;
            }

            Console.WriteLine("Задание 4:");
            Console.WriteLine();

            List<int> elementList = new List<int> { 1, 2, 3, 4 };
            Console.Write("Введите m =");
            int m = int.Parse(Console.ReadLine());
            Accommodation accommodation = new Accommodation(elementList, m);

            List<int> currentArrangement;
            int arrangementNumber = 0;

            while ((currentArrangement = accommodation.GetNext()) != null)
            {
                Console.Write($"{arrangementNumber}: {{ ");
                Console.Write(string.Join(", ", currentArrangement));
                Console.WriteLine(" }");
                arrangementNumber++;
            }

            Console.WriteLine("Задание 5:");


            Console.Write("--Задача о рюкзаке--\n");
            int capacity = 30;
            int[] weights = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 , 13 };
            int[] values = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 , 13 };

            Random random = new Random();

            for (int i = 12; i < 21;i++)
            {
                Stopwatch sw = new Stopwatch();
                weights = new int[i];
                values = new int[i];

                for (int j = 0; j < i; j++)
                {
                    weights[j] = random.Next(1, 101);
                    values[j] = random.Next(1, 101);
                }

                sw.Start();

                KnapsackSolver.SolveKnapsack(capacity, weights, values);

                sw.Stop();

                Console.WriteLine($"Время выполнения: {sw.ElapsedTicks * 100.0 / Stopwatch.Frequency} наносекунд");


            }









        }

    }
}