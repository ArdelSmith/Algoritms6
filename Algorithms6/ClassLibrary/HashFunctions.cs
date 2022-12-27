using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public static class HashFunctions
    {
        public static int UsualHash(int elem)
        {
            return (elem % 1000);
        }
        public static int HashOne(int elem)
        {
            int hash = (int)(Math.Sqrt(Math.Sqrt(elem)) * 10000 % 1000);
            return hash;
        }
        public static int HashTwo(int elem)
        {
            double a = 0.61598;
            return ((int)(elem * a * Math.PI
                * Math.Abs(Math.Tan(elem))
                    * (double)(elem / 33) % 1000));
        }
        //вот эта выглядит как расчёска!
        public static int HashThree(int elem)
        {
            int d = elem % 18 + 1;
            return elem % (53 * d);
        }
        public static int DoubleHash(int elem)
        {
            return UsualHash(HashOne(elem));
        }
        public static int GetSum(int elem)
        {
            int b = elem;
            int c = 0;
            string e = elem.ToString();
            for (int i = 0; i < e.Length; i++)
            {
                int t = b % 10;
                c += t;
                b /= 10;
            }
            return c;
        }
        public static int Bebra(int elem)
        {
            return Math.Abs(GetSum(elem) % 10000);
        }
        public static int ODoubleHashAdditional(int elem)
        {
            return Math.Abs(GetSum(elem) % (1000 - 1) + 1);
        }
    }
}
