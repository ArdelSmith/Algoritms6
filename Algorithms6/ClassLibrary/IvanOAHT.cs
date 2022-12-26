using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class IvanOAHT
    {
        bool[] Deleted = new bool[10000];
        private const int K = 1;
        OPair[] table;
        int l = 10000;
        public IvanOAHT()
        {
            table = new OPair[l];
        }

        /// <summary>
        /// Находит элемент
        /// </summary>
        /// <param name="elem"></param>
        /// <param name="type">0 - linear, 1 - quadro, 2 - Double hash</param>
        /// <returns></returns>
        public int Find(int elem, int type)
        {
            switch (type)
            {
                case 0:
                    {
                        // Линейное исследование
                        int hash = HashFunctions.HashTwo(elem);
                        for (int i = hash % l; i < l; i++)
                        {
                            if (i > 9999) throw new Exception();
                            if (table[i % l].value != elem) continue;
                            else return i;
                        }
                        break;
                    }
                case 1:
                    {
                        // Квадратичное исследование
                        int hash = HashFunctions.HashTwo(elem);
                        int c = 0;
                        for (int i = hash % l; i < l; c++)
                        {
                            if (i > 9999) throw new Exception();
                            if (table[i % l].value != elem)
                            {
                                i = (hash + (c + c * c)/2) % l;
                                continue;
                            }
                            else return i;
                        }
                        break;
                    }
                case 2:
                    {
                        // Двойное хеширование
                        int hash = HashFunctions.ODoubleHash(elem);
                        int c = 0;
                        for (int i = hash % l; i < l; c++)
                        {
                            int add = HashFunctions.DoubleHash(c);
                            if (i > 9999) throw new Exception();
                            if (table[i % l].value != elem)
                            {
                                i = (hash + add * i) % l;
                            }
                            else return i;
                        }
                        break;
                    }
            }
            return 0;
        }
        public void Insert(int key, int value, int type)
        {
            switch (type)
            {
                case 0:
                    {
                        // Линейное исследование
                        int hash = HashFunctions.HashTwo(key);
                        for (int i = hash % l; i < l; i++)
                        {
                            if (i > 9999) throw new Exception();
                            if (!Deleted[i]) continue;
                            else
                            {
                                table[i].key = key;
                                table[i].value = value;
                                break;
                            }
                        }
                        break;
                    }
                case 1:
                    {
                        // Квадратичное исследование
                        int hash = HashFunctions.HashTwo(key);
                        int c = 1;
                        for (int i = hash % l; i < l; c *= c)
                        {
                            if (i > 9999) throw new Exception();
                            if (!Deleted[i])
                            {
                                i = i + c;
                                continue;
                            }
                            else
                            {
                                table[i].key = key;
                                table[i].value = value;
                                break;
                            }
                        }
                        break;
                    }
                case 2:
                    {
                        // Двойное хеширование
                        int hash = HashFunctions.ODoubleHash(key);
                        int c = 0;
                        for (int i = hash % l; i < l; c++)
                        {
                            int add = HashFunctions.DoubleHash(c);
                            if (i > 9999) throw new Exception();
                            if (table[i % l].value != key)
                            {
                                i = (hash + add * i) % l;
                            }
                        }
                        break;
                    }
            }
        }
    }
}
