using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace Snowflake
{
    class Program
    {
        static void Main(string[] args)
        {
            bool[] isValid = new bool[5];
            string core = "";
            string check = "";
            for (int i = 0; i < 5; i++)
            {
                string snowflake = Console.ReadLine();
                isValid[i] = false;
                if (i == 2)
                {
                    string pattern = @"(?:[^A-Za-z0-9]+)[\d|_]+([A-Z-a-z]+)[\d|_]+(?:[^A-Za-z0-9]+)";
                    isValid[i] = GetRegexMatch(snowflake, pattern);
                    core = Regex.Match(snowflake, pattern: @"[A-Za-z]+").Value;
                    check = Regex.Match(snowflake, pattern).Value;

                }
                else if (i % 2 == 0)
                {
                    string surface = @"(?:[^A-Za-z0-9]+)";
                    isValid[i] = GetRegexMatch(snowflake, surface);
                    check = Regex.Match(snowflake, surface).Value;
                }
                else
                {
                    string mantle = @"[\d|_]+";
                    isValid[i] = GetRegexMatch(snowflake, mantle);
                    check = Regex.Match(snowflake, mantle).Value;
                }
                if (snowflake.Length != check.Length)
                {
                    isValid[i] = false;
                }
            }

            if (isValid.Contains(false))
            {
                Console.WriteLine("Invalid");
                return;
            }
            Console.WriteLine("Valid");
            Console.WriteLine(core.Length);
        }

        static bool GetRegexMatch(string snowflake, string pattern)
        {
            bool isMatch = false;
            if (Regex.IsMatch(snowflake, pattern))
            {
                isMatch = true;
            }
            return isMatch;
        }
    }
}
