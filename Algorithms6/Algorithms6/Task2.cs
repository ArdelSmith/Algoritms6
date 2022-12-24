using ClassLibrary;
using HashTables;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms6
{
    public class Task2
    {
        public static void ExecuteTask()
        {
            var table = new OpenAddressHashTable(1);
            var tableDh = new OpenAddressHashTable(2);
            DoingSmth(table);
            
        }

        public static void DoingSmthDh(OpenAddressHashTable table)
        {
            var list = new List<int>();
            GenerationItems(list);
            InsertAllItems(list, table);
            var max = table.CalculatingClasterMaxLength();
            var min = table.CalculatingClasterMinLength();
            var average = table.CalculatingClasterAverageLength();
            var text = table.print();
            Console.WriteLine($"длина самого длинного кластера в таблице: {max}");
            Console.WriteLine($"длина среднего кластера в таблице: {average}");
            Console.WriteLine($"длина самого короткого кластера в таблице: {min}");
        }



        public static void DoingSmth(OpenAddressHashTable table)
        {
            var list = new List<int>();

            GenerationItems(list);
            InsertAllItems(list, table);
            var max = table.CalculatingClasterMaxLength();
            var min = table.CalculatingClasterMinLength();
            var average = table.CalculatingClasterAverageLength();
            var text = table.print();
            //Console.WriteLine(text);
            Console.WriteLine($"длина самого длинного кластера в таблице: {max}");
            Console.WriteLine($"длина среднего кластера в таблице: {average}");
            Console.WriteLine($"длина самого короткого кластера в таблице: {min}");
        }

        //Генерация 10000 элементов с различными ключами
        public static void GenerationItems(List<int> list)
        {
            var random = new Random();

            for (int i = 0; i < 10000; i++)
                list.Add(random.Next());
        }

        //Вставить все элементы в хеш-таблицу
        public static void InsertAllItems(List<int> list, OpenAddressHashTable table)
        {
            foreach (var e in list)
                table.AddItem(e);
        }
    }
}
