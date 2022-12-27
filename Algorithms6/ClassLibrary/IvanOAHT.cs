using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class IvanOAHT
    {
        bool[] UnDeleted = new bool[10000];
        private const int K = 1;
        public OPair[] table;
        int l = 10000;
        public IvanOAHT()
        {
            table = new OPair[l];
            for (int i = 0; i < table.Length; i++)
            {
                table[i] = new OPair();
            }
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
                        int hash = HashFunctions.UsualHash(elem);
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
                        int hash = HashFunctions.UsualHash(elem);
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
                        int hash = HashFunctions.DoubleHash(elem);
                        int c = 0;
                        for (int i = hash % l; i < l; c++)
                        {
                            int add = HashFunctions.ODoubleHashAdditional(c);
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
                        int hash = HashFunctions.UsualHash(key);
                        for (int i = hash % l; i < l; i++)
                        {
                            if (i > 9999) i = i % 10000;
                            if (UnDeleted[i]) continue;
                            else
                            {
                                table[i] = new OPair();
                                table[i].key = key;
                                table[i].value = value;
                                UnDeleted[i] = true;
                                break;
                            }
                        }
                        break;
                    }
                case 1:
                    {
                        // Квадратичное исследование
                        int hash = HashFunctions.UsualHash(key);
                        int c = 1;
                        for (int i = hash % l; i < l; c *= c)
                        {
                            if (i > 9999) i = i % 10000;
                            if (UnDeleted[i])
                            {
                                i = i + c;
                                continue;
                            }
                            else
                            {
                                table[i] = new OPair();
                                table[i].key = key;
                                table[i].value = value;
                                UnDeleted[i] = true;
                                break;
                            }
                        }
                        break;
                    }
                case 2:
                    {
                        // Двойное хеширование
                        int hash = HashFunctions.UsualHash(key);
                        int add = HashFunctions.HashTwo(key);
                        for (int i = 0; i < l; i++)
                        {
                            if (i > 9999) i = i % 10000;
                            if (UnDeleted[i])
                            {
                                i = (hash + add * i) % l;
                            }
                            else
                            {
                                table[i] = new OPair();
                                table[i].key = key;
                                table[i].value = value;
                                UnDeleted[i] = true;
                                break;
                            }
                        }
                        break;
                    }
            }
        }
        public void Delete(int key, int type)
        {
            switch (type)
            {
                case 0:
                    {
                        // Линейное исследование
                        int hash = HashFunctions.UsualHash(key);
                        for (int i = hash % l; i < l; i++)
                        {
                            if (i > 9999) throw new Exception();
                            if (UnDeleted[i]) continue;
                            else
                            {
                                table[i] = new OPair();
                                table[i].value = -1;
                                UnDeleted[i] = true;
                                break;
                            }
                        }
                        break;
                    }
                case 1:
                    {
                        // Квадратичное исследование
                        int hash = HashFunctions.UsualHash(key);
                        int c = 1;
                        for (int i = hash % l; i < l; c *= c)
                        {
                            if (i > 9999) throw new Exception();
                            if (UnDeleted[i])
                            {
                                i = i + c;
                                continue;
                            }
                            else
                            {
                                table[i] = new OPair();
                                table[i].value = -1;
                                UnDeleted[i] = true;
                                break;
                            }
                        }
                        break;
                    }
                case 2:
                    {
                        // Двойное хеширование
                        int hash = HashFunctions.DoubleHash(key);
                        int c = 0;
                        for (int i = hash % l; i < l; c++)
                        {
                            int add = HashFunctions.ODoubleHashAdditional(c);
                            if (i > 9999) throw new Exception();
                            if (table[i % l].value != key)
                            {
                                i = (hash + add * i) % l;
                            }
                            else
                            {
                                table[i] = new OPair();
                                table[i].value = -1;
                                UnDeleted[i] = true;
                                break;
                            }
                        }
                        break;
                    }
            }
        }
    }
}
