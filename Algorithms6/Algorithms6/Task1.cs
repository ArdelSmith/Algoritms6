using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary;

namespace HashTables
{
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
