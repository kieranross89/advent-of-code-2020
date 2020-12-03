using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace day1
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = ReadInputNumbersFromFile(args[0]).ToList();
            Int32.TryParse(args[1], out var target);


            var (index1, index2) = GetTwoSumIndexes(numbers, target);
            var sum = numbers[index1] + numbers[index2];
            var result = numbers[index1] * numbers[index2];
            Console.WriteLine(result);
        }

        internal static Tuple<int, int> GetTwoSumIndexes(IEnumerable<int> list, int target)
        {
            var lookup = new Dictionary<int, int>();

            foreach (var (number, index) in list.Select((n, i) => (n, i)))
            {
                var complement = target - number;
                Console.WriteLine($"Number:{number}, Index:{index}, Comp:{complement}");

                if (lookup.TryGetValue(complement, out var complementIndex))
                {
                    return new Tuple<int, int>(index, complementIndex);
                }

                if (!lookup.ContainsKey(number))
                {
                    lookup.Add(number, index);
                }
            }

            return null;
        }

        internal static IEnumerable<int> ReadInputNumbersFromFile(string filename)
        {
            string line;
            var numbers = new List<int>();

            System.IO.StreamReader file = new System.IO.StreamReader(filename);
            while ((line = file.ReadLine()) != null)
            {
                Int32.TryParse(line, out var number);
                numbers.Add(number);
            }

            file.Close();

            return numbers;
        }
    }
}
