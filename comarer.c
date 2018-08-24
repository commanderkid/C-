using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
    public class Program
    {
        static void Main(string[] args)
        {
            Solution MyDistance = new Solution();
            Console.WriteLine(MyDistance.HammingDistance(1, 4));
            Console.ReadKey();
        }
    }

    public class Solution
    {
        public int HammingDistance(int x, int y)
        {
            int ans = 0;
            string x1 = Convert.ToString(x, 2);
            string y1 = Convert.ToString(y, 2);
            y1 = y1.PadLeft(31, '0');
            x1 = x1.PadLeft(31, '0');
            for (int i = 0; i < 31; i++)
            {
                if (x1[i] != y1[i]) ans += 1;
            }
            return ans;
        }
    }
}
