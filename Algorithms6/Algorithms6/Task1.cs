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
        public void GenerateElements()
        {
            List<string> elems = new List<string>();
            for (int i = 0; i < 100000; i++)
            {
                Random random = new Random();
                const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
                elems.Add(new string(Enumerable.Repeat(chars, random.Next(5, 20))
                    .Select(s => s[random.Next(s.Length)]).ToArray()));
            }
            File.AppendAllLines("test.csv", elems.ToArray());
        }
    }
    public class Pair
    {
        public string key;
        public MyList<string> values = new MyList<string>();
    }
    public class Table
    {
        //просто константа для подсчёта хеша методом умножения
        const double A = 0.741;

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
        public void Insert(string elem)
        {
            string hash = CalculateHash(elem);
            foreach (Pair pair in table)
            {
                if (pair.key != hash) continue;
                else
                {
                    pair.values.AppendFirst(elem);
                }
            }
        }
        /// <summary>
        /// Удаляет элемент из таблицы
        /// </summary>
        /// <param name="elem"></param>
        public void Delete(string elem)
        {
            string hash = CalculateHash(elem);
            foreach (Pair pair in table)
            {
                if (pair.key != hash) continue;
                else
                {
                    pair.values.Remove(elem);
                }
            }
        }
        /// <summary>
        /// Находит элемент в таблице
        /// </summary>
        /// <param name="elem"></param>
        public void Find(string elem)
        {
            string hash = CalculateHash(elem);
        }
        /// <summary>
        /// Считает заполненность хеш-таблицы
        /// </summary>
        public void CalculateOccupancy()
        {
            //записываем в словарь ключ и количество элементов, находящихся по этому ключу в таблице
            Dictionary<string, long> occupancy = new Dictionary<string, long>();
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
            foreach (var elem in occupancy)
            {
                long e = elem.Value;
                Console.WriteLine($"По ключу {elem.Key} находится {e} элементов, что составляет {e/count*100}% от всей таблицы");
            }
        }
        /// <summary>
        /// Считает хеш для какого-то значения, используется метод умножения
        /// </summary>
        /// <param name="elem"></param>
        /// <returns></returns>
        public static string CalculateHash(string elem)
        {
            return null;
        }
    }
    public static class Task1
    {
        public static void ExecuteTask()
        {
        }
    }
}
