using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
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
}
