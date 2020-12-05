using System;
using System.Collections.Generic;
using System.Linq;

namespace day1
{
    public static class Calculate
    {
        public static int Part1Answer(IEnumerable<int> numbers, int target)
        {
            var lookup = new HashSet<int>();

            foreach (var number in numbers)
            {
                if (lookup.TryGetValue(target - number, out var value))
                {
                    return number * value;
                }

                if (!lookup.Contains(number))
                {
                    lookup.Add(number);
                }
            }

            return 0;
        }

        public static int Part2Answer(IEnumerable<int> numbers, int target)
        {
            int result = 0;
            var lookup = new HashSet<int>();
            var numbersList = numbers.ToList<int>();
            // Not happy with uses of for loop want to try find foreach solution using collection
            for (int i = 0; i < numbersList.Count - 2; i++)
            {
                var currentSum = target - numbersList[i];
                for (int i2 = i + 1; i2 < numbersList.Count; i2++)
                {
                    if (lookup.Contains(currentSum - numbersList[i2]))
                    {
                        result = numbersList[i] * numbersList[i2] * (currentSum - numbersList[i2]);
                    }
                    else
                    {
                        lookup.Add(numbersList[i2]);
                    }
                }
            }
            return result > 0 ? result : throw new Exception("No matches found in input numbers");
        }
    }
}