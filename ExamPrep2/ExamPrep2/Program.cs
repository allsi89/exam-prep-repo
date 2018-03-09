using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Text.RegularExpressions;

namespace SnowMen
{
 
    class Program
    {
        static void Main(string[] args)
        {
            List<int> snowmen = Console.ReadLine()
                 .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                 .Select(int.Parse)
                 .ToList();
            while (snowmen.Count > 1)
            {
                List<int> skipList = new List<int>();
                for (int i = 0; i < snowmen.Count; i++)
                {
                    int attacker = i;
                    int target = snowmen[i];
                    if (target >= snowmen.Count)
                    {
                        target = target % snowmen.Count;
                    }
                    if (skipList.Contains(i))
                    {
                        continue;
                    }
                    int difference = Math.Abs(target - attacker);
                    if (difference == 0)
                    {
                        Console.WriteLine($"{attacker} performed harakiri");
                        skipList.Add(attacker);

                    }
                    else
                    {
                        if (difference % 2 == 0)
                        {
                            Console.WriteLine($"{attacker} x {target} -> {attacker} wins");
                            skipList.Add(target);
                        }
                        else
                        {
                            Console.WriteLine($"{attacker} x {target} -> {target} wins");
                            skipList.Add(attacker);
                        }
                    }
                    skipList = skipList.Distinct().ToList();
                    if (Math.Abs(skipList.Count - snowmen.Count) == 1)
                    {
                        break;
                    }

                }

                snowmen = GetNewList(skipList, snowmen);
            }
        }

        private static List<int> GetNewList(List<int> skipList, List<int> snowmen)
        {
            skipList = skipList.OrderByDescending(x => x).ToList();
            for (int i = snowmen.Count - 1; i >= 0; i--)
            {
                if (skipList.Contains(i))
                {
                    snowmen.RemoveAt(i);
                }

            }
            return snowmen;
        }
    }
}


