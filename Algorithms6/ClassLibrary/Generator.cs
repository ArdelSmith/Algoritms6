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
        public void GeneratePairedElements(string fileName)
        {
            List<string> keys = new List<string>();
            List<string> values = new List<string>();
            List<string> n = new List<string>();
            for (int i = 0; i < 100000; i++)
            {
                Random random = new Random();
                int k = random.Next(1, 10000000);
                int v = random.Next(1, 10000000);
                while (keys.Contains(k.ToString()) || values.Contains(v.ToString()))
                {
                    k = random.Next(1, 10000000);
                    v = random.Next(1, 10000000);
                }
                keys.Add(k.ToString());
                values.Add(random.Next(1, 10000000).ToString());
            }
            if (!File.Exists(fileName))
            {
                for (int i = 0; i < keys.Count; i++)
                {
                    n.Add(keys[i] + ";" + values[i]);
                }
                File.AppendAllLines(fileName, n.ToArray());
            }
            else
            {
                File.Delete(fileName);
                for (int i = 0; i < keys.Count; i++)
                {
                    n.Add(keys[i] + ";" + values[i]);
                }
                File.AppendAllLines(fileName, n.ToArray());
            }
        }
    }
}
