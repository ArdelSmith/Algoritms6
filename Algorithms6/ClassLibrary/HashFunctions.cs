using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public static class HashFunctions
    {
        public static string HashOne(string elem)
        {
            int e = int.Parse(elem);
            int hash = (int) (Math.Sqrt(Math.Sqrt(e)) * 10000 % 1000);
            return hash.ToString();
        }
        public static string HashTwo(string elem)
        {
            double a = 0.61598;
            return ((int)(int.Parse(elem) * a * Math.PI * Math.Abs(Math.Tan(int.Parse(elem))) * (double)(int.Parse(elem) / 33) % 1000)).ToString();
        }
    }
}
