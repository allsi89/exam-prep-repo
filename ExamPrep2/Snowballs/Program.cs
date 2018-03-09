using System;
using System.Numerics;

namespace Snowballs
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            BigInteger value = -1;
            BigInteger sbValue = 0;
            int[] sbData = new int[3];
            for (int i = 0; i < n; i++)
            {
                int snowballSnow = int.Parse(Console.ReadLine());
                int snowballTime = int.Parse(Console.ReadLine());
                int snowballQuality = int.Parse(Console.ReadLine());
                sbValue = BigInteger.Pow(snowballSnow / snowballTime, snowballQuality);
                if (sbValue > value)
                {

                    value = sbValue;
                    sbData[0] = snowballSnow;
                    sbData[1] = snowballTime;
                    sbData[2] = snowballQuality;
                }
            }
            Console.WriteLine($"{sbData[0]} : {sbData[1]} = {value} ({sbData[2]})");
        }
    }
}
