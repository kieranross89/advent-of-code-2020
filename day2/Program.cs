using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.RegularExpressions;
using System.IO;
using System.Text;

namespace day2
{
    class Program
    {
        static void Main(string[] args)
        {
            var lines = ReadInputFromFile(args[0]).ToList();
            var passwordPolicies = ParseInputPasswordPolicies(lines);

            // Part 1
            var result1 = passwordPolicies.Select(x => x.GetPart1Answer());
            Console.WriteLine($"Part 1: {result1.Count()} passwords input: {result1.Where(x => x == true).Count()} passwords are valid. {result1.Where(x => x == false).Count()} passwords are invalid.");

            // Part 2
            var result2 = passwordPolicies.Select(x => x.GetPart2Answer());
            Console.WriteLine($"Part 2: {result2.Count()} passwords input: {result2.Where(x => x == true).Count()} passwords are valid. {result2.Where(x => x == false).Count()} passwords are invalid.");
        }

        private static IEnumerable<PasswordPolicy> ParseInputPasswordPolicies(IEnumerable<string> lines)
        {
            var regex = new Regex(@"(\d+)-(\d+) (\w): (\w+)");
            return lines.Select(l => {
                var matches = regex.Match(l);
                return new PasswordPolicy(
                    min: Int32.Parse(matches.Groups[1].ToString()),
                    max: Int32.Parse(matches.Groups[2].ToString()),
                    requiredCharacter: matches.Groups[3].ToString(),
                    password: matches.Groups[4].ToString()
                );
            });
        }

        internal static IEnumerable<string> ReadInputFromFile(string filename)
        {
            return File.ReadAllLines(filename);
        }
    }
}
