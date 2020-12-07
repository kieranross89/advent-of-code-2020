using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.RegularExpressions;

namespace day2
{
    class Program
    {
        static void Main(string[] args)
        {
            var lines = ReadInputFromFile(args[0]).ToList();
            // var lines 
            var passwordValidity = new List<bool>();

            foreach (var line in lines)
            {
                var indexOfFirstColon = line.IndexOf(":");

                var r = new Regex(@"(\d+)-(\d+)");
                var policyRangeMatches = r.Match(line);

                var policyMin = Int32.Parse(policyRangeMatches.Groups[1].ToString());
                var policyMax = Int32.Parse(policyRangeMatches.Groups[2].ToString());
                
                var charForPolicy = line.Substring(indexOfFirstColon - 1, 1);
                var password = line.Substring(indexOfFirstColon + 1).Trim();

                var count = password.Split(charForPolicy).Length - 1;

                if (count >= policyMin && count <= policyMax)
                {
                    Console.WriteLine(true);
                    passwordValidity.Add(true);
                }
                else
                {
                    Console.WriteLine(false);
                    passwordValidity.Add(false);
                }
            }

            Console.WriteLine($"{passwordValidity.Count} passwords input: {passwordValidity.Where(x => x == true).Count()} passwords are valid. {passwordValidity.Where(x => x == false).Count()} passwords are invalid.");
        }

        internal static IEnumerable<string> ReadInputFromFile(string filename)
        {
            string line;
            var input = new List<string>();

            System.IO.StreamReader file = new System.IO.StreamReader(filename);
            while ((line = file.ReadLine()) != null)
            {
                input.Add(line);
            }

            file.Close();

            return input;
        }
    }
}
