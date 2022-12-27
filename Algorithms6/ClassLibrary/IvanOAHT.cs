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
        public Dictionary<int, int> clusters = new Dictionary<int, int>();
        public Dictionary<int, int> table = new Dictionary<int, int>();
        int l = 10000;

        /// <summary>
        /// Находит элемент
        /// </summary>
        /// <param name="key"></param>
        /// <param name="type">0 - linear, 1 - quadro, 2 - Double hash</param>
        /// <returns></returns>
        public int Find(int key,int value, int type)
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
                            if (table.ContainsKey(i))
                            {
                                int k = table[i];
                                if (k == value) return i;
                            }
                            else continue;
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
                            if (table.ContainsKey(i))
                            {
                                int k = table[i];
                                if (k == value) return i;
                            }
                            else
                            {
                                i = i + c;
                                continue;
                            }
                        }
                        break;
                    }
                case 2:
                    {
                        // Двойное хеширование
                        int hash = HashFunctions.Bebra(key);
                        int add = HashFunctions.ODoubleHashAdditional(key);
                        for (int i = 0; i < l; i++)
                        {
                            if (table.ContainsKey(hash))
                            {
                                int k = table[i];
                                if (k == value) return i;
                            }
                            else if (!table.ContainsKey(hash + i * add))
                            {
                                int k = table[hash + i * add];
                                if (k == value) return hash + i * add;
                            }
                        }
                        throw new IndexOutOfRangeException();
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
                        int count = 1;
                        for (int i = hash % l; i < l; i++)
                        {
                            if (i > 9999) i = i % 10000;
                            if (table.ContainsKey(i)) {
                                count++;
                                continue;
                            }
                            else
                            {
                                table.Add(i, value);
                                clusters.Add(i, count);
                                break;
                            }
                        }
                        break;
                    }
                case 1:
                    {
                        // Квадратичное исследование
                        int hash = HashFunctions.UsualHash(key);
                        int count = 1;
                        int c = 1;
                        for (int i = hash % l; i < l; c *= c)
                        {
                            if (i > 9999) i = i % 10000;
                            if (table.ContainsKey(i))
                            {
                                i = i + c;
                                count++;
                                continue;
                            }
                            else
                            {
                                table.Add(i, value);
                                clusters.Add(i, count);
                                break;
                            }
                        }
                        break;
                    }
                case 2:
                    {
                        // Двойное хеширование
                        int hash = HashFunctions.Bebra(key);
                        int add = HashFunctions.ODoubleHashAdditional(key);
                        int count = 1;
                        for (int i = 0; i < l; i++)
                        {
                            if (!table.ContainsKey(hash))
                            {
                                table.Add(hash, value);
                                clusters.Add(hash, count);
                                return;
                            }
                            else if (!table.ContainsKey(hash + i*add))
                            {
                                table.Add(hash + i * add, value);
                                clusters.Add(hash + i * add, count);
                                return;
                            }
                            count++;
                        }
                        throw new IndexOutOfRangeException();
                    }
            }
        }
        /// <summary>
        /// Удаляет элемент из таблицы, для удаления нужен ключ и значение
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        /// <exception cref="IndexOutOfRangeException"></exception>
        public int Delete(int key, int value, int type)
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
                            if (table.ContainsKey(i))
                            {
                                int k = table[i];
                                if (k == value) table.Remove(i);
                                return i;
                            }
                            else continue;
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
                            if (table.ContainsKey(i))
                            {
                                int k = table[i];
                                if (k == value) table.Remove(i);
                                return i;
                            }
                            else
                            {
                                i = i + c;
                                continue;
                            }
                        }
                        break;
                    }
                case 2:
                    {
                        // Двойное хеширование
                        int hash = HashFunctions.Bebra(key);
                        int add = HashFunctions.ODoubleHashAdditional(key);
                        for (int i = 0; i < l; i++)
                        {
                            if (table.ContainsKey(hash))
                            {
                                int k = table[i];
                                if (k == value) table.Remove(i);
                                return i;
                            }
                            else if (!table.ContainsKey(hash + i * add))
                            {
                                int k = table[hash + i * add];
                                if (k == value) table.Remove(i);
                                return i;
                            }
                        }
                        throw new IndexOutOfRangeException();
                    }
            }
            return 0;
        }
        public void FindMinMax()
        {
            int min = 0;
            int max = 0;
            foreach (var elem in clusters)
            {
                if (elem.Value > max) max = elem.Value;
            }
            min = max;
            foreach (var elem in clusters)
            {
                if (elem.Value < min) min = elem.Value;
            }
            Console.WriteLine("min:" + min);
            Console.WriteLine("max:" + max);
        }
    }
}
