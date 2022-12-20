using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary;

namespace HashTables
{
    public class Pair
    {
        public string key;
        public MyList<string> values = new MyList<string>();
    }
    public class Table
    {
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

        }
        /// <summary>
        /// Удаляет элемент из таблицы
        /// </summary>
        /// <param name="elem"></param>
        public void Delete(string elem)
        {

        }
        /// <summary>
        /// Находит элемент в таблице
        /// </summary>
        /// <param name="elem"></param>
        public void Find(string elem)
        {

        }
        public static string CalculateHash()
        {
            return null;
        }
    }
    public static class Task1
    {

    }
}
