using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RacingResource.Utilities
{
    public static class StringUtilities
    {
        public static string FormatWeight(int weight)
        {
            int stones = weight / 14;
            int pounds = weight % 14;
            return string .Format("{0}-{1}",stones.ToString(), pounds.ToString());
        }

        public static string DoubleToFraction(double num, double epsilon = 0.0001, int maxIterations = 20)
        {
            if (num != 0)
            {
                double[] d = new double[maxIterations + 2];
                d[1] = 1;
                double z = num;
                double n = 1;
                int t = 1;

                while (t < maxIterations && Math.Abs(n / d[t] - num) > epsilon)
                {
                    t++;
                    z = 1 / (z - (int)z);
                    d[t] = d[t - 1] * (int)z + d[t - 2];
                    n = (int)(num * d[t] + 0.5);
                }

                return string.Format("{0}/{1}",
                                     n.ToString(),
                                     d[t].ToString()
                                    ).ToRacingOdds();
            }
            return string.Empty;
        }

        public static string ToRacingOdds(this string odds)
        {
            switch (odds)
                {
                case @"3/2":
                    return @"6/4";
                case @"2/3":
                    return @"4/6";
                case @"10/3":
                    return @"100/30";
                 case @"3/10":
                    return @"30/100";
                default:
                    return odds;
                }
        }
    }


}