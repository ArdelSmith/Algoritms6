using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class Table
    {

        //список ключей для нашей таблицы
        private List<string> keys = new List<string>();

        //фактически сама таблица
         protected Pair[] table;

        public Table()
        {
            table = new Pair[1000];
        }
        /// <summary>
        /// Вставляет элемент в таблицу
        /// </summary>
        /// <param name="elem"></param>
        public virtual void Insert(int elem)
        {
            int hash = CalculateHash(elem);
            int v = hash;
            if (table[v] == null)
            {
                table[v] = new Pair();
                table[v].key = hash;
                table[v].values.AppendFirst(elem);
            }
            else
            {
                table[v].values.AppendFirst(elem);
            }
        }
        /// <summary>
        /// Удаляет элемент из таблицы
        /// </summary>
        /// <param name="elem"></param>
        public virtual void Delete(int elem)
        {
            int hash = CalculateHash(elem);
            bool e = table[hash].values.RemoveAllDuplicates(elem);
            if (e) Console.WriteLine("Element has been removed");
            else Console.WriteLine("There is no such element in table");
        }
        /// <summary>
        /// Находит элемент в таблице
        /// </summary>
        /// <param name="elem"></param>
        public virtual void Find(int elem)
        {
            int hash = CalculateHash(elem);
            foreach (Pair pair in table)
            {
                if (pair.values.Contains(elem))
                {
                    Console.WriteLine($"Elem {elem} placed in table with hash-code {hash}");
                }
                else Console.WriteLine("There is no such elem in table!");
            }

        }
        /// <summary>
        /// Считает заполненность хеш-таблицы
        /// </summary>
        public void CalculateOccupancy()
        {
            //записываем в словарь ключ и количество элементов, находящихся по этому ключу в таблице
            Dictionary<int, long> occupancy = new Dictionary<int, long>();
            long count = 0;
            foreach (var pair in table)
            {
                if (pair == null) continue;
                else
                {
                    long amount = pair.values.Count;
                    occupancy.Add(pair.key, amount);
                    count += amount;
                }
            }
            List<string> elems = new List<string>();
            foreach (var elem in occupancy)
            {
                long e = elem.Value;
                double val = (double)e / count * 100;
                val = Math.Round(val, 3);
                Console.WriteLine($"По ключу {elem.Key} находится {e} элементов, что составляет {val}% от всей таблицы");
                elems.Add(val.ToString());
            }
            File.AppendAllLines("HashThree.csv", elems.ToArray());
        }
        /// <summary>
        /// Считает хеш для какого-то значения, используется метод деления
        /// </summary>
        /// <param name="elem"></param>
        /// <returns></returns>
        public static int CalculateHash(int elem)
        {
            return HashFunctions.HashThree(elem);
        }

        /// <summary>
        /// Находит длину самой длинной и короткой цепочек в таблице
        /// </summary>
        public virtual void FindMinMax()
        {
            int min = 0;
            int max = 0;
            foreach (var pair in table)
            {
                int e = pair.values.Count();
                if (min == 0 || max == 0)
                {
                    min = e;
                    max = e;
                }
                if (e > max) max = e;
                if (e < min) min = e;
            }
            Console.WriteLine($"Длина максимальной цепочки - {max}");
            Console.WriteLine($"Длина минимальной цепочки - {min}");
        }
    }
}
