using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace day4
{
    partial class Program
    {
        
        static void Main(string[] args)
        {
            var inputs = ParseInput(args[0]);

            var result1 = new List<bool>();
            foreach(var input in inputs)
            {
                result1.Add(Part1ValidatePassport(input));
            }
            
            Console.WriteLine($"{result1.Where(x => x == true).Count()} passports are valid. {result1.Where(x => x == false).Count()} passports are invalid");
        }

        internal static IEnumerable<Dictionary<string, string>> ParseInput(string filename)
        {
             var contents = File.ReadAllText(filename);
             var lookup = new Dictionary<string, string>();
             // TODO this is nasty do better
             return contents.Split("\r\n\r\n").Select(r => r.Replace("\r\n", " ").Split(' ').Select(x => x.Split(':')).ToDictionary(k => k[0], v => v[1]));
        }

        internal static bool Part1ValidatePassport(Dictionary<string, string> passport)
        {
            var requiredField = new string[] {"byr","iyr","eyr","hgt","hcl","ecl","pid"};
            return requiredField.All(passport.ContainsKey);
        }
    }
}
