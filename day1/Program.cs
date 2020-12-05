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

            var part1Result = Calculate.Part1Answer(numbers, target);
            Console.WriteLine($"Part 1 Answer: {part1Result}");

            var part2Result = Calculate.Part2Answer(numbers, target);
            Console.WriteLine($"Part 2 Answer: {part2Result}");
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
