using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stringDestroyer
{
    class Program
    {
        static void Main(string[] args)
        {
            string num = "1..2..3", newNum = null;
            foreach(char i in num)
                if (i != '.') newNum += i;
            int usingInt = Convert.ToInt32(newNum);

            if (usingInt < 1024)
                return newNum;
            else
                //return (usingInt - 1024).ToString();
                Console.WriteLine(usingInt - 1024);


        }
    }
}
