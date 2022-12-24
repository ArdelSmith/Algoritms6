using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary;

namespace HashTables
{
    public class Generator
    {
        /// <summary>
        /// Генерирует 100000 случайных элементов
        /// </summary>
        public void GenerateElements(string fileName)
        {
            List<string> elems = new List<string>();
            for (int i = 0; i < 100000; i++)
            {
                Random random = new Random();
                elems.Add(random.Next(1, 10000000).ToString());
            }
            if (!File.Exists(fileName))
            {
                File.AppendAllLines(fileName, elems.ToArray());
            }
            else
            {
                File.Delete(fileName);
                File.AppendAllLines(fileName, elems.ToArray());
            }
        }
    }
    public class Pair
    {
        public int key;
        public MyList<int> values = new MyList<int>();
    }
    public class Table
    {

        //список ключей для нашей таблицы
        private List<string> keys = new List<string>();

        //фактически сама таблица
        Pair[] table;

        public Table()
        {
            table = new Pair[1000];
        }
        /// <summary>
        /// Вставляет элемент в таблицу
        /// </summary>
        /// <param name="elem"></param>
        public void Insert(int elem)
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
        public void Delete(int elem)
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
        public void Find(int elem)
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
                double val = (double) e / count * 100;
                val = Math.Round(val, 3);
                Console.WriteLine($"По ключу {elem.Key} находится {e} элементов, что составляет {val}% от всей таблицы");
                elems.Add(val.ToString());
            }
            //File.AppendAllLines("HashThree.csv", elems.ToArray());
        }
        /// <summary>
        /// Считает хеш для какого-то значения, используется метод деления
        /// </summary>
        /// <param name="elem"></param>
        /// <returns></returns>
        public static int CalculateHash(int elem)
        {
            return HashFunctions.UsualHash(elem);
        }

        /// <summary>
        /// Находит длину самой длинной и короткой цепочек в таблице
        /// </summary>
        public void FindMinMax()
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
    public static class Task1
    {
        public static Table ExecuteTask(string fileName)
        {
            Table table = new Table();
            foreach (var value in File.ReadLines(fileName))
            {
                table.Insert(int.Parse(value));
            }
            return table;
        }
    }
}
